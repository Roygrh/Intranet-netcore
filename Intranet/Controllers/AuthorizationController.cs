using AutoMapper;
using Intranet.Data;
using Intranet.Models;
using Intranet.Services.AuthorizationState;
using Intranet.Services.DateTimeManagement;
using Intranet.Services.FileConverter;
using Intranet.Services.Unit;
using Intranet.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;

namespace Intranet.Controllers
{
    [Authorize]
    public class AuthorizationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AuthorizationStateManagement _authorizationStateManagement;
        private readonly DataTimeManagement _dateTimeManagement;
        private readonly ApplicationDbContext _context;
        // GET: AuthorizationController

        public AuthorizationController(IMapper mapper, IUnitOfWork unitOfWork, 
            AuthorizationStateManagement authorizationStateManagement, 
            DataTimeManagement dateTimeManagement, ApplicationDbContext context)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
            this._authorizationStateManagement = authorizationStateManagement;
            this._dateTimeManagement = dateTimeManagement;
            this._context = context;
        }

        public ActionResult Index()
        {
            UserVM user = GetDataUserCookie();

            List<AuthorizationVM> authorizations = this._mapper.Map<List<AuthorizationVM>>(this._unitOfWork.StoredProcedures.Sp_Commissions(user.DNI));
            var states = this._mapper.Map<List<AuthorizationStateVM>>(this._unitOfWork.AuthorizationStatus.Get().ToList());

            foreach (var authorization in authorizations)
            {
                authorization.ESTADO = states.Find(s => s.ESTADO_ID == authorization.ID_ESTADO);
            }

            return View(authorizations);
        }

        public ActionResult Overview()
        {
            UserVM user = GetDataUserCookie();
            if (user != null && user.UserTypeName.ToLower().Contains("admin"))
            {
                OverviewVM overview = this._authorizationStateManagement.GetOverviewListbyUserforStates(DateTime.Now.AddDays(-20), DateTime.Now);
                overview.Authorization = new AuthorizationVM();
                return View(overview);
            }
            else if (user.UserTypeName.ToLower().Contains("estandar"))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction(nameof(Watchview));
            }
        }

        public ActionResult Watchview()
        {
            OverviewVM overview = this._authorizationStateManagement.GetOverviewListbyUserforStates(DateTime.Now.AddDays(-5), DateTime.Now);
            overview.Authorization = new AuthorizationVM();
            return View(overview);
        }

        public ActionResult HRview()
        {
            UserVM user = GetDataUserCookie();

            OverviewVM overview = this._authorizationStateManagement.GetOverviewListbyUserforStates(DateTime.Now.AddDays(-5), DateTime.Now);
            overview.Authorization = new AuthorizationVM();
            return View(overview);
        }

        // GET: AuthorizationController/Details/5
        public ActionResult Details(decimal id)
        {
            UserVM user = GetDataUserCookie();
            this._authorizationStateManagement.SelectAuthorization(id).IncludeStatesList().IncludeOwnMovementsListAndStatesList();
            this._authorizationStateManagement.Authorization.SESSIONUSER = user;
            return View(this._authorizationStateManagement.Authorization);
        }

        // GET: AuthorizationController/Create
        public ActionResult Create()
        {
            UserVM user = GetDataUserCookie();
            var authorization = this._authorizationStateManagement.CreateNewAuthorization();
            AuthorizationObjectInitialization(authorization);
            return View(authorization);
        }

        // POST: AuthorizationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AuthorizationVM Authorization)
        {
            try
            {
                var user = GetDataUserCookie();
                Authorization.USUARIO_CREA = user.DNI;
                Authorization.USARIO_CREA_NOMBRE = user.UserFullName;
                this._authorizationStateManagement.SelectAuthorization(Authorization).SwitchToPending();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: AuthorizationController/Edit/5
        public ActionResult Edit(int id)
        {
            UserVM user = GetDataUserCookie();
            var authorization = this._authorizationStateManagement
                .SelectAuthorization(id)
                .Authorization;

            if (user != null && !user.DNI.Equals(authorization.USUARIO_CREA))
            {
                return RedirectToAction(nameof(Index));
            }

            return View(authorization);
        }

        // POST: AuthorizationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(decimal id, AuthorizationVM Authorization)
        {
            try
            {
                UserVM user = GetDataUserCookie();

                if (user != null && !user.DNI.Equals(Authorization.USUARIO_CREA))
                {
                    return RedirectToAction(nameof(Index));
                }
                var authorization = this._authorizationStateManagement.SelectAuthorization(id).GetAuthorization();
                authorization.FECHA_SALIDA_PROG = this._dateTimeManagement.StringToDateTime(Authorization.FECHA_SALIDA_PROG);
                authorization.FECHA_RETORNO_PROG = this._dateTimeManagement.StringToDateTime(Authorization.FECHA_RETORNO_PROG);
                authorization.RETORNO = Authorization.RETORNO;
                authorization.DESCRIPCION = Authorization.DESCRIPCION;
                authorization.FECHA_EDICION = DateTime.Now;
                authorization.MOTIVO = Authorization.MOTIVO;

                if (Authorization.FILE != null)
                {
                    authorization.FILE = new FileConverter().ConvertFileToBytes(Authorization.FILE);
                    authorization.TIPO_CONTENIDO_FILE = Authorization.FILE.ContentType;
                    authorization.NOMBRE_ARCHIVO = Authorization.FILE.FileName;
                }

                var auto_audi = this._authorizationStateManagement.GetAuthorizationAuditory();
                auto_audi.TIPO_MOVIMIENTO = "EDICION";
                auto_audi.FECHA_MOVIMIENTO = DateTime.Now;

                this._unitOfWork.Authorizations.Update(authorization);
                this._unitOfWork.AuthorizationAuditory.Add(auto_audi);
                this._unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: AuthorizationController/Delete/5
        public ActionResult Delete(int id)
        {
            return RedirectToAction(nameof(Index));
            var authorization = this._authorizationStateManagement.SelectAuthorization(id).Authorization;
            return View(authorization);
        }

        // POST: AuthorizationController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                //var authorization = this._unitOfWork.Authorizations.GetById(id);
                //this._unitOfWork.Authorizations.Delete(authorization);
                //var auto_audi = this._authorizationStateManagement.GetAuthorizationAuditory();
                //auto_audi.TIPO_MOVIMIENTO = "ELIMINACION";
                //auto_audi.FECHA_MOVIMIENTO = DateTime.Now;

                //this._unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View();
            }
        }

        public ActionResult Cancel(decimal id)
        {
            UserVM user = GetDataUserCookie();
            var authorization = this._authorizationStateManagement.SelectAuthorization(id).Authorization;
            if(user != null && (user.UserTypeName.ToLower().Contains("admin") || user.DNI.Equals(authorization.USUARIO_CREA) ))
            {
                return View(authorization);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            var authorization = this._unitOfWork.Authorizations.GetById(id);
            this._authorizationStateManagement.SetAuthorization(authorization);

            var state = this._unitOfWork.AuthorizationStatus.Get(s => s.NOMBRE_ESTADO.Trim().Equals("anulado")).First();
            authorization.ID_ESTADO = state.ESTADO_ID;

            var auto_audi = this._authorizationStateManagement.GetAuthorizationAuditory();
            auto_audi.TIPO_MOVIMIENTO = "CAMBIO DE ESTADO";
            auto_audi.FECHA_MOVIMIENTO = DateTime.Now;

            this._unitOfWork.Authorizations.Update(authorization);
            this._unitOfWork.AuthorizationAuditory.Add(auto_audi);
            this._unitOfWork.Commit();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet, ActionName("Change-state")]
        public ActionResult ChangeState(decimal id)
        {
            var authorization = this._authorizationStateManagement.SelectAuthorization(id).Authorization;
            return View(authorization);
        }

        [HttpGet, ActionName("Change-state-admin")]
        public ActionResult ChangeStateAdmin(decimal id)
        {
            var authorization = this._authorizationStateManagement.SelectAuthorization(id).Authorization;
            authorization.OWNERUSER = this._unitOfWork.ActiveDirectoryUsers.Get(a => a.DNI == authorization.USUARIO_CREA)
                .Select(a => {
                    var user = new UserVM();
                    user.DNI = a.DNI;
                    user.UserFullName = a.Display_Name;
                    return user;
                }).First();
            return View(authorization);
        }

        [HttpGet, ActionName("Change-state-watch")]
        public ActionResult ChangeStateWatch(decimal id)
        {
            var authorization = this._authorizationStateManagement.SelectAuthorization(id).Authorization;
            authorization.OWNERUSER = this._unitOfWork.ActiveDirectoryUsers.Get(a => a.DNI == authorization.USUARIO_CREA)
                .Select(a => {
                    var user = new UserVM();
                    user.DNI = a.DNI;
                    user.UserFullName = a.Display_Name;
                    return user;
                }).First();
            return View(authorization);
        }

        [HttpGet, ActionName("Change-state-hr")]
        public ActionResult ChangeStateHR(decimal id)
        {
            var authorization = this._authorizationStateManagement.SelectAuthorization(id).Authorization;
            authorization.OWNERUSER = this._unitOfWork.ActiveDirectoryUsers.Get(a => a.DNI == authorization.USUARIO_CREA)
                .Select(a => {
                    var user = new UserVM();
                    user.DNI = a.DNI;
                    user.UserFullName = a.Display_Name;
                    return user;
                }).First();
            return View(authorization);
        }

        [HttpPost, ActionName("Change-state")]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeState(decimal IdAuthorization, decimal IdState)
        {
            var user = GenerateUserForAuthorization();
            this._authorizationStateManagement.SelectAuthorization(IdAuthorization);
            this._authorizationStateManagement.Authorization.USUARIO_AUTORIZA = user.DNI;

            var state = this._unitOfWork.AuthorizationStatus.GetById(IdState);

            this._authorizationStateManagement.SwitchTo(state.NOMBRE_ESTADO.ToLower(), DateTime.Now);

            return RedirectToAction(nameof(Overview));
        }

        [HttpPost]
        public FileResult DownloadFile(decimal? id)
        {
            byte[] bytes;
            var contenido = this._unitOfWork.Authorizations.GetById(id.Value);
            bytes = contenido.FILE;

            return File(bytes, contenido.TIPO_CONTENIDO_FILE, contenido.NOMBRE_ARCHIVO);
        }

        public FileResult GetReport(decimal id)
        {
            var contenido = this._unitOfWork.Authorizations.GetById(id);
            return File(contenido.FILE, contenido.TIPO_CONTENIDO_FILE);
        }

        private AuthorizationVM AuthorizationObjectInitialization(AuthorizationVM authorization)
        {
            UserVM user = GetDataUserCookie();

            authorization.USUARIO_CREA = user.DNI;
            authorization.OWNERUSER = user;
            authorization.ID_TIPO_USUARIO = user.UserType;
            authorization.AUTHORIZINGUSER = GenerateUserForAuthorization();

            return authorization;
        }

        private UserVM GetDataUserCookie()
        {
            var userCookie = HttpContext.User;
            UserVM user = null;

            if (userCookie.Identity.IsAuthenticated)
            {
                user = new UserVM
                {
                    UserName = userCookie.FindFirstValue("UserName"),
                    UserFullName = userCookie.FindFirstValue(ClaimTypes.Name),
                    Email = userCookie.FindFirstValue(ClaimTypes.Email),
                    DNI = userCookie.FindFirstValue("DNI"),
                    UserTypeName = userCookie.FindFirstValue("userType")
                };
            }

            return user;
        }

        private UserVM GenerateUserForAuthorization()
        {
            UserVM user = this._mapper.Map<UserVM>(this._unitOfWork.ActiveDirectoryUsers.Get(a => a.DNI.Equals("10506225")).FirstOrDefault());

            return user;
        }
    }
}

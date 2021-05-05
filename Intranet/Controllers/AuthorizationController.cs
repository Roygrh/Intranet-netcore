using AutoMapper;
using Intranet.Data;
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
            var user = HttpContext.User;
            var b = user.Claims;
            var c = user.Identities;
            var d = user.Identity;
            //var e = HttpContext.Session;
            var f = user.FindFirstValue("UserName");
            var g = user.FindFirst(ClaimTypes.Email);
            var h = user.FindFirst(ClaimTypes.Name);
            var tmp = this._authorizationStateManagement.GetAuthorizationPaging(DateTime.Now.AddDays(-15), DateTime.Now, "", 1, 5);
            List<AuthorizationVM> authorizations = this._mapper.Map<List<AuthorizationVM>>(this._unitOfWork.Authorizations.Get(a => a.USUARIO_CREA.Equals("01844800")).ToList());
            var authorizationtmp = this._unitOfWork.Authorizations.Get().First();
            var states = this._mapper.Map<List<AuthorizationStateVM>>(this._unitOfWork.AuthorizationStatus.Get().ToList());

            foreach (var authorization in authorizations)
            {
                authorization.ESTADO = states.Find(s => s.ESTADO_ID == authorization.ID_ESTADO);
            }

            return View(authorizations);
        }

        public ActionResult Overview()
        {
            OverviewVM overview = this._authorizationStateManagement.GetOverviewListbyUserforStates(DateTime.Now.AddDays(-5), DateTime.Now);
            overview.Authorization = new AuthorizationVM();
            return View(overview);
        }

        public ActionResult Watchview()
        {
            OverviewVM overview = this._authorizationStateManagement.GetOverviewListbyUserforStates(DateTime.Now.AddDays(-5), DateTime.Now);
            overview.Authorization = new AuthorizationVM();
            return View(overview);
        }

        public ActionResult HRview()
        {
            OverviewVM overview = this._authorizationStateManagement.GetOverviewListbyUserforStates(DateTime.Now.AddDays(-5), DateTime.Now);
            overview.Authorization = new AuthorizationVM();
            return View(overview);
        }

        // GET: AuthorizationController/Details/5
        public ActionResult Details(decimal id)
        {
            this._authorizationStateManagement.SelectAuthorization(id).IncludeStatesList().IncludeOwnMovementsListAndStatesList();
            return View(this._authorizationStateManagement.Authorization);
        }

        // GET: AuthorizationController/Create
        public ActionResult Create()
        {
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
            var authorization = this._authorizationStateManagement.SelectAuthorization(id).Authorization;
            return View(authorization);
        }

        // POST: AuthorizationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AuthorizationVM Authorization)
        {
            try
            {
                var authorization = this._unitOfWork.Authorizations.GetById(id);
                authorization.FECHA_SALIDA_PROG = this._dateTimeManagement.StringToDateTime(Authorization.FECHA_SALIDA_PROG + " " + Authorization.HORA_SALIDA_PROG);
                authorization.FECHA_RETORNO_PROG = this._dateTimeManagement.StringToDateTime(Authorization.FECHA_RETORNO_PROG + " " + Authorization.HORA_RETORNO_PROG);
                authorization.RETORNO = Authorization.RETORNO;
                authorization.DESCRIPCION = Authorization.DESCRIPCION;
                authorization.FECHA_EDICION = DateTime.Now;
                authorization.USUARIO_EDITA = "08887865";

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
            var authorization = this._authorizationStateManagement.SelectAuthorization(id).Authorization;
            return View(authorization);
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
            authorization.OWNERUSER = this._unitOfWork.AttendanceRepository.Get(a => a.id_personal == authorization.USUARIO_CREA)
                .Select(u => {
                    var user = new PersonalVM();
                    user.cod_personal = u.id_personal;
                    user.nombre = u.nombres;
                    return user;
                }).First();
            return View(authorization);
        }

        [HttpGet, ActionName("Change-state-watch")]
        public ActionResult ChangeStateWatch(decimal id)
        {
            var authorization = this._authorizationStateManagement.SelectAuthorization(id).Authorization;
            authorization.OWNERUSER = this._unitOfWork.AttendanceRepository.Get(a => a.id_personal == authorization.USUARIO_CREA)
                .Select(u => {
                    var user = new PersonalVM();
                    user.cod_personal = u.id_personal;
                    user.nombre = u.nombres;
                    return user;
                }).First();
            return View(authorization);
        }

        [HttpGet, ActionName("Change-state-hr")]
        public ActionResult ChangeStateHR(decimal id)
        {
            var authorization = this._authorizationStateManagement.SelectAuthorization(id).Authorization;
            authorization.OWNERUSER = this._unitOfWork.AttendanceRepository.Get(a => a.id_personal == authorization.USUARIO_CREA)
                .Select(u => {
                    var user = new PersonalVM();
                    user.cod_personal = u.id_personal;
                    user.nombre = u.nombres;
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
            this._authorizationStateManagement.Authorization.USUARIO_AUTORIZA = user.cod_personal;

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
            PersonalVM user = new PersonalVM();
            authorization.USUARIO_CREA = user.cod_personal = "01844800";
            user.nombre = "AMARU CHAMBILLA GLICERIO REYES";
            authorization.OWNERUSER = user;
            authorization.UNIDAD_ORGANICA = "UNIDAD ORGANICA";
            authorization.ID_TIPO_USUARIO = 2;
            authorization.ID_AREA_FUNCIONAL = 1;
            authorization.AUTHORIZINGUSER = GenerateUserForAuthorization();

            return authorization;
        }

        private PersonalVM GenerateUserForAuthorization()
        {
            PersonalVM user = new PersonalVM();
            user.cod_personal = "08887865";
            user.nombre = "AGUILAR ARAKAKI REGINA ELENA";

            return user;
        }
    }
}

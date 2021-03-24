using AutoMapper;
using Intranet.Data;
using Intranet.Services.AuthorizationState;
using Intranet.Services.Unit;
using Intranet.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Intranet.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AuthorizationStateManagement _authorizationStateManagement;
        // GET: AuthorizationController

        public AuthorizationController(IMapper mapper, UnitOfWork unitOfWork, AuthorizationStateManagement authorizationStateManagement)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
            this._authorizationStateManagement = authorizationStateManagement;
        }

        public ActionResult Index()
        {
            var authorizationList = this._mapper.Map<List<AuthorizationVM>>(this._unitOfWork.Authorizations.Get().ToList());
            return View(authorizationList);
        }

        // GET: AuthorizationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorizationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AuthorizationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorizationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AuthorizationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private AuthorizationVM AuthorizationObjectInitialization(AuthorizationVM authorization)
        {
            BasicUserInformationVM user = new BasicUserInformationVM();
            authorization.USUARIO_CREA = user.USUARIO_CREA = "PES-001234";
            user.USER_NAME = "Mario Huapaya Chumpitaz";
            authorization.USER = user;
            authorization.UNIDAD_ORGANICA = "UNIDAD DE";
            authorization.ID_TIPO_USUARIO = 2;
            authorization.ID_AREA_FUNCIONAL = 1;
            authorization.USER = GenerateUserForAuthorization();

            return authorization;
        }

        private BasicUserInformationVM GenerateUserForAuthorization()
        {
            BasicUserInformationVM user = new BasicUserInformationVM();
            user.USUARIO_CREA = "PES-002345";
            user.USER_NAME = "Marcos Almengor Ríos";

            return user;
        }
    }
}

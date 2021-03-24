using AutoMapper;
using Intranet.Models;
using Intranet.Services.Unit;
using Intranet.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.Services.AuthorizationState
{
    public class AuthorizationStateManagement
    {
        public AuthorizationVM Authorization;
        private IUnitOfWork _unitOfWork;
        private IT_AUTORIZACION _authorization;
        private IMapper _mapper;
        public AuthorizationStateManagement(IMapper mapper, UnitOfWork unitOfWork)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
        }

        public AuthorizationVM CreateNewAuthorization()
        {
            var authorization = new AuthorizationVM();
            authorization.LISTA_DE_ESTADOS = this._mapper.Map<List<AuthorizationStateVM>>(this._unitOfWork.AuthorizationStatus.Get().ToList());
            authorization.LISTA_DE_MOTIVOS = this._mapper.Map<List<AuthorizationMotiveVM>>(this._unitOfWork.AuthorizationMotive.Get().ToList());
            authorization.ESTADO = new AuthorizationStateVM();
            authorization.ESTADO.NOMBRE_ESTADO = "SIN SOLICITAR";
            //var authos = this._unitOfWork.Authorizations.Get().ToList();
            var movements = this._unitOfWork.MovementAuthorizations.Get().ToList();
            return authorization;
        }
    }
}

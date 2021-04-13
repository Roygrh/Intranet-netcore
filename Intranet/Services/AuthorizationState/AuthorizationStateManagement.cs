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
            authorization.RETORNO = "SI";
            var movements = this._unitOfWork.MovementAuthorizations.Get().ToList();
            return authorization;
        }

        public OverviewVM GetOverviewListbyUserforStates(DateTime? start, DateTime? end, string userId = null)
        {
            OverviewVM overview = new OverviewVM();
            overview.ID_USUARIO = userId;
            if (start.HasValue && end.HasValue)
            {
                List<AuthorizationVM> authorizations = null;

                if (string.IsNullOrWhiteSpace(userId))
                {
                    authorizations = this._mapper.Map<List<AuthorizationVM>>(this._unitOfWork.Authorizations.Get(a => start.Value <= a.FECHA_CREACION.Value && a.FECHA_CREACION.Value <= end.Value, q => q.OrderByDescending(au => au.FECHA_CREACION)).ToList());
                    var users = this._unitOfWork.AttendanceRepository.Get().Select(u => (u.id_personal, u.nombres)).Distinct().Select(u => {
                        var user = new PersonalVM();
                        user.cod_personal = u.id_personal;
                        user.nombre = u.nombres.Trim();
                        return user;
                    }).ToList();
                    authorizations.ForEach( a => {
                        a.OWNERUSER = users.Find(u => u.cod_personal.Trim().Equals(a.USUARIO_CREA));
                    });
                }
                else
                    authorizations = this._mapper.Map<List<AuthorizationVM>>(this._unitOfWork.Authorizations.Get(a => start.Value <= a.FECHA_CREACION.Value && a.FECHA_CREACION.Value <= end.Value && a.USUARIO_CREA.Equals(userId), q => q.OrderByDescending(au => au.FECHA_CREACION)).ToList());

                var states = this._unitOfWork.AuthorizationStatus.Get().ToList();

                var pendingId = states.Find(s => s.NOMBRE_ESTADO.Trim().ToLower().Equals("pendiente")).ESTADO_ID;
                var authorizedId = states.Find(s => s.NOMBRE_ESTADO.Trim().ToLower().Equals("autorizado")).ESTADO_ID;
                var executedId = states.Find(s => s.NOMBRE_ESTADO.Trim().ToLower().Equals("ejecutado")).ESTADO_ID;
                var finishedId = states.Find(s => s.NOMBRE_ESTADO.Trim().ToLower().Equals("finalizado")).ESTADO_ID;
                var rejectedId = states.Find(s => s.NOMBRE_ESTADO.Trim().ToLower().Equals("rechazado")).ESTADO_ID;
                var canceledId = states.Find(s => s.NOMBRE_ESTADO.Trim().ToLower().Equals("anulado")).ESTADO_ID;

                overview.Authorizations = authorizations;

                overview.PendingAuthorizations = authorizations.Where(a => a.ID_ESTADO == pendingId).ToList();
                overview.AuthorizedAuthorizations = authorizations.Where(a => a.ID_ESTADO == authorizedId).ToList();
                overview.ExecutedAuthorizations = authorizations.Where(a => a.ID_ESTADO == executedId).ToList();
                overview.FinishedAuthorizations = authorizations.Where(a => a.ID_ESTADO == finishedId).ToList();
                overview.RejectedAuthorizations = authorizations.Where(a => a.ID_ESTADO == rejectedId).ToList();
                overview.CanceledAuthorizations = authorizations.Where(a => a.ID_ESTADO == canceledId).ToList();

                overview.LISTA_DE_ESTADOS = this._mapper.Map<List<AuthorizationStateVM>>(states);
                overview.LISTA_DE_MOTIVOS = this._mapper.Map<List<AuthorizationMotiveVM>>(this._unitOfWork.AuthorizationMotive.Get().ToList());
            }
            return overview;
        }

        public AuthorizationStateManagement SelectAuthorization(decimal id)
        {
            this._authorization = this._unitOfWork.Authorizations.GetById(id);
            this.Authorization = this._mapper.Map<AuthorizationVM>(this._authorization);
            this.Authorization.LISTA_DE_MOTIVOS = this._mapper.Map<List<AuthorizationMotiveVM>>(this._unitOfWork.AuthorizationMotive.Get().ToList());
            this.Authorization.LISTA_DE_ESTADOS = this._mapper.Map<List<AuthorizationStateVM>>(this._unitOfWork.AuthorizationStatus.Get().ToList());
            this.Authorization.LISTA_DE_MOVIMIENTOS = this._mapper.Map<List<AuthorizationMovementVM>>(this._unitOfWork.MovementAuthorizations.Get(m => m.ID_AUTORIZACION == id).ToList());
            this.Authorization.ESTADO = this.Authorization.LISTA_DE_ESTADOS.Find(s => s.ESTADO_ID.Equals(this.Authorization.ID_ESTADO));
            var idList = this.Authorization.LISTA_DE_MOVIMIENTOS.Select(m => m.ID_ESTADO).ToList();
            this.Authorization.LISTA_DE_ESTADOS_PROPIO = this._mapper.Map<List<AuthorizationStateVM>>(this._unitOfWork.AuthorizationStatus.Get(e => idList.Contains(e.ESTADO_ID)).ToList());

            this.Authorization.OWNERUSER = this._unitOfWork.AttendanceRepository.Get(a => a.id_personal == this.Authorization.USUARIO_CREA)
                .Select(u => {
                    var user = new PersonalVM();
                    user.cod_personal = u.id_personal;
                    user.nombre = u.nombres;
                    return user;
                }).First();

            return this;
        }

        public AuthorizationStateManagement SelectAuthorization(AuthorizationVM authorization)
        {
            this.Authorization = authorization;
            var authorizationEntity = this._unitOfWork.Authorizations.GetById(authorization.AUTORIZACION_ID);

            if (!Nullable.Equals(authorizationEntity, null))
                this._authorization = this._mapper.Map<IT_AUTORIZACION>(authorization);

            return this;
        }

        public void SetAuthorization(IT_AUTORIZACION authorization)
        {
            this._authorization = authorization;
            this.Authorization = this._mapper.Map<AuthorizationVM>(this._authorization);
        }

        public AuthorizationStateManagement IncludeMotivesListAndStatesList()
        {
            this.Authorization.LISTA_DE_MOTIVOS = this._mapper.Map<List<AuthorizationMotiveVM>>(this._unitOfWork.AuthorizationMotive.Get().ToList());
            this.Authorization.LISTA_DE_ESTADOS = this._mapper.Map<List<AuthorizationStateVM>>(this._unitOfWork.AuthorizationStatus.Get().ToList());
            return this;
        }

        public AuthorizationStateManagement IncludeOwnMovementsListAndStatesList()
        {
            this.Authorization.ESTADO = this._mapper.Map<AuthorizationStateVM>(this._authorization.IT_ESTADO_AUTORIZACION);
            var movementList = this._mapper.Map<List<AuthorizationMovementVM>>(this._unitOfWork.MovementAuthorizations.Get(m => m.ID_AUTORIZACION == this.Authorization.AUTORIZACION_ID).ToList());
            this.Authorization.LISTA_DE_MOVIMIENTOS = movementList;
            var idList = movementList.Select(m => m.ID_ESTADO).ToList();
            var ownStateList = this._unitOfWork.AuthorizationStatus.Get(e => idList.Contains(e.ESTADO_ID)).ToList();
            this.Authorization.LISTA_DE_ESTADOS_PROPIO = this._mapper.Map<List<AuthorizationStateVM>>(ownStateList);

            return this;
        }

        public AuthorizationStateManagement SwitchToPending()
        {
            SwitchTo("pendiente");
            return this;
        }

        public AuthorizationStateManagement SwitchToAuthorized()
        {
            SwitchTo("autorizado");
            return this;
        }

        public AuthorizationStateManagement SwitchToExecuted(DateTime exitTime)
        {
            SwitchTo("ejecutado", exitTime);
            return this;
        }

        public AuthorizationStateManagement SwitchToFinished(DateTime? returnTime = null)
        {
            SwitchTo("finalizado", returnTime);
            return this;
        }

        public AuthorizationStateManagement SwitchToRejected()
        {
            SwitchTo("rechazado");
            return this;
        }

        public AuthorizationStateManagement SwitchToCanceled()
        {
            SwitchTo("anulado");
            return this;
        }

        public void SwitchTo(string action, DateTime? time = null)
        {
            var state = this._unitOfWork.AuthorizationStatus.Get().ToList().Find(a => a.NOMBRE_ESTADO.Trim().ToLower().Equals(action));

            if (Nullable.Equals(this._authorization, null))
            {
                this._authorization = this._mapper.Map<IT_AUTORIZACION>(this.Authorization);
                this._authorization.ID_ESTADO = state.ESTADO_ID;
                this._authorization.FECHA_CREACION = this._authorization.FECHA_ULTIMO_ESTADO = DateTime.Now;
                if(string.IsNullOrEmpty(this.Authorization.FECHA_RETORNO_PROG) || string.IsNullOrEmpty(this.Authorization.HORA_RETORNO_PROG)) this._authorization.RETORNO = "NO";
                this._unitOfWork.Authorizations.Add(this._authorization);
                this._unitOfWork.Commit();
                var nuevo = this._unitOfWork.Authorizations.Get().ToList();
            }
            else
            {
                if (!this._authorization.HORA_SALIDA.HasValue)
                {
                    this._authorization.HORA_SALIDA = time;
                    this._authorization.HORA_SALIDA_SEGURIDAD = time;
                }
                else
                {
                    this._authorization.HORA_RETORNO = time;
                    this._authorization.HORA_RETORNO_SEGURIDAD = time;
                }

                this._authorization.ID_ESTADO = state.ESTADO_ID;
                this._authorization.FECHA_ULTIMO_ESTADO = DateTime.Now;
                if (state.NOMBRE_ESTADO.Trim().ToLower().Equals("autorizado"))
                    this._authorization.USUARIO_AUTORIZA = "PES-002345";
                this._unitOfWork.Authorizations.Update(this._authorization);
            }

            var movements = this._mapper.Map<IT_AUTORIZACION_MOVIMIENTOS>(this._authorization);
            this._unitOfWork.MovementAuthorizations.Add(movements);
            var auto_audi = GetAuthorizationAuditory();

            if(state.NOMBRE_ESTADO.ToLower().Equals("pendiente"))
                auto_audi.TIPO_MOVIMIENTO = "CREACION";
            else
                auto_audi.TIPO_MOVIMIENTO = "CAMBIO DE ESTADO";

            auto_audi.FECHA_MOVIMIENTO = DateTime.Now;
            this._unitOfWork.AuthorizationAuditory.Add(auto_audi);
            this._unitOfWork.Commit();
            SelectAuthorization(this._authorization.AUTORIZACION_ID);
        }

        public IT_AUTORIZACION_AUDITORIA GetAuthorizationAuditory()
        {
            return this._mapper.Map<IT_AUTORIZACION_AUDITORIA>(this._authorization);
        }
    }
}
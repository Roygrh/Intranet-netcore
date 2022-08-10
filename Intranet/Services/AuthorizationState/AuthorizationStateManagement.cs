using AutoMapper;
using Intranet.Models;
using Intranet.Services.Unit;
using Intranet.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Intranet.Services.AuthorizationState
{
    public class AuthorizationStateManagement
    {
        public AuthorizationVM Authorization;
        private IUnitOfWork _unitOfWork;
        private IT_AUTORIZACION _authorization;
        private IMapper _mapper;
        public AuthorizationStateManagement(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
        }

        public AuthorizationVM CreateNewAuthorization()
        {
            var authorization = new AuthorizationVM();
            authorization.LISTA_DE_ESTADOS = this._mapper.Map<List<AuthorizationStateVM>>(this._unitOfWork.AuthorizationStatus.Get().ToList());
            var list = new List<FunctionalAreaVM> { new FunctionalAreaVM { AREA_FUNCIONAL_ID = 0, NOMBRE_AREA_FUNCIONAL = "-- Seleccionar Área --" } };
            list.AddRange(this._mapper.Map<List<FunctionalAreaVM>>(this._unitOfWork.FunctionalAreas.Get().ToList()));
            authorization.LISTA_AREAS_FUNCIONALES = list;
            authorization.ESTADO = new AuthorizationStateVM();
            authorization.ESTADO.NOMBRE_ESTADO = "SIN SOLICITAR";
            authorization.RETORNO = "SI";
            var movements = this._unitOfWork.MovementAuthorizations.Get().ToList();
            return authorization;
        }
        public List<AuthorizationVM> GetAuthorizationPaging(DateTime? start, DateTime? end, string phrase = "", int page = 0, int size = -1)
        {
            var users = this._mapper.Map<List<UserVM>>(this._unitOfWork.ActiveDirectoryUsers.Get(p => p.Display_Name.Contains(phrase) || p.DNI.Contains(phrase)).ToList());
            var userIds = users.Select(p => p.DNI).ToList();

            var authos = this._mapper.Map<List<AuthorizationVM>>(this._unitOfWork.Authorizations.Get(
                a => userIds.Contains(a.USUARIO_CREA) && start.Value <= a.FECHA_CREACION.Value && a.FECHA_CREACION.Value <= end.Value,
                q => q.OrderByDescending(au => au.FECHA_CREACION),
                page, size));

            authos.ForEach(a => {
                a.OWNERUSER = users.Find(u => u.DNI.Trim().Equals(a.USUARIO_CREA));
            });
            return authos;
        }

        public OverviewVM GetOverviewListbyUserforStates(DateTime? start, DateTime? end, string userId = null, string phrase = null, int page = 1, int? size = 5)
        {
            OverviewVM overview = new OverviewVM();
            overview.ID_USUARIO = userId;
            if (start.HasValue && end.HasValue)
            {
                List<AuthorizationVM> authorizations = this._mapper.Map<List<AuthorizationVM>>(this._unitOfWork.StoredProcedures.Sp_Commissions(userId, phrase, start, end, size, page));

                int total = this._unitOfWork.StoredProcedures.Sp_Commissions(userId, phrase, start, end, null, 1).Count();
                overview.TotalPages = total % size.Value == 0 ? total / size.Value : (total / size.Value) + 1;
                overview.CurrentPage = page;

                if (string.IsNullOrWhiteSpace(userId))
                {
                    var users = this._mapper.Map<List<UserVM>>(this._unitOfWork.ActiveDirectoryUsers.Get(a => !string.IsNullOrEmpty(a.DNI)).Distinct().ToList());
                    authorizations.ForEach(a => {
                        a.OWNERUSER = users.Find(u => u.DNI.Trim().Equals(a.USUARIO_CREA));
                    });
                }

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
            }
            return overview;
        }

        public AuthorizationStateManagement SelectAuthorization(decimal id)
        {
            this._authorization = this._unitOfWork.Authorizations.GetById(id);
            this.Authorization = this._mapper.Map<AuthorizationVM>(this._authorization);
            this.Authorization.NOMBRE_AREA_FUNCIONAL = this._unitOfWork.FunctionalAreas.GetById(this.Authorization.ID_AREA_FUNCIONAL).NOMBRE_AREA_FUNCIONAL;
            IncludeStatesList();
            IncludeFunctionalAreas();
            IncludeOwnMovementsListAndStatesList();

            this.Authorization.OWNERUSER = this._unitOfWork.ActiveDirectoryUsers.Get(a => a.DNI == this.Authorization.USUARIO_CREA)
                .Select(u => {
                    var user = new UserVM();
                    user.DNI = u.DNI;
                    user.UserFullName = u.Display_Name;
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

        public IT_AUTORIZACION GetAuthorization()
        {
            return this._authorization;
        }

        public AuthorizationStateManagement IncludeStatesList()
        {
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

        public AuthorizationStateManagement IncludeFunctionalAreas()
        {
            var list = new List<FunctionalAreaVM> { new FunctionalAreaVM { AREA_FUNCIONAL_ID = 0, NOMBRE_AREA_FUNCIONAL = "-- Seleccionar Área --" } };
            list.AddRange(this._mapper.Map<List<FunctionalAreaVM>>(this._unitOfWork.FunctionalAreas.Get().ToList()));
            this.Authorization.LISTA_AREAS_FUNCIONALES = list;

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
                if (string.IsNullOrEmpty(this.Authorization.FECHA_RETORNO_PROG)) this._authorization.RETORNO = "NO";
                this._unitOfWork.Authorizations.Add(this._authorization);
                this._unitOfWork.Commit();
                var nuevo = this._unitOfWork.Authorizations.Get().ToList();
            }
            else
            {
                if (!this._authorization.HORA_SALIDA.HasValue && state.NOMBRE_ESTADO.Trim().ToLower().Equals("ejecutado"))
                {
                    this._authorization.HORA_SALIDA = time;
                    this._authorization.HORA_SALIDA_SEGURIDAD = time;
                }
                else if (state.NOMBRE_ESTADO.Trim().ToLower().Equals("finalizado"))
                {
                    this._authorization.HORA_RETORNO = time;
                    this._authorization.HORA_RETORNO_SEGURIDAD = time;
                }

                this._authorization.ID_ESTADO = state.ESTADO_ID;
                this._authorization.FECHA_ULTIMO_ESTADO = DateTime.Now;
                if (state.NOMBRE_ESTADO.Trim().ToLower().Equals("autorizado"))
                    this._authorization.USUARIO_AUTORIZA = "10506225";
                this._unitOfWork.Authorizations.Update(this._authorization);
            }

            var movements = this._mapper.Map<IT_AUTORIZACION_MOVIMIENTOS>(this._authorization);
            this._unitOfWork.MovementAuthorizations.Add(movements);
            var auto_audi = GetAuthorizationAuditory();

            if (state.NOMBRE_ESTADO.ToLower().Equals("pendiente"))
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

        public void ValidateDialing()
        {
            while (true)
            {
                DateTime today = DateTime.Now;
                var status = this._unitOfWork.AuthorizationStatus.Get().ToList();
                var authorizedStatus = status.Where(s => s.NOMBRE_ESTADO.ToLower().Equals("autorizado")).First();
                var executedStatus = status.Where(s => s.NOMBRE_ESTADO.ToLower().Equals("ejecutado")).First();
                var dayMarkings = this._unitOfWork.AttendanceRepository.Get(a => a.fecha.Value.Year == today.Year && a.fecha.Value.DayOfYear == today.DayOfYear).ToList();

                dayMarkings.ForEach(autho => {

                    var dayAuthorizedCommissions = this._unitOfWork.Authorizations.Get(a => a.ID_ESTADO == authorizedStatus.ESTADO_ID && a.FECHA_SALIDA_PROG.Value.Day == today.Day).ToList();
                    var dayExecutedCommissions = this._unitOfWork.Authorizations.Get(a => a.ID_ESTADO == executedStatus.ESTADO_ID && a.FECHA_SALIDA_PROG.Value.Day == today.Day).ToList();

                    if (dayAuthorizedCommissions.Select(d => d.USUARIO_CREA).Contains(autho.id_personal) && autho.hora_salida != null)
                    {
                        var authorizedComission = dayAuthorizedCommissions.Find(a => a.USUARIO_CREA.Trim().Equals(autho.id_personal.Trim()));
                        this._authorization = authorizedComission;
                        SwitchTo("ejecutado", autho.hora_salida);
                    }

                    /*if (dayExecutedCommissions.Select(d => d.USUARIO_CREA).Contains(autho.id_personal) && autho.hora_salida == null)
                    {
                        var executedComission = dayAuthorizedCommissions.Find(a => a.USUARIO_CREA.Trim().Equals(autho.id_personal.Trim()));
                        executedComission.HORA_RETORNO = autho.hora_ingreso;

                        this._unitOfWork.Authorizations.Update(executedComission);
                    }*/
                });
                Thread.Sleep(5000);
            }
        }

        public void run()
        {
            Thread thread = new Thread(new ThreadStart(this.ValidateDialing));
            thread.Start();
        }
    }
}
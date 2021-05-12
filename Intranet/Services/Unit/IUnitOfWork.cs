using Intranet.Models;
using Intranet.Models.Sicon;
using Intranet.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.Services.Unit
{
    public interface IUnitOfWork
    {
        IRepository<IT_CONTENIDO_GENERAL> Contents { get; }
        IRepository<IT_TIPO_CONTENIDO> ContentTypes { get; }
        IRepository<IT_AUTORIZACION> Authorizations { get; }
        IRepository<IT_AREA_FUNCIONAL> FunctionalAreas { get; }
        IRepository<IT_AUTORIZACION_MOVIMIENTOS> MovementAuthorizations { get; }
        IRepository<IT_ESTADO_AUTORIZACION> AuthorizationStatus { get; }
        IRepository<IT_CONTENIDO_GENERAL_AUDITORIA> ContentsAuditory { get; }
        IRepository<IT_AUTORIZACION_AUDITORIA> AuthorizationAuditory { get; }
        IRepository<IT_ACTIVE_DIRECTORY_USER> ActiveDirectoryUsers { get; }
        IRepository<IT_USER_TYPE> UserTypes { get; }
        IStoredProcedureRepository StoredProcedures { get; }

        IRepository<ca_personal> PersonalRepository { get; }
        IRepository<intranet_asistencia> AttendanceRepository { get; }
        IRepository<intranet_vacaciones> VacationsRepository { get; }

        void Commit();
        void RollBack();
    }
}

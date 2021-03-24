using Intranet.Models;
using Intranet.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.Services.Unit
{
    interface IUnitOfWork
    {
        IRepository<IT_CONTENIDO_GENERAL> Contents { get; }
        IRepository<IT_TIPO_CONTENIDO> ContentTypes { get; }
        IRepository<IT_AUTORIZACION> Authorizations { get; }
        IRepository<IT_AUTORIZACION_MOVIMIENTOS> MovementAuthorizations { get; }
        IRepository<IT_ESTADO_AUTORIZACION> AuthorizationStatus { get; }
        IRepository<IT_MOTIVO_AUTORIZACION> AuthorizationMotive { get; }
        IRepository<IT_CONTENIDO_GENERAL_AUDITORIA> ContentsAuditory { get; }
        IRepository<IT_AUTORIZACION_AUDITORIA> AuthorizationAuditory { get; }
        void Commit();
        void RollBack();
    }
}

using Intranet.Data;
using Intranet.Models;
using Intranet.Models.Sicon;
using Intranet.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.Services.Unit
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ApplicationDbContext _context;
        private ApplicationSiconDbContext _siconContext;
        private GenericRepository<IT_CONTENIDO_GENERAL> ContentRepository;
        private GenericRepository<IT_TIPO_CONTENIDO> ContentTypeRepository;
        private GenericRepository<IT_AUTORIZACION> AuthorizationRepository;
        private GenericRepository<IT_AREA_FUNCIONAL> FunctionalAreasRepository;
        private GenericRepository<IT_AUTORIZACION_MOVIMIENTOS> MovementAuthorizationRepository;
        private GenericRepository<IT_ESTADO_AUTORIZACION> AuthorizationStatusRepository;
        private GenericRepository<IT_CONTENIDO_GENERAL_AUDITORIA> ContentAuditoryRepository;
        private GenericRepository<IT_AUTORIZACION_AUDITORIA> AuthorizationAuditoryRepository;
        private SiconGenericRepository<ca_personal> PersonalRepository;
        private SiconGenericRepository<intranet_asistencia> AttendanceRepository;
        private SiconGenericRepository<intranet_vacaciones> VacationsRepository;

        public UnitOfWork(ApplicationDbContext context, ApplicationSiconDbContext siconContext)
        {
            this._context = context;
            this._siconContext = siconContext;
        }

        IRepository<IT_CONTENIDO_GENERAL> IUnitOfWork.Contents
        {
            get
            {

                if (this.ContentRepository == null)
                {
                    this.ContentRepository = new GenericRepository<IT_CONTENIDO_GENERAL>(_context);
                }
                return ContentRepository;
            }
        }

        IRepository<IT_TIPO_CONTENIDO> IUnitOfWork.ContentTypes
        {
            get
            {

                if (this.ContentTypeRepository == null)
                {
                    this.ContentTypeRepository = new GenericRepository<IT_TIPO_CONTENIDO>(_context);
                }
                return ContentTypeRepository;
            }
        }

        IRepository<IT_AUTORIZACION> IUnitOfWork.Authorizations
        {
            get
            {

                if (this.AuthorizationRepository == null)
                {
                    this.AuthorizationRepository = new GenericRepository<IT_AUTORIZACION>(_context);
                }
                return AuthorizationRepository;
            }
        }

        IRepository<IT_AREA_FUNCIONAL> IUnitOfWork.FunctionalAreas
        {
            get
            {

                if (this.FunctionalAreasRepository == null)
                {
                    this.FunctionalAreasRepository = new GenericRepository<IT_AREA_FUNCIONAL>(_context);
                }
                return FunctionalAreasRepository;
            }
        }

        IRepository<IT_AUTORIZACION_MOVIMIENTOS> IUnitOfWork.MovementAuthorizations
        {
            get
            {

                if (this.MovementAuthorizationRepository == null)
                {
                    this.MovementAuthorizationRepository = new GenericRepository<IT_AUTORIZACION_MOVIMIENTOS>(_context);
                }
                return MovementAuthorizationRepository;
            }
        }

        IRepository<IT_ESTADO_AUTORIZACION> IUnitOfWork.AuthorizationStatus
        {
            get
            {

                if (this.AuthorizationStatusRepository == null)
                {
                    this.AuthorizationStatusRepository = new GenericRepository<IT_ESTADO_AUTORIZACION>(_context);
                }
                return AuthorizationStatusRepository;
            }
        }

        IRepository<IT_CONTENIDO_GENERAL_AUDITORIA> IUnitOfWork.ContentsAuditory
        {
            get
            {

                if (this.ContentAuditoryRepository == null)
                {
                    this.ContentAuditoryRepository = new GenericRepository<IT_CONTENIDO_GENERAL_AUDITORIA>(_context);
                }
                return ContentAuditoryRepository;
            }
        }

        IRepository<IT_AUTORIZACION_AUDITORIA> IUnitOfWork.AuthorizationAuditory
        {
            get
            {

                if (this.AuthorizationAuditoryRepository == null)
                {
                    this.AuthorizationAuditoryRepository = new GenericRepository<IT_AUTORIZACION_AUDITORIA>(_context);
                }
                return AuthorizationAuditoryRepository;
            }
        }

        IRepository<ca_personal> IUnitOfWork.PersonalRepository
        {
            get
            {

                if (this.PersonalRepository == null)
                {
                    this.PersonalRepository = new SiconGenericRepository<ca_personal>(_siconContext);
                }
                return PersonalRepository;
            }
        }

        IRepository<intranet_asistencia> IUnitOfWork.AttendanceRepository
        {
            get
            {

                if (this.AttendanceRepository == null)
                {
                    this.AttendanceRepository = new SiconGenericRepository<intranet_asistencia>(_siconContext);
                }
                return AttendanceRepository;
            }
        }

        IRepository<intranet_vacaciones> IUnitOfWork.VacationsRepository
        {
            get
            {

                if (this.VacationsRepository == null)
                {
                    this.VacationsRepository = new SiconGenericRepository<intranet_vacaciones>(_siconContext);
                }
                return VacationsRepository;
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void RollBack()
        {
            //TODO
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

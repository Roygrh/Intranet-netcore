using Intranet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<IT_CONTENIDO_GENERAL> IT_CONTENIDO_GENERAL { get; set; }
        public DbSet<IT_TIPO_CONTENIDO> IT_TIPO_CONTENIDO { get; set; }
        public DbSet<IT_AUTORIZACION> IT_AUTORIZACION { get; set; }
        public DbSet<IT_MOTIVO_AUTORIZACION> IT_MOTIVO_AUTORIZACION { get; set; }
        public DbSet<IT_ESTADO_AUTORIZACION> IT_ESTADO_AUTORIZACION { get; set; }
        public DbSet<IT_AUTORIZACION_MOVIMIENTOS> IT_AUTORIZACION_MOVIMIENTOS { get; set; }
        public DbSet<IT_CONTENIDO_GENERAL_AUDITORIA> IT_CONTENIDO_GENERAL_AUDITORIA { get; set; }
        public DbSet<IT_AUTORIZACION_AUDITORIA> IT_AUTORIZACION_AUDITORIA { get; set; }
        //public DbSet<IT_MOTIVO_AUTORIZACION_AUDITOR> IT_MOTIVO_AUTORIZACION_AUDITOR { get; set; }
    }
}

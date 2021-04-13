using Intranet.Models.Sicon;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.Data
{
    public class ApplicationSiconDbContext : DbContext
    {
        public ApplicationSiconDbContext(DbContextOptions<ApplicationSiconDbContext> options) : base(options)
        {

        }

        public DbSet<ca_personal> ca_personal { get; set; }
        public DbSet<intranet_asistencia> intranet_asistencia { get; set; }
        public DbSet<intranet_vacaciones> intranet_vacaciones { get; set; }
    }
}

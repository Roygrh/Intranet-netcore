using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.Models.Sicon
{
    public class intranet_asistencia
    {
        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column("item", TypeName = "int")]
        public int item { get; set; }
        public string id_personal { get; set; }
        public string nombres { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public string tipo_trabj { get; set; }
        public Nullable<System.DateTime> hora_ingreso { get; set; }
        public Nullable<System.DateTime> hora_salida { get; set; }
        public string observacion { get; set; }
    }
}

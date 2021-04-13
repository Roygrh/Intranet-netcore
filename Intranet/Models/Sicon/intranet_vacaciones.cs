using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.Models.Sicon
{
    public class intranet_vacaciones
    {
        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column("item", TypeName = "int")]
        public int item { get; set; }
        public string id_personal { get; set; }
        public string nombres { get; set; }
        public Nullable<System.DateTime> fecha_inicio { get; set; }
        public Nullable<System.DateTime> fecha_termino { get; set; }
        public Nullable<int> nro_dias { get; set; }
        public string situacion { get; set; }
        public string documento { get; set; }
        public Nullable<int> rec_sicon { get; set; }
        public Nullable<System.DateTime> fecha_update { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.ViewModels
{
    public class AttendanceVM
    {
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

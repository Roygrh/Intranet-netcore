using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.Models
{
    public class IT_ESTADO_AUTORIZACION
    {
        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column("ESTADO_ID", TypeName = "numeric(6,0)")]
        public decimal ESTADO_ID { get; set; }
        public string NOMBRE_ESTADO { get; set; }
        public string USUARIO_CREA { get; set; }
        public Nullable<System.DateTime> FECHA_CREACION { get; set; }
        public string USUARIO_EDITA { get; set; }
        public Nullable<System.DateTime> FECHA_EDICION { get; set; }
    }
}

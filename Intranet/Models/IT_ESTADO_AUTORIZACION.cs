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
        [Column(TypeName = "numeric(4,0)")]
        public Nullable<decimal> USUARIO_INGRESA { get; set; }
        public Nullable<System.DateTime> FECHA_INGRESA { get; set; }
        [Column(TypeName = "numeric(4,0)")]
        public Nullable<decimal> USUARIO_MODIFICA { get; set; }
        public Nullable<System.DateTime> FECHA_MODIFICA { get; set; }
    }
}

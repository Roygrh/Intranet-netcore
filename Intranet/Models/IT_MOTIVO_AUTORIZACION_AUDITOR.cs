using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.Models
{
    public class IT_MOTIVO_AUTORIZACION_AUDITOR
    {
        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column("MOTIVO_AUTORIZACION_AUDITOR_ID", TypeName = "numeric(6,0)")]
        public decimal MOTIVO_AUTORIZACION_AUDITOR_ID { get; set; }
        [Column(TypeName = "numeric(6,0)")]
        public Nullable<decimal> MOTIVO_AUTORIZACION_ID { get; set; }
        public string NOMBRE_MOTIVO { get; set; }
        public System.DateTime FECHA_MOVIMIENTO { get; set; }
        public string TIPO_MOVIMIENTO { get; set; }
        [Column(TypeName = "numeric(4,0)")]
        public Nullable<decimal> USUARIO_INGRESA { get; set; }
        public Nullable<System.DateTime> FECHA_INGRESA { get; set; }
        [Column(TypeName = "numeric(4,0)")]
        public Nullable<decimal> USUARIO_MODIFICA { get; set; }
        public Nullable<System.DateTime> FECHA_MODIFICA { get; set; }

    }
}

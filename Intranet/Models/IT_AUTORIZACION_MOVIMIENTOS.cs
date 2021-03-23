using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.Models
{
    public class IT_AUTORIZACION_MOVIMIENTOS
    {
        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column("MOVIMIENTO_ID", TypeName = "numeric(6,0)")]
        public decimal MOVIMIENTO_ID { get; set; }
        [Column(TypeName = "numeric(6,0)")]
        public decimal ID_AUTORIZACION { get; set; }
        [Column(TypeName = "numeric(6,0)")]
        public decimal ID_ESTADO { get; set; }
        public string USUARIO_CREA { get; set; }
        public System.DateTime FECHA_CREACION { get; set; }
        [Column(TypeName = "numeric(6,0)")]
        public decimal ID_MOTIVO { get; set; }
        [Column(TypeName = "numeric(6,0)")]
        public Nullable<decimal> ID_AREA_FUNCIONAL { get; set; }
        public string ID_USUARIO_AUTORIZA { get; set; }
        [Column(TypeName = "numeric(6,0)")]
        public Nullable<decimal> ID_TIPO_USUARIO { get; set; }
        [Column(TypeName = "numeric(4,0)")]
        public Nullable<decimal> USUARIO_INGRESA { get; set; }
        public Nullable<System.DateTime> FECHA_INGRESA { get; set; }
        [Column(TypeName = "numeric(4,0)")]
        public Nullable<decimal> USUARIO_MODIFICA { get; set; }
        public Nullable<System.DateTime> FECHA_MODIFICA { get; set; }

        [ForeignKey("ID_AUTORIZACION")]
        public virtual IT_AUTORIZACION IT_AUTORIZACION { get; set; }
        //[ForeignKey("ID_MOTIVO")]
        //public virtual IT_MOTIVO_AUTORIZACION IT_MOTIVO_AUTORIZACION { get; set; }
        //[ForeignKey("ID_ESTADO")]
        //public virtual IT_ESTADO_AUTORIZACION IT_ESTADO_AUTORIZACION { get; set; }
    }
}

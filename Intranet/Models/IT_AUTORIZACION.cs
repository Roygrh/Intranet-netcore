using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.Models
{
    public class IT_AUTORIZACION
    {
        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column("AUTORIZACION_ID", TypeName = "numeric(6,0)")]
        public decimal AUTORIZACION_ID { get; set; }
        [Column(TypeName = "numeric(6,0)")]
        public Nullable<decimal> ID_AREA_FUNCIONAL { get; set; }
        public string MOTIVO { get; set; }
        public string RETORNO { get; set; }
        public Nullable<System.DateTime> HORA_SALIDA { get; set; }
        public Nullable<System.DateTime> HORA_RETORNO { get; set; }
        public Nullable<System.DateTime> HORA_SALIDA_SEGURIDAD { get; set; }
        public Nullable<System.DateTime> HORA_RETORNO_SEGURIDAD { get; set; }
        public string USUARIO_AUTORIZA { get; set; }
        [Column(TypeName = "numeric(6,0)")]
        public Nullable<decimal> ID_TIPO_USUARIO { get; set; }
        [Column(TypeName = "numeric(6,0)")]
        public decimal ID_ESTADO { get; set; }
        public string DESCRIPCION { get; set; }
        public Nullable<System.DateTime> FECHA_ULTIMO_ESTADO { get; set; }
        public Nullable<System.DateTime> FECHA_SALIDA_PROG { get; set; }
        public Nullable<System.DateTime> FECHA_RETORNO_PROG { get; set; }
        public string NOMBRE_ARCHIVO { get; set; }
        public string TIPO_CONTENIDO_FILE { get; set; }
        public byte[] FILE { get; set; }
        public string USUARIO_CREA { get; set; }
        public string USARIO_CREA_NOMBRE { get; set; }
        public Nullable<System.DateTime> FECHA_CREACION { get; set; }
        public string USUARIO_EDITA { get; set; }
        public Nullable<System.DateTime> FECHA_EDICION { get; set; }


        [ForeignKey("ID_ESTADO")]
        public virtual IT_ESTADO_AUTORIZACION IT_ESTADO_AUTORIZACION { get; set; }
    }
}

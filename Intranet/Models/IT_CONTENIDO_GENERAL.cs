using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.Models
{
    public class IT_CONTENIDO_GENERAL
    {
        [Key,DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column("CONTENIDO_ID", TypeName = "numeric(6,0)")]
        public decimal CONTENIDO_ID { get; set; }
        public string NOMBRE_CONTENIDO { get; set; }
        public string DESCRIPCION_CONTENIDO { get; set; }
        [Column(TypeName = "numeric(6,0)")]
        public decimal TIPO_CONTENIDO_ID { get; set; }
        public string NOMBRE_ARCHIVO { get; set; }
        public string UBICACION_ARCHIVO { get; set; }
        [Column(TypeName = "numeric(6,0)")]
        public Nullable<decimal> ID_AREA_FUNCIONAL { get; set; }
        public string USUARIO_CREA { get; set; }
        public string USUARIO_EDITA { get; set; }
        public Nullable<System.DateTime> FECHA_CREACION { get; set; }
        public Nullable<System.DateTime> FECHA_EDICION { get; set; }
        public byte[] FILE { get; set; }
        public string TIPO_CONTENIDO_FILE { get; set; }
        [Column(TypeName = "numeric(4,0)")]
        public Nullable<decimal> USUARIO_INGRESA { get; set; }
        public Nullable<System.DateTime> FECHA_INGRESA { get; set; }
        [Column(TypeName = "numeric(4,0)")]
        public Nullable<decimal> USUARIO_MODIFICA { get; set; }
        public Nullable<System.DateTime> FECHA_MODIFICA { get; set; }

        [ForeignKey("TIPO_CONTENIDO_ID")]
        public virtual IT_TIPO_CONTENIDO IT_TIPO_CONTENIDO { get; set; }
    }
}

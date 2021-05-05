using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.ViewModels
{
    public class AuthorizationVM
    {
        public decimal AUTORIZACION_ID { get; set; }
        [Display(Name = "N° Formato")]
        public string USUARIO_CREA { get; set; }
        [Display(Name = "Nombre")]
        public string USARIO_CREA_NOMBRE { get; set; }
        public decimal ID_AREA_FUNCIONAL { get; set; }
        [Display(Name = "Area Funcional")]
        public string NOMBRE_AREA_FUNCIONAL { get; set; }
        [Display(Name = "Motivo")]
        public string MOTIVO { get; set; }
        [Display(Name = "Retorno")]
        public string RETORNO { get; set; }
        public Nullable<DateTime> FECHA_SALIDA_PROG_DATE_TIME { get; set; }
        public Nullable<DateTime> FECHA_RETORNO_PROG_DATE_TIME { get; set; }
        public Nullable<System.DateTime> HORA_SALIDA { get; set; }
        public Nullable<System.DateTime> HORA_RETORNO { get; set; }
        public Nullable<System.DateTime> HORA_SALIDA_SEGURIDAD { get; set; }
        public Nullable<System.DateTime> HORA_RETORNO_SEGURIDAD { get; set; }
        public string USUARIO_AUTORIZA { get; set; }
        public Nullable<decimal> ID_TIPO_USUARIO { get; set; }
        [Display(Name = "Fecha de registro")]
        [DisplayFormat(DataFormatString = "{dd/MM/yy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public Nullable<DateTime> FECHA_CREACION { get; set; }
        public Nullable<System.DateTime> FECHA_EDICION { get; set; }
        public string USUARIO_EDITA { get; set; }
        public decimal ID_ESTADO { get; set; }
        [Display(Name = "Descripción")]
        public string DESCRIPCION { get; set; }
        public Nullable<System.DateTime> FECHA_ULTIMO_ESTADO { get; set; }
        [Display(Name = "Fecha de salida")]
        public string FECHA_SALIDA_PROG { get; set; }
        [Display(Name = "Hora de salida")]
        public string HORA_SALIDA_PROG { get; set; }
        [Display(Name = "Fecha de retorno")]
        public string FECHA_RETORNO_PROG { get; set; }
        [Display(Name = "Hora de retorno")]
        public string HORA_RETORNO_PROG { get; set; }
        [Display(Name = "Unidad Orgánica")]
        public string UNIDAD_ORGANICA { get; set; }
        [Display(Name = "Archivo")]
        public IFormFile FILE { get; set; }
        [Display(Name = "Usuario")]
        public BasicUserInformationVM USER { get; set; }
        [Display(Name = "Usuario")]
        public PersonalVM OWNERUSER { get; set; }
        [Display(Name = "Usuario")]
        public PersonalVM AUTHORIZINGUSER { get; set; }
        [Display(Name = "Estado")]
        public AuthorizationStateVM ESTADO { get; set; }
        [Display(Name = "Lista de areas funcionales")]
        public List<FunctionalAreaVM> LISTA_AREAS_FUNCIONALES { get; set; }
        [Display(Name = "Lista de estados")]
        public List<AuthorizationStateVM> LISTA_DE_ESTADOS { get; set; }
        [Display(Name = "Lista de estados")]
        public List<AuthorizationStateVM> LISTA_DE_ESTADOS_PROPIO { get; set; }
        [Display(Name = "Lista de movimientos")]
        public List<AuthorizationMovementVM> LISTA_DE_MOVIMIENTOS { get; set; }
    }
}

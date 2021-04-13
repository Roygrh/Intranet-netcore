using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.ViewModels
{
    public class OverviewVM
    {
        public string ID_USUARIO { get; set; }
        public decimal ID_AREA_FUNCIONAL { get; set; }
        public Nullable<decimal> ID_TIPO_USUARIO { get; set; }
        [Display(Name = "Unidad Orgánica")]
        public string UNIDAD_ORGANICA { get; set; }
        [Display(Name = "Usuario")]
        public BasicUserInformationVM USER { get; set; }
        [Display(Name = "Autorizaciones pendientes")]
        public List<AuthorizationVM> PendingAuthorizations { get; set; }
        [Display(Name = "Autorizaciones autorizadas")]
        public List<AuthorizationVM> AuthorizedAuthorizations { get; set; }
        [Display(Name = "Autorizaciones ejecutadas")]
        public List<AuthorizationVM> ExecutedAuthorizations { get; set; }
        [Display(Name = "Autorizaciones finalizadas")]
        public List<AuthorizationVM> FinishedAuthorizations { get; set; }
        [Display(Name = "Autorizaciones rechazadas")]
        public List<AuthorizationVM> RejectedAuthorizations { get; set; }
        [Display(Name = "Autorizaciones canceladas")]
        public List<AuthorizationVM> CanceledAuthorizations { get; set; }

        public List<AuthorizationVM> Authorizations { get; set; }
        public AuthorizationVM Authorization { get; set; }

        [Display(Name = "Lista de estados")]
        public List<AuthorizationStateVM> LISTA_DE_ESTADOS { get; set; }
        [Display(Name = "Motivo de salida")]
        public List<AuthorizationMotiveVM> LISTA_DE_MOTIVOS { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.ViewModels
{
    public class AuthorizationMotiveVM
    {
        public decimal MOTIVO_ID { get; set; }
        [Display(Name = "Nombre del motivo")]
        public string NOMBRE_MOTIVO { get; set; }
        public bool IsSelected { get; set; }
    }
}

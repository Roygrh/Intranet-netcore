using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.ViewModels
{
    public class BasicUserInformationVM
    {
        [Display(Name = "N° Formato")]
        public string USUARIO_CREA { get; set; }
        [Display(Name = "Usuario")]
        public string USER_NAME { get; set; }
    }
}

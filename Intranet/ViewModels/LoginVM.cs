using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Usuario")]
        public string UserName { get; set; }
        [Display(Name = "Nombre")]
        public string UserFullName { get; set; }
        [Display(Name = "Correo electronico")]
        public string Email { get; set; }
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
        [Display(Name = "Recordarme?")]
        public bool RememberMe { get; set; }
    }
}

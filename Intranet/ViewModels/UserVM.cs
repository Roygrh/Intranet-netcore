using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.ViewModels
{
    public class UserVM
    {
        [Display(Name = "Usuario")]
        public string UserName { get; set; }
        [Display(Name = "Nombre")]
        public string UserFullName { get; set; }
        [Display(Name = "DNI")]
        public string DNI { get; set; }
        [Display(Name = "Correo electronico")]
        public string Email { get; set; }
        [Display(Name = "Tipo de usuario")]
        public decimal UserType { get; set; }
        [Display(Name = "Rol usuario")]
        public string UserTypeName { get; set; }
    }
}

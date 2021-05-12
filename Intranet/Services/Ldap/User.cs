using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.Services.Ldap
{
    public class User
    {
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string DNI { get; set; }
        public string Email { get; set; }
        public decimal UserType { get; set; }
        public string UserTypeName { get; set; }
    }
}
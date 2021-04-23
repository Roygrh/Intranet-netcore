using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.Services.Ldap
{
    public interface IAuthenticationService
    {
        User Login(string userName, string password);
    }
}

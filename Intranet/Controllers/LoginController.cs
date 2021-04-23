using Intranet.Services.Ldap;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Intranet.Controllers
{
    public class LoginController : Controller
    {
        private readonly Services.Ldap.IAuthenticationService _authService;

        public LoginController(Services.Ldap.IAuthenticationService authService)
        {
            this._authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(string userName, string password)
        {
            //var user = this._authService.Login(userName, password);
            var user = new User();
            user.DisplayName = "Jorge Enrique Quiroz Ñato";
            user.UserName = "jquiroz";
            if (null != user)
            {
                // create your login token here
                var userClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, user.DisplayName),
                    new Claim(ClaimTypes.Email, "jquiroz@imarpe.gob.pe"),
                    new Claim("UserName","jquiroz")
                };

                var licenseClaims = new List<Claim>()
                {
                    new Claim("userType","Administrador")
                };

                var userIdentity = new ClaimsIdentity(userClaims, "identidad de usuario");
                var licenseIdentity = new ClaimsIdentity(licenseClaims, "Gobierno");

                var userPrincipal = new ClaimsPrincipal(new[] {userIdentity, licenseIdentity});

                await HttpContext.SignInAsync(userPrincipal);

                return null;
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}

using Intranet.Services.Ldap;
using Intranet.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Intranet.Controllers
{
    public class AccountController : Controller
    {
        private readonly Services.Ldap.IAuthenticationService _authService;

        public AccountController(Services.Ldap.IAuthenticationService authService)
        {
            this._authService = authService;
        }

        public IActionResult Login()
        {
            var user = HttpContext.User;
            var b = user.Claims;
            var c = user.Identities;
            var d = user.Identity;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM login)
        {
            login.UserName = login.Email;
            login.Email = "jquiroz@imarpe.gob.pe";
            login.Password = "Imarpe2021$";
            var usern = this._authService.Login(login.UserName, login.Password);
            var user = new User();
            user.DisplayName = "Jorge Enrique Quiroz Ñato";
            if (null != user)
            {
                // create your login token here
                var userClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, user.DisplayName),
                    new Claim(ClaimTypes.Email, login.Email),
                    new Claim("UserName",login.UserName)
                };

                var licenseClaims = new List<Claim>()
                {
                    new Claim("userType","Administrador")
                };

                var userIdentity = new ClaimsIdentity(userClaims, "identidad de usuario");
                var licenseIdentity = new ClaimsIdentity(licenseClaims, "Gobierno");

                var userPrincipal = new ClaimsPrincipal(new[] { userIdentity, licenseIdentity });

                await HttpContext.SignInAsync(userPrincipal);

                return RedirectToAction("Index", "Authorization");
            }
            else
            {
                return Unauthorized();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

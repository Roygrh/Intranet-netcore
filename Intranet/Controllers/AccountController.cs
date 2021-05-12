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
            GetUserName(login);
            var user = this._authService.Login(login.UserName, login.Password);
            //user = FillUserData(user);

            if (null != user)
            {
                // create your login token here
                var userClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, user.DisplayName),
                    new Claim(ClaimTypes.Email, login.Email),
                    new Claim("UserName",user.UserName),
                    new Claim("DNI", user.DNI)
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

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction(nameof(Index), "Authorization");
        }

        [HttpPost]
        public IActionResult IsAuthenticated()
        {
            var user = HttpContext.User;
            UserVM result = null;
            if (user.Identity.IsAuthenticated)
            {
                result = new UserVM
                {
                    UserName = user.FindFirstValue("UserName"),
                    UserFullName = user.FindFirstValue(ClaimTypes.Name),
                    Email = user.FindFirstValue(ClaimTypes.Email)
                };
            }
            return Ok(result);
        }

        private void GetUserName(LoginVM login)
        {
            if (login.UserName.Contains("@imarpe.gob.pe"))
            {
                login.Email = login.UserName;
                login.UserName = login.UserName.Substring(0, login.UserName.IndexOf("@imarpe.gob.pe"));
            }
        }

        private User FillUserData(User user)
        {
            if (user == null)
            {
                return new User
                {
                    UserName = "jquiroz",
                    DisplayName = "Jorge Enrique Quiroz Ñato",
                    DNI = "46879788",
                    Email = "jquiroz@imarpe.gob.pe"
                };
            }
            else
            {
                return user;
            }
        }
    }
}

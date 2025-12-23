using TestApp.Application.Interfaces;
using TestApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using TestApp.Domain.Helpers;

namespace TestApp.Presentation.Controllers
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 01/02/2025
    /// Class: AccountController
    /// </summary>
    public class AccountController: Controller
    {

        public readonly IUsersServices _usersServices;        

        public AccountController(IUsersServices usersServices)
        {
            _usersServices = usersServices;            
        }        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(UsersModel userModel)
        {

            if (!ModelState.IsValid)
            {
                return View(userModel);
            }
            else
            {
                var user = _usersServices.Login(userModel.User, StringHelpers.sha256_hash(userModel.Password));

                if (user.Id > 0)
                {

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, String.Format("{0} {1}", user.Name, user.LastName)),
                        new Claim(ClaimTypes.Email, user.Email)
                    };

                    await SignIn(claims);

                    return RedirectToAction("Index", "Dashboard");

                }
                else
                {                    
                    ViewBag.Message = "Error en el login";
                    return View(userModel);
                }

            }
        }               

        public async Task<ActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login", "Account");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        private async Task SignIn(List<Claim> claims)
        {
            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
                IsPersistent = true,
                IssuedUtc = DateTimeOffset.UtcNow
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }        
    }
}

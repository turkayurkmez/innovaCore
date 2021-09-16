using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using miniShop.Business;
using miniShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace miniShop.Controllers
{
    public class UserController : Controller
    {
        private FakeUserService fakeUserService;

        public IActionResult Index()
        {
            return View();
        }

        public UserController(FakeUserService fakeUserService)
        {
            this.fakeUserService = fakeUserService;
        }
        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel userLogin, string returnUrl)
        {
            var user = fakeUserService.Validate(userLogin.UserName, userLogin.Password);
            if (user != null)
            {
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(ClaimTypes.Role,user.Role)
                };

                ClaimsIdentity identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(claimsPrincipal);
                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }       
                return Redirect("/");
            }

            ModelState.AddModelError("", "Kullanıcı adı ya da şifre hatalı!!!");
            return View();
         


        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MembershipAuthenticationWithDapperORM.Data;
using MembershipAuthenticationWithDapperORM.DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;


namespace MembershipAuthenticationWithDapperORM.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthRepo _repo;

        public AccountController(IAuthRepo repo)
        {
            _repo = repo;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserForLoginDTO userForLogin, string retunUrl="")
        {
            var validUser = _repo.Login(userForLogin.user_name, userForLogin.password);

            if (validUser == true)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userForLogin.user_name)
                };
                var claimsIdentity = new ClaimsIdentity(claims, "Login");
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                if (Url.IsLocalUrl(retunUrl))
                {
                    return Redirect(retunUrl);
                } else
                {
                    return RedirectToAction("Profile", "Home");
                }
            }
            ModelState.Remove("Password");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index","Home");
        }

    }
}

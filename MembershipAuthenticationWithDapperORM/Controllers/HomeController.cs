using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MembershipAuthenticationWithDapperORM.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;


namespace MembershipAuthenticationWithDapperORM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;

        }


        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(DapperORM.testQuerry<User>());
        }

        
        [Authorize]
        public IActionResult Profile()
        {
            var currentUser = User.FindFirst(ClaimTypes.NameIdentifier);
            return View(currentUser);
        }
       
    }
}

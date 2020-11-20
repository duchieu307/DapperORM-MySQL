using MembershipAuthenticationWithDapperORM.Data;
using MembershipAuthenticationWithDapperORM.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MembershipAuthenticationWithDapperORM.Controllers
{
    [Authorize]
    public class VehicleController : Controller
    {
        private readonly IVehicleRepo _repo;

        public VehicleController(IVehicleRepo repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/Account/Login");
            }
            return View(_repo.GetAllVehicle());
        }

        [HttpGet]
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View();
            } else
            {
                return View(_repo.GetVehicleById(id));
            }
        }

        [HttpPost]
        public IActionResult AddOrEdit(Vehicle vehicle)
        {
            _repo.AddOrEditVehicle(vehicle);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteVehicle(int id)
        {
            _repo.DeleteVehicle(id);

            return RedirectToAction("Index");

        }
    }
}

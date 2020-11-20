using MembershipAuthenticationWithDapperORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MembershipAuthenticationWithDapperORM.Data
{
    public interface IVehicleRepo
    {
        public IEnumerable<Vehicle> GetAllVehicle();

        public Vehicle GetVehicleById(int id);

        public void AddOrEditVehicle(Vehicle vehicle);

        public void DeleteVehicle(int id);

    }
}

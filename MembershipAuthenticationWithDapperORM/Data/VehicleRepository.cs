using Dapper;
using MembershipAuthenticationWithDapperORM.Helpers;
using MembershipAuthenticationWithDapperORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MembershipAuthenticationWithDapperORM.Data
{
    public class VehicleRepository : IVehicleRepo
    {
        public IEnumerable<Vehicle> GetAllVehicle()
        {
            var sql = "SELECT * FROM vehicle";

            var vehicleFromRepo = DapperORM.ExecuteReturnList<Vehicle>(sql, null);

            return vehicleFromRepo;
        }

        public Vehicle GetVehicleById(int id)
        {
            var sql = "SELECT * FROM vehicle WHERE id = @id";
            DynamicParameters param = new DynamicParameters();
            param.Add("@id", id);

            var vehicleFromRepo = DapperORM.ExecuteReturnOne<Vehicle>(sql, param);

            return vehicleFromRepo;
        }

        public void AddOrEditVehicle(Vehicle vehicle)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@id", vehicle.id);
            param.Add("@vehicle_type_id", vehicle.vehicle_type_id);
            param.Add("@brand", vehicle.brand);
            param.Add("@model", vehicle.model);
            param.Add("@license_number", vehicle.lincese_number);
            param.Add("@capacity", vehicle.capacity);
            param.Add("@supplier_id", vehicle.supplier_id);

            DapperORM.ExecuteProcedureWithNoReturn("AddOrEdit", param);
        }

        public void DeleteVehicle(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@id", id);
            var sql = "DELETE FROM vehicle WHERE id = @id ";

            DapperORM.ExecuteWithNoReturn(sql, param);
        }
    }
}

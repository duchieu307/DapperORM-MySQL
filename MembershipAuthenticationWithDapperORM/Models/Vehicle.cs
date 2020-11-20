using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MembershipAuthenticationWithDapperORM.Models
{
    public class Vehicle
    {
        public int id { get; set; }
        public int vehicle_type_id { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public string lincese_number { get; set; }
        public int capacity { get; set; }
        public int supplier_id { get; set; }
    }
}

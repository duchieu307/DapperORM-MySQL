using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MembershipAuthenticationWithDapperORM.Models
{
    public class User
    {
        public int id { get; set; }

        public int school_id { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }

        public int user_type_id { get; set; }
        public int profile_picture_id { get; set; }
        public  int is_active { get; set; }

        public DateTime created_at { get; set; }
        public DateTime expiry_date { get; set; }
        public int role_id { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }

        public string gender { get; set; }

        public DateTime birth_date { get; set; }

        public string identity_number { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public DateTime identity_issued_date { get; set; }

        public string address { get; set; }






    }
}

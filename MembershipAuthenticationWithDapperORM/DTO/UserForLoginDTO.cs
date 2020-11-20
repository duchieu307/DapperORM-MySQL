using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MembershipAuthenticationWithDapperORM.DTO
{
    public class UserForLoginDTO
    {
        public string user_name { get; set; }

        public string password { get; set; }
    }
}

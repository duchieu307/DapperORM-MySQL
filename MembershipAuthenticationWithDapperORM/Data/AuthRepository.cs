using Dapper;
using MembershipAuthenticationWithDapperORM.Helpers;
using MembershipAuthenticationWithDapperORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MembershipAuthenticationWithDapperORM.Data
{
    public class AuthRepository : IAuthRepo
    {
 

        public bool Login(string username, string password)
        {
            var sql = "SELECT * FROM user WHERE user_name = @user_name";
            DynamicParameters param = new DynamicParameters();
            param.Add("@user_name", username);

            var userFromRepo = DapperORM.ExecuteReturnOne<User>(sql, param);

            if (userFromRepo == null)
            {
                return false;
            }

            if (userFromRepo.password != password)
            {
                return false;
            }

            return true;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MembershipAuthenticationWithDapperORM.Data
{
    public interface IAuthRepo
    {
        public bool Login(string username, string password);
    }
}

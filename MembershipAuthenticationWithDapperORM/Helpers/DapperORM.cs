using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;

namespace MembershipAuthenticationWithDapperORM.Models
{
    public class DapperORM
    {
        private static string connectionString = "server=127.0.0.1;user=root;password=123456;database=edukite";

        public static IEnumerable<T> testQuerry<T>()
        {
            string sql = "SELECT * FROM user";

            using( MySqlConnection  sqlCon = new MySqlConnection(connectionString))
            {
                sqlCon.Open();
                var data = sqlCon.Query<T>(sql);
                return data;
            }
        }
    }


}

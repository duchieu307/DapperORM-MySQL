using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;

namespace MembershipAuthenticationWithDapperORM.Helpers
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

        public static void ExecuteWithNoReturn(string sql, DynamicParameters param = null)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                sqlCon.Query(sql, param);
            }
        }

        public static void ExecuteProcedureWithNoReturn(string procedureName, DynamicParameters param = null)
        {
            using(MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                sqlCon.Open();
                sqlCon.Execute(procedureName, param, commandType: CommandType.StoredProcedure);
            }
        }

        public static T ExecuteReturnOne<T>(string sql, DynamicParameters param = null)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                sqlCon.Open();
                return (T)Convert.ChangeType(sqlCon.QuerySingle<T>(sql,param), typeof(T));
            }
        }

        public static IEnumerable<T> ExecuteReturnList<T>(string sql, DynamicParameters param = null)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                return sqlCon.Query<T>(sql, param);
            }
        }
    }


}

using Dapper;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MEDICO.Helpers
{
    public class ConexionHelper
    {
        public static string GetOracleConnectionString()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Oracle"].ConnectionString;
            return connectionString;
        }

        public static Task<IEnumerable<T>> DapperExecuteQuery<T>(string sqlQuery, Dictionary<string, object> parameters = null) where T : new()
        {
            using (OracleConnection connection = new OracleConnection(GetOracleConnectionString()))
            {
                connection.Open();

                if (parameters != null)
                {
                    return connection.QueryAsync<T>(sqlQuery, parameters);
                }
                else
                {
                    return connection.QueryAsync<T>(sqlQuery);
                }
            }
        }
    }
}
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLShortnerApp.Library.DataAccess.Internal
{
    public class SqlDb : IDataAccess
    {
        private readonly IConfiguration _config;

        public SqlDb(IConfiguration config)
        {
            _config = config;
        }

        public List<T> LoadData<T, U>(string storedProcedure, U paramaters, string connectionStringName)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var rows = connection.Query<T>(
                    storedProcedure,
                    paramaters,
                    commandType: CommandType.StoredProcedure);

                return rows.ToList();
            }
        }

        public void SaveData<T>(string storedProcedure, T paramaters, string connectionStringName)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                    connection.Execute(
                    storedProcedure,
                    paramaters,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}

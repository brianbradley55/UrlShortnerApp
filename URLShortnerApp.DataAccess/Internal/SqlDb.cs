using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLShortnerApp.DataAccess.Models;

namespace URLShortnerApp.DataAccess.Internal
{
    public class SqlDb : IDataAccess
    {
        private readonly IConfiguration _config;

        public SqlDb(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<T>> LoadData<T, U>(string storedProcedure, U paramaters, string connectionStringName)
        {
            // allows us to add name from settings without hard coding into our app which is v good 
            string connectionString = _config.GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var rows = await connection.QueryAsync<T>(
                    storedProcedure,
                    paramaters,
                    commandType: CommandType.StoredProcedure);

                return rows.ToList();
            }
        }

        public async Task<int> SaveData<T>(string storedProcedure, T paramaters, string connectionStringName)
        {
            // allows us to add name from settings without hard coding into our app which is v good 
            string connectionString = _config.GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                return await connection.ExecuteAsync(
                    storedProcedure,
                    paramaters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        //public IEnumerable<URLModel> GetCollectionFromDb()
        //{
        //    throw new NotImplementedException();
        //}

        //public URLModel GetItemFromDbByLongUrl(string shortUrl)
        //{
        //    throw new NotImplementedException();
        //}

        //public URLModel GetItemFromDbByShortUrl(string shortUrl)
        //{
        //    throw new NotImplementedException();
        //}

        //public URLModel SaveItemToDb(URLModel model)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using URLShortnerApp.Library.DataAccess.Internal;
using URLShortnerApp.Library.Models;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace URLShortnerApp.Library.DataAccess
{
    public class UrlData : IUrlData
    {
        private readonly IDataAccess _db;

        public UrlData(IDataAccess db)
        {
            _db = db;
        }

        public URLModel GetItemFromDbByLongUrl(string longUrl)
        {
            var output = _db.LoadData<URLModel, dynamic>("spUrls_GetByURL", new { URL = longUrl }, "UrlDb").FirstOrDefault();
            return output;
        }

        public URLModel GetItemFromDbByShortUrl(string shortUrl)
        {
            var output = _db.LoadData<URLModel, dynamic>("spUrls_GetByShortUrl", new { ShortURL = shortUrl }, "UrlDb").FirstOrDefault();
            return output;
        }

        public URLModel GetItemFromDbByToken(string token)
        {
            var output = _db.LoadData<URLModel, dynamic>("spUrls_GetByToken", new { Token = token }, "UrlDb").FirstOrDefault();
            return output;
        }

        public int SaveItemToDb(URLModel model)
        {
            DynamicParameters p = new DynamicParameters();

            p.Add("URL", model.URL);
            p.Add("ShortURL", model.ShortURL);
            p.Add("Token", model.Token);
            p.Add("Created", model.CreatedAt);
            p.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

            _db.SaveData("spUrls_Insert", p, "UrlDb");

            // Scope identity in stored procedure will bring id back
            return p.Get<int>("Id");
        }
    }
}

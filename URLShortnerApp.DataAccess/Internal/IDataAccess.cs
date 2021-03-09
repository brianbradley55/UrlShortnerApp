using System.Collections.Generic;
using System.Threading.Tasks;
using URLShortnerApp.DataAccess.Models;

namespace URLShortnerApp.DataAccess.Internal
{
    public interface IDataAccess
    {
        Task<List<T>> LoadData<T, U>(string storedProcedure, U paramaters, string connectionStringName);
        Task<int> SaveData<T>(string storedProcedure, T paramaters, string connectionStringName);

        //IEnumerable<URLModel> GetCollectionFromDb();
        //URLModel GetItemFromDbByShortUrl(string shortUrl);
        //URLModel GetItemFromDbByLongUrl(string shortUrl);
        //URLModel SaveItemToDb(URLModel model);
    }
}

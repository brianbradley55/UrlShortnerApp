using System.Collections.Generic;
using System.Threading.Tasks;

namespace URLShortnerApp.Library.DataAccess.Internal
{
    public interface IDataAccess
    {
        List<T> LoadData<T, U>(string storedProcedure, U paramaters, string connectionStringName);
        void SaveData<T>(string storedProcedure, T paramaters, string connectionStringName);
    }
}

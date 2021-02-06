using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public interface ISqlDataAccess
    {
        string ConnectionString { get; set; }

        Task<List<T>> LoadDataSql<T>(string sqlStatement);

        //string ConnectionStringName { get; set; }

        //Task<List<T>> LoadData<T, U>(string sql, U parameter);
        //Task SaveData<T>(string sql, T parameters);
        Task SaveDataSql(string sqlStatement);
    }
}
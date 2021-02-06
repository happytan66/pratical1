using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class SqlDataAccess : ISqlDataAccess
    {
        //what you want to do with a DataAccess Class is to make it generic
        //that way your other methods in your projects will be able to use it to 
        //access different sql database as needed, thus the more generic the connection string is
        //the more flexibility you have to reuse it.

        private string _connectionString = string.Empty;

        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }




        //private readonly IConfiguration _config;

        //public string ConnectionStringName { get; set; } = "Default";

        //public SqlDataAccess(IConfiguration config)
        //{
        //    _config = config;
        //}


        //if you are using sqlquerystatement then you should prepare your sql statement in your code which uses
        //this method rather than passing all the parameters and build up tour sql query statement here
        //always as generic as possible for reusability
        public async Task<List<T>> LoadDataSql<T>(string sqlStatement)
        {
            //check if there are connection string defined
            if (string.IsNullOrEmpty(_connectionString))
                return null;

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var rows = await connection.QueryAsync<T>(sqlStatement, commandType: CommandType.Text);

                return rows.ToList();
            }
        }

        //public async Task<List<T>> LoadData<T, U>(string sql, U parameter)
        //{
        //    String connectionString = _config.GetConnectionString(ConnectionStringName);

        //    using (IDbConnection connection = new SqlConnection(connectionString))
        //    {
        //        var data = await connection.QueryAsync<T>(sql, parameter);

        //        return data.ToList();

        //    }
        //}

        public async Task SaveDataSql(string sqlStatement)
        {
            if (string.IsNullOrEmpty(_connectionString))
                return;

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(sqlStatement, commandType: CommandType.Text);
            }
        }

        //public async Task SaveData<T>(string sql, T parameters)
        //{
        //    String connectionString = _config.GetConnectionString(ConnectionStringName);

        //    using (IDbConnection connection = new SqlConnection(connectionString))
        //    {
        //        await connection.ExecuteAsync(sql, parameters);

        //    }
        //}


        //Don't do something specific in this class, it should be ambigious and nothing specific
        //things like get user, add user, update people should be place in their own respecitve class
        //seperation of concerns

        //public async Task<List<T>> GetUser<T, U>(string sql, U parameter)
        //{
        //    String connectionString = _config.GetConnectionString(ConnectionStringName);

        //    using (IDbConnection connection = new SqlConnection(connectionString))
        //    {
        //        var data = await connection.QueryAsync<T>(sql, parameter);

        //        return data.ToList();

        //    }
        //}


        /*
         * the above will be the most basic code to save and load data from a sql db after you pass in a connection string
         */ 
         
    }
}

using DataAccessLibrary.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class PersonSqlServices : IPersonServices
    {
        private readonly ISqlDataAccess _dataAccess;

        public PersonSqlServices(ISqlDataAccess dataaccess)
        {
            _dataAccess = dataaccess;
        }

        public void DefineConnectionString(string connectionstring)
        {
            //define the connection string specific to this service

            _dataAccess.ConnectionString = connectionstring;
        }

        //get all the people object from your table
        public async Task<List<IPersonModel>> GetPeople()
        {
            var peoplelist = await _dataAccess.LoadDataSql<PersonModel>("Select * From dbo.People");

            return peoplelist.ToList<IPersonModel>();
        }


        //Get the person object by the email and do the verification in your application code to check the password
        public async Task<IPersonModel> GetPersonByEmail(string emailaddress)
        {
            try
            {
                var peoplelist = await _dataAccess.LoadDataSql<PersonModel>($"Select * from dbo.People where Email='{emailaddress}'");

                if (peoplelist == null || peoplelist.Count == 0)
                    return null;

                return peoplelist.FirstOrDefault<IPersonModel>();

            }
            catch (Exception)
            {
                throw;
            }
        }


        //personally i don't like using sql statement like this as it posses a lot of security concerns and changes are not flexible
        //I would rather use stored procedure and manage my database as code using SSDT but that is a whole different knowledge to learn if you are not familiar with it
        //so for this example we will just use sql statement and I assume that your database table are the same as what is define in your model
        public async Task Insert(IPersonModel persondata)
        {
            string insertstr = $"insert into dbo.People ([Id],[FirstName],[LastName],[EmailAddress],[Password]) " +
                $"values ({persondata.Id},'{persondata.FirstName}','{persondata.LastName}','{persondata.EmailAddress}','{persondata.Password}')";

            await _dataAccess.SaveDataSql(insertstr);
        }
    }
}

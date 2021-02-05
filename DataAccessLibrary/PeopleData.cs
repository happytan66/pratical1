using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{


    public class PeopleData : IPeopleData

    {
        private readonly ISqlDataAccess _db;

        public PeopleData(ISqlDataAccess db)
        {
            _db = db;
        }
        public Task<List<PersonModel>> GetPeople()
        {
            string sql = "select * from dbo.People";

            return _db.LoadData<PersonModel, dynamic>(sql, new { });
        }

        public Task InsertPerson(PersonModel person)
        {
            string sql = @"insert into dbo.People (Id,FirstName, LastName, EmailAddress, password)
                            values (@Id,@FirstName, @LastName, @EmailAddress, @password);";

            return _db.SaveData(sql, person);
        }

        public Task<List<PersonModel>> Id()
        {
            string sql = "select Id from dbo.People";

            return _db.LoadData<PersonModel, dynamic>(sql, new { });
        }
        public Task<List<PersonModel>> VerifyUser()
        {

           // string sql = @"select EmailAddress,password from dbo.People"  ;
            string sql = "dbo.People.SingleOrDefault(a =>a.Email ==Email" +
                         " && a.password == password";

            return _db.LoadData<PersonModel, dynamic>(sql, new { });
        }

        public bool GetEmailPassword(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}    


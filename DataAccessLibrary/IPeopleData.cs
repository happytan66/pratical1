using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public interface IPeopleData
    {
        Task<List<PersonModel>> GetPeople();
        Task InsertPerson(PersonModel person);

        Task<List<PersonModel>> Id();

        Boolean GetEmailPassword(string email, string password);

        Task<List<PersonModel>> VerifyUser();
    }
}
using DataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public interface IPersonServices
    {
        void DefineConnectionString(string connectionstring);
        Task<List<IPersonModel>> GetPeople();
        Task<IPersonModel> GetPersonByEmail(string emailaddress);
        Task Insert(IPersonModel persondata);
    }
}
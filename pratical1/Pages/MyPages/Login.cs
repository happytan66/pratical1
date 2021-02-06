using DataAccessLibrary;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using pratical1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pratical1.Pages.MyPages
{
    public partial class Login
    {
        [Inject]
        protected IPersonServices PersonService { get; set; }

        [Inject]
        protected IConfiguration Config { get; set; }

        [Inject]
        protected NavigationManager NavManager { get; set; }

        private DisplayPersonModel personData = new DisplayPersonModel();

        protected override void OnParametersSet()
        {
            var connectionstring = Config.GetConnectionString("Default");

            PersonService.DefineConnectionString(connectionstring);
        }

        private async Task LoginAttempt()
        {
            var loginpersondata = await PersonService.GetPersonByEmail(personData.EmailAddress);

            if(loginpersondata!=null)
            {
                if(loginpersondata.Password.Equals(personData.Password))
                    NavManager.NavigateTo("/Counter");
            }
            
        }

    }
}

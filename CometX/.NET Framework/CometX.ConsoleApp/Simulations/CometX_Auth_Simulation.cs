using CometX.ConsoleApp.Models.Authentication;
using CometX.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CometX.ConsoleApp.Simulations
{
    public class CometX_Auth_Simulation : CometX_Base_Simulation
    {
        protected CometXService _service1 = new CometXService("HackathonConnection");
        public CometX_Auth_Simulation(string connectionString = "") : base(connectionString)
        {
        }

        public override void Run()
        {
            // Test out INSERT
            //var result_insertWithContext = Insert_WithContext();
            Insert_WithoutContext(new Token
            {
                Key = "TEST",
                AuthorizedOriginId = 2,
                CreatedOn = DateTime.Now,
                ExpiresOn = DateTime.Now.AddMinutes(30),
                IssuedOn = DateTime.Now
            });
        }

        public void Insert_WithoutContext(Token token)
        {
            _service1.Insert(token);
        }
    }
}

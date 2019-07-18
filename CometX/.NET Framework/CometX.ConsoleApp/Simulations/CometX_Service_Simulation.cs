using System;
using System.Collections.Generic;
using CometX.Service;
using CometX.Entities.TableEntity;
using CometX.ConsoleApp.Models.Generic;

namespace CometX.ConsoleApp.Simulations
{
    public class CometX_Service_Simulation : CometX_Base_Simulation
    {
        protected CometXService _service1 = new CometXService("DefaultConnection");
        protected CometXService _service2 = new CometXService("DefaultConnection");

        public CometX_Service_Simulation(string connectionString = "") : base(connectionString)
        {
        }

        public override void Run()
        {
            // Testing out Any 
            var result_singleCondition = Any_SingleCondition();
            var result_multiCondition = Any_MultiCondition();

            // Testing out Sorted Table
            var result_skipTakeCondition = SortedTable_SkipTakeCondition<ApplicationLog>();
            var result_skipTakeWhereCondition = SortedTable_SkipTakeWhereCondition();

            // Test out INSERT
            var result_insertWithContext = Insert_WithContext();
        }

        public bool Any_SingleCondition()
        {
            return _service1.Any<UserSetting>(x => x.Username == "A04744" && x.FirstName == "Carlos");
        }

        public bool Any_MultiCondition()
        {
            return _service1.Any<UserSetting>(x => x.Username == "A04744" && x.FirstName == "" && x.LastName == "" && x.IsEntryValidationRequired == true);
        }

        public ApplicationLog Insert_WithContext()
        {
            var entity = new ApplicationLog
            {
                Date = DateTime.Now,
                Thread = "TEST",
                Level = "TEST",
                Logger = "TEST",
                Message = "TEST",
                Exception = "",
                ApplicationName = "TEST",
                ApplicationLibrary = "TEST",
                Username = "TEST",
                Filename = "TEST"
            };

            _service2.InsertWithContext(ref entity);
            return entity;
        }

        public List<T> SortedTable_SkipTakeCondition<T>() where T : new()
        {
            return _service2.GetSortedTable<T>(SortDirection.Descending, "Id", 0, 10);
        }

        public List<ApplicationLog> SortedTable_SkipTakeWhereCondition() 
        {
            var today = DateTime.Now;
            return _service2.GetSortedTable<ApplicationLog>(SortDirection.Descending, "Id", 0, 10, x => x.Date < today);
        }
    }
}

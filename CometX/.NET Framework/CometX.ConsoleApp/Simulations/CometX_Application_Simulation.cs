using System;
using System.Collections.Generic;
using CometX.Service;
using CometX.Entities.TableEntity;
using CometX.ConsoleApp.Models.APAAcct;
using CometX.ConsoleApp.Models.APALog;

namespace CometX.ConsoleApp.Simulations
{
    public class CometX_Application_Simulation : CometX_Base_Simulation
    {
        protected CometXService _cometXService_Acct = new CometXService("APATables_ACCTEntities");
        protected CometXService _cometXService_APALog = new CometXService("APALog");

        public CometX_Application_Simulation(string connectionString = "") : base(connectionString)
        {
        }

        public override void Run()
        {
            // Testing out Any 
            var result_singleCondition = Any_SingleCondition();
            var result_multiCondition = Any_MultiCondition();

            // Testing out Sorted Table
            var result_skipTakeCondition = SortedTable_SkipTakeCondition<APA_ApplicationLog>();
            var result_skipTakeWhereCondition = SortedTable_SkipTakeWhereCondition();

            // Test out INSERT
            var result_insertWithContext = Insert_WithContext();
        }

        public bool Any_SingleCondition()
        {
            return _cometXService_Acct.Any<UserSetting>(x => x.Username == "A04744" && x.FirstName == "Carlos");
        }

        public bool Any_MultiCondition()
        {
            return _cometXService_Acct.Any<UserSetting>(x => x.Username == "A04744" && x.FirstName == "" && x.LastName == "" && x.IsEntryValidationRequired == true);
        }

        public APA_ApplicationLog Insert_WithContext()
        {
            var entity = new APA_ApplicationLog
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

            _cometXService_APALog.InsertWithContext(ref entity);
            return entity;
        }

        public List<T> SortedTable_SkipTakeCondition<T>() where T : new()
        {
            return _cometXService_APALog.GetSortedTable<T>(SortDirection.Descending, "Id", 0, 10);
        }

        public List<APA_ApplicationLog> SortedTable_SkipTakeWhereCondition() 
        {
            var today = DateTime.Now;
            return _cometXService_APALog.GetSortedTable<APA_ApplicationLog>(SortDirection.Descending, "Id", 0, 10, x => x.Date < today);
        }
    }
}

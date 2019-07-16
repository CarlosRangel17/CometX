using System;
using CometX.ConsoleApp.Simulations;

namespace CometX.ConsoleApp
{
    public class Program
    {
        protected CometX_Base_Simulation Simulation { get; set; }

        static void Main(string[] args)
        {
            try
            {
                var sim = new CometX_Application_Simulation();
                //var Simulation = new CometX_DataMigration_Simulation();
                //var Simulation = new APA_AttendanceLog_VisitorLog_Simulation();

                sim.Run();
            }
            catch (Exception ex)
            {
                string message = ex.Message;

                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    message += ex.Message;
                }

                throw new Exception(message);
            }
        }
    }
}

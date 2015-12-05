using Exchange_Manager;
using System.ServiceProcess;

namespace BackupService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new BackupService()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}

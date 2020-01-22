using System;
using System.IO;
using System.ServiceProcess;

namespace WindowsService
{
    public partial class Service : ServiceBase
    {
        private const string LogPath = "C:\\ServiceLog.txt";

        public Service()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            LogToFile("Service started.");
        }

        protected override void OnStop()
        {
            LogToFile("Service stopped.");
        }

        private static void LogToFile(string text)
        {
            using (var writer = new StreamWriter(LogPath, append: true))
            {
                writer.WriteLine($"{DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")}: {text}");
            }
        }
    }
}

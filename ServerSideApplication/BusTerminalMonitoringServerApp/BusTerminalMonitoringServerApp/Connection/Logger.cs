
using System;
using System.Configuration;
using System.IO;
namespace BusTerminalMonitoringServerApp.Connection
{
    public class Logger : ILogger
    {
        private string dirPath = ConfigurationManager.AppSettings.Get("LOGGER_DIR_PATH");
        private string fileName = string.Empty;
        private string extension = ".txt";
        private bool disposed = false;
        private static Logger instance = default(Logger);

        public static Logger InstanceContext
        {
            get { return instance ?? (instance = new Logger()); }
        }

        private Logger()
        {
        }

        public void Initialize()
        {
            if (string.IsNullOrEmpty(dirPath))
                throw new ArgumentException("FilePath");

            try
            {
                if (!Directory.Exists(dirPath))
                    Directory.CreateDirectory(dirPath);

                this.fileName = DateTime.Now.ToString("MM-dd-yy") + extension;
                FileInfo file = new FileInfo(dirPath + this.fileName);
                if (!file.Exists)
                    using (file.Create()) { }                        
            }
            catch
            {
            }
        }

        public void Initialize(string filePath)
        {
            this.dirPath = filePath;
            Initialize();
        }

        public string FilePath
        {
            get { return this.dirPath; }
            set { this.dirPath = value; }
        }

        public bool IsEnable
        {
            get { return bool.Parse(ConfigurationManager.AppSettings.Get("LOGGER_ENABLE")); }
        }

        public void LogToDisk(string message)
        {
            try
            {
                using (StreamWriter writer = File.AppendText(this.dirPath + this.fileName))
                {
                    writer.WriteLine(message);
                }
            }
            catch
            {
            }
        }

        public void LogToDisk(string message, System.DateTime dateTime)
        {
            LogToDisk(string.Format("[ {0} ] : {1}", dateTime.ToString("MM-dd-yy"), message));
        }
    }
}

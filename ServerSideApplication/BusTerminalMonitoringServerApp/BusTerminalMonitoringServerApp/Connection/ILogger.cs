
using System;
namespace BusTerminalMonitoringServerApp.Connection
{
    public interface ILogger
    {
        string FilePath { get; set; }
        bool IsEnable { get; }

        void Initialize();
        void Initialize(string filePath);

        void LogToDisk(string message);
        void LogToDisk(string message, DateTime dateTime);
    }
}

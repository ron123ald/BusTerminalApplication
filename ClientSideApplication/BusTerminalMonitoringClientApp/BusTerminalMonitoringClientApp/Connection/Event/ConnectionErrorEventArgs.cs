namespace BusTerminalMonitoringClientApp.Connection.Event
{
    using System;

    public class ConnectionErrorEventArgs : EventArgs
    {
        private string message = string.Empty;
        public ConnectionErrorEventArgs(string message)
        {
            this.message = message;
        }

        public string ErrorMessage
        {
            get { return this.message; }
        }
    }
}
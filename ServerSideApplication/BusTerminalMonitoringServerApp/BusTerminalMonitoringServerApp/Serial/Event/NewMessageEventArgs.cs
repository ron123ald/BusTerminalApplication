namespace BusTerminalMonitoringServerApp.Serial.Event
{
    using System;

    public class NewMessageEventArgs : EventArgs
    {
        private string message = string.Empty;

        public NewMessageEventArgs()
        {
        }

        public NewMessageEventArgs(string message)
        {
            this.message = message;
        }

        public string Message
        {
            get { return this.message; }
            set { this.message = value; }
        }
    }
}

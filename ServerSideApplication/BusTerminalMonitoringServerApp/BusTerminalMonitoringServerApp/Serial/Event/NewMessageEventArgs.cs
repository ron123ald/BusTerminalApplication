namespace BusTerminalMonitoringServerApp.Serial.Event
{
    using System;

    public class NewMessageEventArgs : EventArgs
    {
        private string message = string.Empty;
        private string phoneNumber = string.Empty;

        public NewMessageEventArgs()
        {
        }

        public NewMessageEventArgs(string message, string phoneNumber)
        {
            this.message = message;
            this.phoneNumber = phoneNumber;
        }

        public string Message
        {
            get { return this.message; }
            set { this.message = value; }
        }

        public string PhoneNumber
        {
            get { return this.phoneNumber; }
            set { this.phoneNumber = value; }
        }
    }
}

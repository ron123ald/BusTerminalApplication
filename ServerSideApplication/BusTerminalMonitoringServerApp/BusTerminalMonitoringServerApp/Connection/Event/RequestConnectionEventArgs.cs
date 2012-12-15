namespace BusTerminalMonitoringServerApp.Connection.Event
{
    using System;
    using System.Net.Sockets;

    /// <summary>
    /// this is an Event Argument class that hold the published data 
    /// from ServerConnection to MainForm
    /// </summary>
    public class RequestConnectionEventArgs : EventArgs
    {
        /// <summary>
        /// TcpClient holds the connection for client
        /// </summary>
        private TcpClient client = default(TcpClient);
        /// <summary>
        /// this variable contains of Random characters and numbers
        /// </summary>
        private string client_uniquekey = Guid.NewGuid().ToString().Replace("-", "");
        /// <summary>
        /// Constructor
        /// </summary>
        public RequestConnectionEventArgs()
        {
        }
        /// <summary>
        /// Constructor with TcpClient params
        /// </summary>
        /// <param name="client">Connection of the Client</param>
        public RequestConnectionEventArgs(TcpClient client)
        {
            /// Set Client Property to client params
            this.Client = client;
        }
        #region Setters and Getters
        /// <summary>
        /// this is a Property: TcpClient Client
        /// public variables that has 'get' and 'set' are called properties.
        /// </summary>
        public TcpClient Client
        {
            /// set client to value
            set { this.client = value; }
            /// get client value
            get { return this.client; }
        }
        /// <summary>
        /// this property is the Unique Key of the Client Connection
        /// </summary>
        public string UniqueKey
        {
            /// return unique_key
            get { return this.client_uniquekey; }
        }
        #endregion
    }
}

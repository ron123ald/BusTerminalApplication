namespace BusTerminalMonitoringServerApp.Connection
{
    using System;
    using System.Net;
    using System.ComponentModel;
    using System.Net.Sockets;
    using BusTerminalMonitoringServerApp.Connection.Event;

    #region Delegates

    public delegate void RequestConnectionEventHandler(object sender, RequestConnectionEventArgs e);

    #endregion

    public class ServerConnection : IDisposable
    {
        /// <summary>
        /// this is an Event.
        /// </summary>
        public event RequestConnectionEventHandler NewRequestConnectionEvent = default(RequestConnectionEventHandler);
        /// <summary>
        /// BackgroundWorker is a component that works in other thread.
        /// </summary>
        private BackgroundWorker worker = default(BackgroundWorker);
        /// <summary>
        /// TCP Listener is used to expose TCP/IP Connection
        /// </summary>
        private TcpListener listener = default(TcpListener);
        /// <summary>
        /// Initialize Background worker
        /// BackgroundWorker class will not run in the Main thread
        /// It will create a new thread where it runs.
        /// Initialize the EventHandler Method of the event DoWork.
        /// </summary>
        private ServerConnection()
        {
            /// Create BackgroundWorker
            this.worker = new BackgroundWorker();
            /// Initialize DoWork EventHandler
            this.worker.DoWork += new DoWorkEventHandler(worker_DoWork);
        }
        /// <summary>
        /// Initialize BackgroundWorker then
        /// Initialize TCP/IP connection
        /// </summary>
        /// <param name="address"></param>
        /// <param name="port"></param>
        public ServerConnection(IPAddress address, int port) : this()
        {
            /// Create TCP/IP Connection
            this.listener = new TcpListener(address, port);
        }
        /// <summary>
        /// this is an EventHandler Method.
        /// this will only triggers whevener you start the worker
        /// this.worker.RunWorkerAsync();
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            /// Start Listening to the Connection
            this.listener.Start();
            /// this is the object that holds the connection of the client.
            TcpClient client = default(TcpClient);
            /// Unlimited Loop
            /// Loop to Get New Client Request for connection.
            while (true)
            {
                try
                {
                    /// the debbugger will pass through this line after there's a client request for connection
                    client = this.listener.AcceptTcpClient();
                    /// check if client is not Null
                    if (client != null)
                    {
                        /// fire Event Handler "NewRequestConnectionEvent"
                        this.NewRequestConnectionEvent(this, new RequestConnectionEventArgs(client));
                    }
                }
                catch { }
            }
        }
        /// <summary>
        /// this method will start the BackgroundWorker Component to Do Work.
        /// </summary>
        public void EstablishConnection()
        { 
            /// run the BackgroundWorker Instance in an Asynchronous call
            /// means: run this worker in a different thread.
            this.worker.RunWorkerAsync();
        }
        /// <summary>
        /// Dispose or Release the resources from this class
        /// Implementing IDisposable Interface in this class is 
        /// Important, because we are using Network resources
        /// in this class.
        /// </summary>
        public void Dispose()
        {
            /// Dispose BackgrounWorker
            this.worker.Dispose();
            /// Stop TCP/IP Connection
            this.listener.Stop();
            /// Set to Null
            this.listener = default(TcpListener);
        }
    }
}
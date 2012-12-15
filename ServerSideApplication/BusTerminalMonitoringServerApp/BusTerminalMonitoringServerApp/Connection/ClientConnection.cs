namespace BusTerminalMonitoringServerApp.Connection
{
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Net.Sockets;

    #region MyRegion
    
    /// <summary>
    /// delete method 
    /// this is used to whenever the client disconnects from the server
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ClientDisconnectEventHandler(object sender, EventArgs e);

    #endregion

    public class ClientConnection : IDisposable
    {
        private string platenumber = string.Empty;
        /// <summary>
        /// Event that publish data to subscribers whenever the client disconnects
        /// from the server.
        /// </summary>
        public event ClientDisconnectEventHandler ClientDisconnectEvent = default(ClientDisconnectEventHandler);
        /// <summary>
        /// BackgroundWorker is a component that works in other thread.
        /// </summary>
        private BackgroundWorker worker = default(BackgroundWorker);
        /// <summary>
        /// TcpClient holds the connection for client
        /// </summary>
        private TcpClient client = default(TcpClient);
        /// <summary>
        /// NetworkStream of the client connection
        /// </summary>
        private NetworkStream stream = default(NetworkStream);
        /// <summary>
        /// this object is used to read data transmit from client
        /// </summary>
        private StreamReader reader = default(StreamReader);
        /// <summary>
        /// this objet is used to write data transmit to client
        /// </summary>
        private StreamWriter writer = default(StreamWriter);
        /// <summary>
        /// Constructor
        /// Initiate new Instance of BackgroundWorker
        /// </summary>
        private ClientConnection()
        {
            /// Create new Instance of BackgroundWorker
            this.worker = new BackgroundWorker();
            /// Initialize DoWork EventHandler
            this.worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            this.worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
        }
        /// <summary>
        /// Constructor
        /// by pass TcpClient client instance
        /// </summary>
        /// <param name="client">holds the connection request of client</param>
        public ClientConnection(TcpClient client) : this()
        {
            /// set private variable client with client params
            this.client = client;
            /// create new instance of NetworkStream by getting client's data stream 
            this.stream = this.client.GetStream();
            /// create new instance of StreamReader by passing the NetWorkStream instance
            this.reader = new StreamReader(this.stream);
            /// create new instance of StreamWriter by passing the NetWorkStream instance
            this.writer = new StreamWriter(this.stream);
        }
        /// <summary>
        /// this is an EventHandler Method,
        /// that will triggers whenever the worker's DoWork ends
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            /// check if e.Result's type is Exception
            if (e.Result is Exception)
                /// fire ClientDisconnectEvent
                this.ClientDisconnectEvent(this, new EventArgs());
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
            /// Intialize data (string) with an empty string instance;
            string data = string.Empty;
            /// Unlimited loop
            /// to read all transmitted data by client side application
            while (true)
            {
                try
                {
                    /// read transmitted data 
                    /// debugger will stop in this line to wait for data, 
                    /// and continue once there is a data transmitted
                    data = this.reader.ReadLine();
                    /// check if data is not Null or Empty
                    if (!string.IsNullOrEmpty(data))
                    {
                        #region no implementation yet, need to work on higher priority
                        ///// Get ActionType of the data
                        //switch (ServerUtility.GetActionType(data))
                        //{
                        //    case ActionType.RequestConnection:
                        //        break;
                        //    case ActionType.Transmit:
                        //        break;
                        //    case ActionType.ClientApplicationStart:
                        //        break;
                        //    case ActionType.ClientApplicationStop:
                        //        break;
                        //    case ActionType.Ping:
                        //        break;
                        //    case ActionType.Pong:
                        //        break;
                        //    case ActionType.Unknown:
                        //        break;
                        //    default: break;
                        //} 
                        #endregion
                    }
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                    break;
                }
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
        /// this method will write the data to the client's connection stream.
        /// this will transmit the data to client side application.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public void Transmit(string data)
        {
            /// write the data to the stream
            this.writer.WriteLine(data);
            /// flush the writer
            this.writer.Flush();
        }
        /// <summary>
        /// this property serves as Unique Identification of ClientConnection
        /// </summary>
        public string PlateNumber
        {
            /// set the private variable platenumber to value
            set { this.platenumber = value; }
            /// get the value of platenumber
            get { return this.platenumber; }
        }
        /// <summary>
        /// Dispose or Release the resources from this class
        /// Implementing IDisposable Interface in this class is 
        /// Important, because we are using Network resources
        /// in this class.
        /// </summary>
        public void Dispose()
        {
            /// close all streams
            this.client.Close();
            this.stream.Close();
            this.reader.Close();
            this.writer.Close();
            /// set client's connection to default; (Null)
            this.client = default(TcpClient);
            /// Dispose all streams
            this.stream.Dispose();
            this.reader.Dispose();
            this.writer.Dispose();
        }
    }
}
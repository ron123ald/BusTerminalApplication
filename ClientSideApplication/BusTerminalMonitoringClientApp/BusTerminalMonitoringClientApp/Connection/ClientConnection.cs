namespace BusTerminalMonitoringClientApp.Connection
{
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Net.Sockets;
    using BusTerminalMonitoringClientApp.Connection.Event;

    public delegate void TransmittedDataEventHandler(object sender, TransmitEventArgs e);
    public delegate void DisconnectEventHandler(object sender, EventArgs e);
    public delegate void ErrorEventHandler(object sender, ConnectionErrorEventArgs e);

    public class ClientConnection : IDisposable
    {
        /// <summary>
        /// Error EventHandler
        /// </summary>
        public event ErrorEventHandler ErrorEvent;
        /// <summary>
        /// Data transmit to process
        /// </summary>
        public event TransmittedDataEventHandler TransmitEvent;
        /// <summary>
        /// this will fire whenever the server gets disconnected
        /// </summary>
        public event DisconnectEventHandler DisconnectedEvent;
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
        /// BackgroundWorker is a component that works in other thread.
        /// </summary>
        private BackgroundWorker worker = default(BackgroundWorker);

        private string address = string.Empty;
        private int port = 0;

        /// <summary>
        /// private constructor
        /// </summary>
        private ClientConnection()
        {
            /// Create new Instance of BackgroundWorker
            this.worker = new BackgroundWorker();
            /// Initialize DoWork EventHandler
            this.worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            /// Initialize RunWorkerCompleted EventHandler
            this.worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="address"></param>
        /// <param name="port"></param>
        public ClientConnection(string address, int port) : this()
        {
            this.Address = address;
            this.Port = port;
        }
        /// <summary>
        /// Get or Set the address of the server
        /// </summary>
        public string Address
        {
            set { this.address = value; }
            get { return this.address; }
        }
        /// <summary>
        /// Get or set the port of the server
        /// </summary>
        public int Port
        {
            set { this.port = value; }
            get { return this.port; }
        }
        /// <summary>
        /// this is an EventHandler Method,
        /// that will triggers whenever the worker's DoWork ends
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) 
        {
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
            try
            {
                /// set private variable client with client params
                this.client = new TcpClient(this.Address, this.Port);
                /// create new instance of NetworkStream by getting client's data stream 
                this.stream = this.client.GetStream();
                /// create new instance of StreamReader by passing the NetWorkStream instance
                this.reader = new StreamReader(this.stream);
                /// create new instance of StreamWriter by passing the NetWorkStream instance
                this.writer = new StreamWriter(this.stream);
            }
            catch (Exception ex)
            {
                ErrorEvent(this, new ConnectionErrorEventArgs(ex.Message));
                return;
            }
            finally
            {
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
                            /// Get ActionType of the data
                            switch (FormUtility.GetActionType(data))
                            {
                                case ActionType.Transmit:
                                    TransmitEvent(this, new TransmitEventArgs(data));
                                    break;
                                case ActionType.Diconnect:
                                    DisconnectedEvent(this, new EventArgs());
                                    break;
                                case ActionType.Unknown:
                                    break;
                                default: break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                        break;
                    }
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
        /// Dispose or Release the resources from this class
        /// Implementing IDisposable Interface in this class is 
        /// Important, because we are using Network resources
        /// in this class.
        /// </summary>
        public void Dispose()
        {
            if (this.stream != null)
            {
                /// close all streams
                this.stream.Close();
                /// Dispose all streams
                this.stream.Dispose();
            }
            if (this.reader != null)
            {
                this.reader.Close();
                this.reader.Dispose();
            }

            if (this.writer != null)
            {
                this.writer.Close();
                this.writer.Dispose(); 
            }
        }
    }
}

namespace BusTerminalMonitoringServerApp.Connection
{
    using System;
    using System.Net;
    using System.ComponentModel;
    using System.Net.Sockets;

    public class ServerConnection : IDisposable
    {
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
            this.worker = new BackgroundWorker();
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
        }
        /// <summary>
        /// this method will write the data in to the stream where the client is connected.
        /// </summary>
        /// <param name="data"></param>
        public void Transmit(string data)
        {
        }
        /// <summary>
        /// Dispose or Release the resources from this class
        /// Implementing IDisposable Interface in this class is 
        /// Important, because we are using Network resources
        /// in this class.
        /// </summary>
        public void Dispose()
        {
            this.listener.Stop();
            this.listener = default(TcpListener);
            this.worker.Dispose();
        }
    }
}

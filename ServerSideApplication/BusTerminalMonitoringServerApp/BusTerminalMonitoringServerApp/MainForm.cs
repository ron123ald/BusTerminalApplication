namespace BusTerminalMonitoringServerApp
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Net;
    using System.Windows.Forms;
    using BusTerminalMonitoringServerApp.Connection;
    using BusTerminalMonitoringServerApp.Connection.Collection;
    using BusTerminalMonitoringServerApp.Database;
    using BusTerminalMonitoringServerApp.Serial;

    public partial class MainForm : Form
    {
        /// <summary>
        /// private instance of Bus database 
        /// this will connect to phpmyadmin mysql database 'bus'
        /// see App.config file for the connection string 
        /// </summary>
        private BusDatabaseContext dbcontext = default(BusDatabaseContext);
        /// <summary>
        /// private Instance of ServerConnection
        /// </summary>
        private ServerConnection connection = default(ServerConnection);
        /// <summary>
        /// Instance of SerialPort connection
        /// </summary>
        private SerialConnection serial     = default(SerialConnection);
        /// <summary>
        /// public Constructor for this Class MainForm
        /// </summary>
        public MainForm()
        {
            /// built-in; auto generated method
            InitializeComponent();
        }

        #region ServerConnection EventHandlers
        /// <summary>
        /// this is an EventHandler Method of "NewRequestConnectionEvent" from ServerConnection Class
        /// this will triggers whenever the "connection" instance publish a "NewRequestConnectionEvent"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void connection_NewRequestConnectionEvent(object sender, Connection.Event.RequestConnectionEventArgs e)
        {
            /// Create ClientWorkerConnection 
            ClientConnection clientconnection = new ClientConnection(e.Client);
            /// start CLient connection
            clientconnection.EstablishConnection();
            /// Get Bus Terminal
            /// Initialize ChatDiconnectEvent's EventHandler method
            clientconnection.ClientDisconnectEvent += new ClientDisconnectEventHandler(clientconnection_ClientDisconnectEvent);
            /// Add ClientWorkerConnection instance to ServerCollection
            (ServerCollection.InstanceContext).Add(clientconnection);
            ServerUtility.Log(this.ServerLogBox, string.Format("New Client Connected {0}", e.UniqueKey));
        }
        /// <summary>
        /// this is an EventHandler Method
        /// When a Client Disconnect this method will execute 
        /// to Dispose all resources used 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clientconnection_ClientDisconnectEvent(object sender, System.EventArgs e)
        {
            /// Log that Client disconnects
            ServerUtility.Log(this.ServerLogBox, string.Format("Client Disconnected {0}", ((ClientConnection)sender).UniqueKey));
            /// remove client connection from the collection
            (ServerCollection.InstanceContext).Remove((ClientConnection)sender);
            /// dispose all resources that client connection used.
            ((ClientConnection)sender).Dispose();
        } 
        #endregion

        #region Serial Connection EventHandlers
        /// <summary>
        /// EventHandler method
        /// this will triggers whenever there is an error connecting to Serial
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serial_ErrorEvent(object sender, Serial.Event.ConnectionErrorEventArgs e)
        {
            if (!this.IsDisposed)
            {
                if (!this.InvokeRequired)
                {
                    /// Show error message
                    MessageBox.Show(this, e.ErrorMessage, "Error occured while connecting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                else
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        /// Show error message
                        MessageBox.Show(this, e.ErrorMessage, "Error occured while connecting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    });
                } 
            }
        }
        /// <summary>
        /// EventHanlder method
        /// this will triggers whenever there is New Message from serial
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serial_NewMessageEvent(object sender, Serial.Event.NewMessageEventArgs e)
        {
            ServerUtility.Log(this.ServerLogBox, e.Message);
            /// Parse e.Message to Bus 
            /// then save to db and sumbit to clients
            Bus bus = ServerUtility.ParseData(e.Message);
            /// select if record of bus_number exists in bus database
            List<Bus> busses = this.dbcontext.Select(bus.BusNumber);
            if (busses.Count <= 0)
            {
                /// insert record in database
                this.dbcontext.Insert(bus);
            }
            else
            {
                /// update record in database
                this.dbcontext.Update(bus);
            }

            /// Get All the clients
            List<ClientConnection> clients = (ServerCollection.InstanceContext).Get();
            /// Iterate to all clients and transmit bus data
            clients.ForEach(delegate(ClientConnection client)
            {
                client.Transmit(bus.ToString());
            });
            /// Log that Client disconnects
            ServerUtility.Log(this.ServerLogBox, string.Format("Send to Clients : {0}", bus.ToString()));    
        }
        #endregion

        #region MainForm EventHandlers
        /// <summary>
        /// this is an EventHandler method
        /// this will trigger whenever the MainForm Loads
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_Load(object sender, System.EventArgs e)
        {
            #region Serial Connection Initialization
            /// Instanciate serial connection
            this.serial = new SerialConnection(ConfigurationManager.AppSettings.Get("PORTNAME"), 9600, System.IO.Ports.Parity.None, System.IO.Ports.StopBits.One);
            /// Initialize NewMessageEvent
            this.serial.NewMessageEvent += new NewMessageEventHandler(serial_NewMessageEvent);
            this.serial.ErrorEvent += new ErrorEventHandler(serial_ErrorEvent);
            /// Start Serial Connection
            bool flag = this.serial.EstablistConnection(); 
            #endregion

            #region Server Connection Initialization
            /// if serial starts okay then flag returns true.
            /// then continue
            if (flag)
            {
                /// Create new instance of ServerConnection 
                /// by passing IPAddress.Any and Port 8081
                this.connection = new ServerConnection(IPAddress.Any, 8000);
                this.connection.EstablishConnection();
                /// Initialize EventHandler "NewRequestConnectionEvent" to subscribe.
                this.connection.NewRequestConnectionEvent += new RequestConnectionEventHandler(connection_NewRequestConnectionEvent);

                ServerUtility.Log(this.ServerLogBox, string.Format("Server is running @{0}:8000", IPAddress.Any.ToString()));
            #endregion

            #region Database Context Initialization
                this.dbcontext = new BusDatabaseContext();
                this.dbcontext.EstablishConnection();
            #endregion
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearLogStripMenuItem_Click(object sender, System.EventArgs e)
        {
            this.ServerLogBox.Clear();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateTimer_Tick(object sender, System.EventArgs e)
        {
            this.DateTimeLabel.Text = System.DateTime.Now.ToString();
        } 
        #endregion

        #region Protected Override Methods
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            /// Get All the clients
            List<ClientConnection> clients = (ServerCollection.InstanceContext).Get();
            /// Iterate to all clients and transmit bus data
            foreach(ClientConnection client in clients)
            {
                /// send disconnection to client
                client.Transmit(string.Format("action={0}", ActionType.Diconnect.ToString()));
                /// dispose resources used by client
                client.Dispose();
                /// remove client from the collection
                (ServerCollection.InstanceContext).Remove(client);
            }
            this.serial.Dispose();
            /// close all the clients that are connected with the server
            base.OnClosing(e);
        }
        #endregion
    }
}

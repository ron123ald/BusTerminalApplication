namespace BusTerminalMonitoringServerApp
{
    using System.Net;
    using System.Windows.Forms;
    using BusTerminalMonitoringServerApp.Connection;
    using BusTerminalMonitoringServerApp.Connection.Collection;

    public partial class MainForm : Form
    {
        /// <summary>
        /// private Instance of ServerConnection
        /// </summary>
        private ServerConnection connection = default(ServerConnection);
        /// <summary>
        /// public Constructor for this Class MainForm
        /// </summary>
        public MainForm()
        {
            /// built-in; auto generated method
            InitializeComponent();
        }
        /// <summary>
        /// this is an EventHandler method
        /// this will trigger whenever the MainForm Loads
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_Load(object sender, System.EventArgs e)
        {
            /// Create new instance of ServerConnection 
            /// by passing IPAddress.Any and Port 8081
            this.connection = new ServerConnection(IPAddress.Any, 8081);
            /// Initialize EventHandler "NewRequestConnectionEvent" to subscribe.
            this.connection.NewRequestConnectionEvent += new RequestConnectionEventHandler(connection_NewRequestConnectionEvent);
        }
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
            /// Get Bus Terminal
            /// Initialize ChatDiconnectEvent's EventHandler method
            clientconnection.ClientDisconnectEvent += new ClientDisconnectEventHandler(clientconnection_ClientDisconnectEvent);
            /// Add ClientWorkerConnection instance to ServerCollection
            (ServerCollection.InstanceContext).Add(clientconnection);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clientconnection_ClientDisconnectEvent(object sender, System.EventArgs e)
        {
        }
    }
}

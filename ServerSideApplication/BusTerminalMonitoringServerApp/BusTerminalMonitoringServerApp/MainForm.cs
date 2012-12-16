namespace BusTerminalMonitoringServerApp
{
    using System.Collections.Generic;
    using System.Net;
    using System.Windows.Forms;
    using BusTerminalMonitoringServerApp.Connection;
    using BusTerminalMonitoringServerApp.Connection.Collection;
    using BusTerminalMonitoringServerApp.Database;

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
            this.connection = new ServerConnection(IPAddress.Any, 8000);
            this.connection.EstablishConnection();
            /// Initialize EventHandler "NewRequestConnectionEvent" to subscribe.
            this.connection.NewRequestConnectionEvent += new RequestConnectionEventHandler(connection_NewRequestConnectionEvent);

            ServerUtility.Log(this.ServerLogBox, string.Format("Server is running @{0}:8000", IPAddress.Any.ToString()));
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
        /// <summary>
        /// test Invoke 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InvokeButton1_Click(object sender, System.EventArgs e)
        {
            Bus bus = new Bus
            {
                BusNumber = this.busdetails1.Text, Capacity = this.capacity1.Text,
                Lattitude = this.lattitude1.Text, Longitude = this.longitude1.Text,
                Occupied = this.occupied1.Text, Vacancy = this.vacancy1.Text, Details = "", 
                Action = ActionType.Transmit
            };
            List<ClientConnection> clients = (ServerCollection.InstanceContext).Get();
            clients.ForEach(delegate(ClientConnection client)
            {
                client.Transmit(bus.ToString());
            });

            /// Log that Client disconnects
            ServerUtility.Log(this.ServerLogBox, string.Format("Send to Clients : {0}", bus.ToString()));
        }

        private void InvokeButton2_Click(object sender, System.EventArgs e)
        {
            Bus bus = new Bus
            {
                BusNumber = this.busdetails2.Text,
                Capacity = this.capacity2.Text,
                Lattitude = this.lattitude2.Text,
                Longitude = this.longitude2.Text,
                Occupied = this.occupied2.Text,
                Vacancy = this.vacancy2.Text,
                Details = "",
                Action = ActionType.Transmit
            };
            List<ClientConnection> clients = (ServerCollection.InstanceContext).Get();
            clients.ForEach(delegate(ClientConnection client)
            {
                client.Transmit(bus.ToString());
            });

            /// Log that Client disconnects
            ServerUtility.Log(this.ServerLogBox, string.Format("Send to Clients : {0}", bus.ToString()));
        }

        private void InvokeButton3_Click(object sender, System.EventArgs e)
        {
            Bus bus = new Bus
            {
                BusNumber = this.busdetails3.Text,
                Capacity = this.capacity3.Text,
                Lattitude = this.lattitude3.Text,
                Longitude = this.longitude3.Text,
                Occupied = this.occupied3.Text,
                Vacancy = this.vacancy3.Text,
                Details = "",
                Action = ActionType.Transmit
            };
            List<ClientConnection> clients = (ServerCollection.InstanceContext).Get();
            clients.ForEach(delegate(ClientConnection client)
            {
                client.Transmit(bus.ToString());
            });

            /// Log that Client disconnects
            ServerUtility.Log(this.ServerLogBox, string.Format("Send to Clients : {0}", bus.ToString()));
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            /// close all the clients that are connected with the server
            base.OnClosing(e);
        }

    }
}

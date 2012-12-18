namespace BusTerminalMonitoringClientApp
{
    using System.Windows.Forms;
    using BusTerminalMonitoringClientApp.Connection;

    public partial class MainForm : Form
    {
        /// <summary>
        /// private instance client connection
        /// </summary>
        private ClientConnection connection = default(ClientConnection);
        /// <summary>
        /// constructor for this MainForm partial class
        /// </summary>
        public MainForm()
        {
            /// built-in method
            InitializeComponent();
        }
        /// <summary>
        /// EventHandler method
        /// this will triggers whenever the form has been loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, System.EventArgs e)
        {
            /// set initial map TargetURL
            /// Load URL
            this.WebViewControl.LoadURL(FormUtility.GoogleMapUrl);
            /// Set Client connection
            /// connect to server ip and port
            /// ex.: "10.1.2.234", 8000
            this.connection = new ClientConnection("localhost", 8000);
            /// set eventhandlers
            this.connection.TransmitEvent += new TransmittedDataEventHandler(connection_TransmitEvent);
            this.connection.DisconnectedEvent += new DisconnectEventHandler(connection_DisconnectedEvent);
            this.connection.ErrorEvent += new ErrorEventHandler(connection_ErrorEvent);
            /// start connection
            this.connection.EstablishConnection();
        }
        /// <summary>
        /// EventHandler method
        /// this will trigger whenever an error occured in the connection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void connection_ErrorEvent(object sender, Connection.Event.ConnectionErrorEventArgs e)
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
        /// EventHandler method.
        /// this will trigger whenever the connection disconnects from the server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void connection_DisconnectedEvent(object sender, System.EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                /// dispose resources
                this.connection.Dispose();
                this.Close();
            });
        }
        /// <summary>
        /// EventHandler method
        /// this will triggers whenever the sender sends transmit data action 
        /// process web view TargetURL
        /// Load Url
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void connection_TransmitEvent(object sender, Connection.Event.TransmitEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                /// Load url whenever e is not equal to TargetURL
                if (string.Compare(this.WebViewControl.Source.AbsoluteUri, e.ToString(), true) != 0)
                    this.WebViewControl.LoadURL(e.ToString()); 
            });
        }
        /// <summary>
        /// Dispose the resources used first. before closing the application
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            this.connection.Transmit(string.Format("action={0}", ActionType.Diconnect.ToString()));
            /// dispose
            this.connection.Dispose();
            base.OnClosing(e);
        }
    }
}

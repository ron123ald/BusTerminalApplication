namespace BusTerminalMonitoringClientApp
{
    using System.Windows.Forms;
    using BusTerminalMonitoringClientApp.Connection;

    public partial class MainForm : Form
    {
        private ClientConnection connection = default(ClientConnection);
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            this.WebViewControl.LoadURL(FormUtility.GoogleMapUrl);

            this.connection = new ClientConnection("localhost", 8000);
            this.connection.TransmitEvent += new TransmittedDataEventHandler(connection_TransmitEvent);
            this.connection.DisconnectedEvent += new DisconnectEventHandler(connection_DisconnectedEvent);
            this.connection.EstablishConnection();
        }

        private void connection_DisconnectedEvent(object sender, System.EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.connection.Dispose();
                this.Close();
            });
        }

        private void connection_TransmitEvent(object sender, Connection.Event.TransmitEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.WebViewControl.LoadURL(e.ToString());
            });
        }
    }
}

namespace BusTerminalServerApp
{
    using System.IO.Ports;
    using System.Windows.Forms;

    public partial class Main : Form
    {
        private SerialPort serial = default(SerialPort);
    
        public Main()
        {
            InitializeComponent();
        }

        #region Main Form EventHandlers
        private void Main_Load(object sender, System.EventArgs e)
        {
            /// Initialize serial 
            /// Look for the GSM's ComPort
            this.serial = new SerialPort("COM1", 8000, Parity.None, 0, StopBits.One);
            this.serial.DataReceived += new SerialDataReceivedEventHandler(serial_DataReceived);
        }
        
        private void Main_Shown(object sender, System.EventArgs e)
        {
        } 
        #endregion

        #region Serial Port Eventhandler
        /// <summary>
        /// this method will received all the data from the serial comport
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
        }
        #endregion
    }
}

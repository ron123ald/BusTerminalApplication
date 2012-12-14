namespace BusTerminalServer
{
    using System;
    using System.Windows.Forms;
    using System.IO.Ports;

    public partial class MainForm : Form
    {
        /// <summary>
        /// SerialPort Global declaration
        /// </summary>
        private SerialPort serial = default(SerialPort);
        /// <summary>
        /// Constructor of this Main Form
        /// </summary>
        public MainForm()
        {
            /// Internal Method ( auto generated );
            InitializeComponent();
        }
        /// <summary>
        /// this is an EventHandler method.
        /// that triggers whenever the Main Form is Running
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_Load(object sender, EventArgs e)
        {
            /// Set DateTimer's Interval property to 100 Milliseconds
            this.DateTimer.Interval = 100;
            /// Starts the DateTimer ( System.Windows.Forms.Timer )
            /// to Start Setting the current date of the program
            this.DateTimer.Start();
        }
        /// <summary>
        /// this is an EventHandler method
        /// this will trigger whenever you click on Menu File->Configuration Option
        /// A new Form will pop-up. your serial configuration will be base from the inputs 
        /// on the new form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /// this will run through, once the serial instance is Null
            if (this.serial == default(SerialPort))
            {
                ConfigurationForm config = new ConfigurationForm();
                DialogResult result = config.ShowDialog();
                /// If Dialog Result is Ok
                /// Initialize Serial Port base from fields of ConfigurationForm
                if (result == DialogResult.OK)
                {
                    /// Call InitializeSerialPort through Action
                    /// this is an Asynchronous call of a method.
                    /// means, this will never run in Main thread 
                    /// instead this will run in a separate thread
                    System.Action action = (() => InitializeSerialPort(config.PortName, config.BaudRate, config.Parity, config.StopBits));
                    /// invoke action
                    action.Invoke();
                    /// Close the ConfigurationForm Instance
                    config.Close(); 
                }
                /// Show Warning message
                /// Close the Program
                else
                {

                }
            }
        }
        /// <summary>
        /// this is an EventHandler method
        /// this will trigger whenever you click on Menu File->Exit Option
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /// Close the Application
            this.Close();
        }
        /// <summary>
        /// this is an EventHandler Method.
        /// this will trigger every 100 milliseconds and 
        /// set the DateTimeLabel's value text to the 
        /// current time base on your System unit's date and time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateTimer_Tick(object sender, EventArgs e)
        {
            /// Set the DateTimeLabel Component to the current Date and Time value
            this.DateTimeLabel.Text = DateTime.Now.ToString();

            if (this.serial != null && this.serial.IsOpen)
            {
                string data = this.serial.ReadLine();
            }
        }
        /// <summary>
        /// Initialize SerialPort
        /// </summary>
        /// <param name="portname">Name of the Port</param>
        /// <param name="baudrate"></param>
        /// <param name="parity"></param>
        /// <param name="stopbits"></param>
        private void InitializeSerialPort(string portname, int baudrate, Parity parity, StopBits stopbits)
        {
            /// Initialize Serial by Params
            this.serial = new SerialPort();
            /// set portname property
            this.serial.PortName = portname;
            /// set baudrate property
            this.serial.BaudRate = baudrate;
            /// set parity property
            this.serial.Parity = parity;
            /// set stopbits property
            this.serial.StopBits = stopbits;
            /// Open SerialPort Instance
            this.serial.Open();
            /// Initialize SerialPort EventHandlers
            /// serial DataReceived
            this.serial.DataReceived += new SerialDataReceivedEventHandler(serial_DataReceived);
        }
        /// <summary>
        /// Data Received from Serial Communication Port
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
        }
    }
}

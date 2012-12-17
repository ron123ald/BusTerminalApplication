namespace BusTerminalMonitoringServerApp.Serial
{
    using System;
    using System.ComponentModel;
    using System.IO.Ports;
    using BusTerminalMonitoringServerApp.Serial.Event;

    public delegate void NewMessageEventHandler(object sender, NewMessageEventArgs e);

    public class SerialConnection : IDisposable
    {
        private string portname = string.Empty;
        private int baudrate = 0;
        private Parity parity = default(Parity);
        private StopBits stopbits = default(StopBits);
        private BackgroundWorker worker = default(BackgroundWorker);
        private SerialPort serial = default(SerialPort);
        public event NewMessageEventHandler NewMessageEvent;

        private SerialConnection()
        {
            this.worker = new BackgroundWorker();
            this.worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            this.worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
        }

        public SerialConnection(string portname, int baudrate, Parity parity, StopBits stopbits) : this()
        {
            this.portname = portname;
            this.baudrate = baudrate;
            this.parity   = parity;
            this.stopbits = stopbits;
        }

        public void EstablistConnection()
        {
            this.serial = new SerialPort
                {
                    PortName = this.portname,
                    BaudRate = this.baudrate,
                    Parity = this.parity,
                    DataBits = 8,
                    StopBits = this.stopbits
                };
            this.serial.Open();
            this.connect();
            this.worker.RunWorkerAsync();
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            int index = 0;
            string datarecieved = string.Empty;
            string at_cmgr = "AT+CMGR=";
            string at_cmgd = "AT+CMGD=";
            NewMessageEventArgs newmessage = new NewMessageEventArgs();
            
            while (true)
            {
                try
                {
                    /// Reading data from serial
                    datarecieved = this.serial.ReadExisting();
                    if (!string.IsNullOrEmpty(datarecieved) && datarecieved.Contains("+CMTI: \"SM\","))
                    {
                        /// Get index of the message
                        index = int.Parse(datarecieved.Replace("\r\n+CMTI: \"SM\",", "").Replace("\r\n", ""));
                        /// Read Message base from index of inbox
                        Write(at_cmgr + index.ToString());
                        /// Wait for 500 milliseconds
                        System.Threading.Thread.Sleep(500);
                        /// publish EventHandler
                        NewMessageEvent(this, new NewMessageEventArgs(this.serial.ReadExisting()));
                        /// Delete messages base from index of inbox
                        Write(at_cmgd + index.ToString());
                    }
                }
                catch
                {

                }
            }
        }

        private void connect()
        {
            string at = "AT";
            string at_cmgf = "AT+CMGF=1";
            string at_cpms_me = "AT+CPMS=\"SM\"";
            bool flag = true;
            while (flag)
            {
                this.Write(at);
                /// wait for 500 milliseconds
                System.Threading.Thread.Sleep(500);
                if ((this.serial.ReadExisting()).ToLower().Contains("ok"))
                {
                    this.Write(at_cmgf);
                    /// wait for 500 milliseconds
                    System.Threading.Thread.Sleep(500);
                    if ((this.serial.ReadExisting()).ToLower().Contains("ok"))
                    {
                        this.Write(at_cpms_me);
                        /// wait for 500 milliseconds
                        System.Threading.Thread.Sleep(500);
                        if ((this.serial.ReadExisting()).ToLower().Contains("ok"))
                            flag = false;
                    }
                }
            }
        }

        public void Write(string data)
        {
            this.serial.Write(data + Environment.NewLine);
        }

        public string PortName
        {
            get { return this.portname; }
        }

        public int Baudrate
        {
            get { return this.baudrate; }
        }

        public Parity Parity
        {
            get { return this.parity; }
        }

        public StopBits StopBits
        {
            get { return this.stopbits; }
        }

        public void Dispose()
        {
            this.serial.Close();
            this.serial.Dispose();
        }
    }
}
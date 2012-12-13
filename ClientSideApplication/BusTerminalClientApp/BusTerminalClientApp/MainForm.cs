namespace BusTerminalClientApp
{
    using System;
    using System.Configuration;
    using System.Threading;
    using System.Windows.Forms;

    public partial class MainForm : Form
    {
        private Thread startbrowser = default(Thread);

        public MainForm()
        {
            InitializeComponent();
            
            this.startbrowser = new Thread(StartNavigation);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.startbrowser.Start();
        }

        private void StartNavigation()
        {
            //this.ClientWebBrowser.Navigate("http://localhost/googlemap/#10.296781234567&123.88991234567&Bus Information services Plate number GHV294");
            //this.ClientWebBrowser.Navigate(string.Format("{0}#10.29678&123.8899&Bus Information services Plate number GHV294", ConfigurationManager.AppSettings.Get("URL")));
        }

        private void BrowerTimer_Tick(object sender, EventArgs e)
        {
            //string[] hashvalue = (this.ClientWebBrowser.Url.AbsoluteUri.Split('#')[1]).Split('&');
            //string lattitude = (double.Parse(hashvalue[0]) + .000000000001).ToString();
            //string longitude = (double.Parse(hashvalue[1]) - .000000000001).ToString();
            //string busdetail = hashvalue[2];
        }

        /*
         * +------------------------+ 
         * | tbl_Bus                |
         * +------------------------+
         * | PK | bus_id            |
         * +------------------------+
         * | bus_plate_number       |
         * | bus_capacity           |
         * | bus_occupied           |
         * | bus_vacant             |
         * | bus_update_time        |
         * +------------------------+
         * 
         * GPS data to GSM
         * 
         * in JSON format
         * data = {
         *          "bus_plate_number": "GHV294",
         *          "lattitude": "10.296781234567",
         *          "longitude": "123.88991234567",
         *          "capacity": "30",
         *          "vacant": "16"
         *        }
         * 
         */
    }
}

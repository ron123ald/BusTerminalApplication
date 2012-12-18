namespace BusTerminalMonitoringClientApp.Connection.Event
{
    using System;

    public class TransmitEventArgs : EventArgs
    {
        private string _bus_number = string.Empty;
        private string _lattitude = string.Empty;
        private string _longitude = string.Empty;
        private string _capacity = string.Empty;
        private string _vacancy = string.Empty;
        private string _occupied = string.Empty;

        public TransmitEventArgs()
        {
        }

        public TransmitEventArgs(string data)
        {
            /// bus_number=GHV359;lattitude=;longitude=;capacity=;vacancy=;occupied=;details=;action=Transmit
            string[] separated = data.Split(';');
            this.BusNumber = separated[0].Split('=')[1];
            this.Lattitude = separated[1].Split('=')[1];
            this.Longitude = separated[2].Split('=')[1];
            this.Capacity = separated[3].Split('=')[1];
            this.Vacancy = separated[4].Split('=')[1];
            this.Occupied = separated[5].Split('=')[1];
        }

        public string Lattitude
        {
            set { this._lattitude = value; }
            get { return this._lattitude; }
        }

        public string Longitude
        {
            set { this._longitude = value; }
            get { return this._longitude; }
        }

        public string Capacity
        {
            set { this._capacity = value; }
            get { return this._capacity; }
        }

        public string Vacancy
        {
            set { this._vacancy = value; }
            get { return this._vacancy; }
        }

        public string Occupied
        {
            set { this._occupied = value; }
            get { return this._occupied; }
        }

        public string Details
        {
            get { return string.Format("Bus {0} has {1} vacant with {2} passengers occupied", this._bus_number, this._vacancy, this._occupied); }
        }

        public string BusNumber
        {
            set { this._bus_number = value; }
            get { return this._bus_number; }
        }

        /// <summary>
        /// http://localhost:8080/BusMonitoringSystem/#800-23&10.232323&123.4343434&Series Bus Liner GVDHE23232&30&18&12
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string data = string.Empty;
            data = string.Format("{0}#{1}&{2}&{3}&{4}&{5}&{6}&{7}"
                , FormUtility.GoogleMapUrl
                , this.BusNumber
                , this.Lattitude
                , this.Longitude
                , this.Details
                , this.Occupied
                , this.Vacancy
                , this.Capacity
                );
            return data;
        }
    }
}

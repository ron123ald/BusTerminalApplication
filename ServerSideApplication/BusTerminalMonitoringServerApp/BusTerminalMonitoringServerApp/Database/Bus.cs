namespace BusTerminalMonitoringServerApp.Database
{
    using BusTerminalMonitoringServerApp.Connection;

    public class Bus
    {
        private string _bus_number = string.Empty;
        private string _lattitude = string.Empty;
        private string _longitude = string.Empty;
        private string _capacity = string.Empty;
        private string _vacancy = string.Empty;
        private string _occupied = string.Empty;
        private string _details = string.Empty;
        private ActionType _action = default(ActionType);
        public Bus()
        {
        }

        public Bus(string bus_number, string lattitude, string longitude, string capacity, string vacancy, string occupied, string details, ActionType action)
        {
            this._bus_number = bus_number;
            this._lattitude = lattitude;
            this._longitude = longitude;
            this._capacity = capacity;
            this._vacancy = vacancy;
            this._occupied = occupied;
            this._details = details;
            this._action = action;
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
            set { this._details = value; }
            get { return this._details; }
        }

        public string BusNumber
        {
            set { this._bus_number = value; }
            get { return this._bus_number; }
        }

        public ActionType Action
        {
            set { this._action = value; }
            get { return this._action; }
        }

        public override string ToString()
        {
            string data = string.Empty;
            data = string.Format("bus_number={0};lattitude={1};longitude={2};capacity={3};vacancy={4};occupied={5};details={6};action={7}"
                , _bus_number
                , _lattitude
                , _longitude
                , _capacity
                , _vacancy
                , _occupied
                , _details
                , _action.ToString());
            return data;
        }
    }
}
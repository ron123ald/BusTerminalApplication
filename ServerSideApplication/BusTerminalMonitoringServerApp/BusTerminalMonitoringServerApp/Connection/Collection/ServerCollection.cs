namespace BusTerminalMonitoringServerApp.Connection.Collection
{
    using System.Collections.Generic;

    public class ServerCollection
    {
        /// <summary>
        /// Key Value container
        /// Key     = Bus plate number
        /// Value   = ClientConnection
        /// </summary>
        List<ClientConnection> collection = default(List<ClientConnection>);
        /// <summary>
        /// private Instance of Server Collection 
        /// SingleTon Design
        /// </summary>
        private static ServerCollection _instance = default(ServerCollection);
        private ServerCollection()
        {
            /// create new Instance of Dictionary 
            this.collection = new List<ClientConnection>();
        }
        /// <summary>
        /// Property: public Instance of ServerCollection
        /// SingleTon Design
        /// </summary>
        public static ServerCollection InstanceContext
        {
            get 
            {
                /// Check if _instance is Null
                if (_instance == default(ServerCollection))
                    /// create new Instance of ServerCollection
                    _instance = new ServerCollection();
                /// return Instance
                return _instance;
            }
        }
        /// <summary>
        /// Add client instance to Collection
        /// by passing platenumber as key 
        /// and client instance as value
        /// </summary>
        /// <param name="platenumber"></param>
        /// <param name="client"></param>
        public void Add(ClientConnection client)
        {
            /// check if (key) platenumber is not in the collection
            if (!this.collection.Contains(client))
                /// add clientconnection to collection
                this.collection.Add(client);
        }
        /// <summary>
        /// retrieves client connection from Collection
        /// by passing platenumber params
        /// </summary>
        /// <returns>List ClientConnection Instance</returns>
        public List<ClientConnection> Get()
        {
            /// return all records
            return this.collection;
        }
        /// <summary>
        /// removes client connection from the collection
        /// by passing platenumber.
        /// </summary>
        /// <param name="client">key of client connection to remove</param>
        public void Remove(ClientConnection client)
        {
            /// check if client is not Null
            if (client != null)
                /// remove clientconnection Instance in collection
                this.collection.Remove(client); 
        }
    }
}

namespace BusTerminalMonitoringServerApp.Connection
{
    public static class ServerUtility
    {
        /// <summary>
        /// return Action type base from the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ActionType GetActionType(string data)
        {
            ActionType type = default(ActionType);

            if (data.Contains("request_connection"))
                type = ActionType.RequestConnection;
            else if (data.Contains("transmit"))
                type = ActionType.Transmit;
            else if (data.Contains("request_disconnection"))
                type = ActionType.RequestDisconnection;
            else if (data.Contains("ping"))
                type = ActionType.Ping;
            else if (data.Contains("pong"))
                type = ActionType.Pong;
            else
                type = ActionType.Unknown;
            return type;
        }
    }
}
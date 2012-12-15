namespace BusTerminalMonitoringServerApp.Connection
{
    public static class ServerUtility
    {
        public static ActionType GetActionType(string data)
        {
            ActionType type = default(ActionType);
            if (data.Contains("request_connection"))
                type = ActionType.RequestConnection;
            else if (data.Contains("transmit"))
                type = ActionType.Transmit;
            else if (data.Contains("client_application_start"))
                type = ActionType.ClientApplicationStart;
            else if (data.Contains("client_application_stop"))
                type = ActionType.ClientApplicationStop;
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
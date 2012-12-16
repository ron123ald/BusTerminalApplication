using System.Collections.Generic;
namespace BusTerminalMonitoringClientApp.Connection
{
    public static class FormUtility
    {
        public static string GoogleMapUrl
        {
            get { return "http://localhost/BusMonitoringSystem/"; }
        }
        /// <summary>
        /// return Action type base from the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ActionType GetActionType(string data)
        {
            ActionType type = default(ActionType);

            if (data.ToLower().Contains("request_connection"))
                type = ActionType.RequestConnection;
            else if (data.ToLower().Contains("transmit"))
                type = ActionType.Transmit;
            else if (data.ToLower().Contains("request_disconnection"))
                type = ActionType.RequestDisconnection;
            else if (data.ToLower().Contains("ping"))
                type = ActionType.Ping;
            else if (data.ToLower().Contains("pong"))
                type = ActionType.Pong;
            else
                type = ActionType.Unknown;
            return type;
        }

    }

    public enum ActionType
    {
        RequestConnection,
        Transmit,
        RequestDisconnection,
        Ping,
        Pong,
        Unknown
    }
}
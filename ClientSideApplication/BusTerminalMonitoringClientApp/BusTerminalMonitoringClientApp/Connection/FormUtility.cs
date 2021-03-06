﻿namespace BusTerminalMonitoringClientApp.Connection
{
    using System.Collections.Generic;
    using System.Configuration;

    public static class FormUtility
    {
        public static string GoogleMapUrl
        {
            get { return ConfigurationManager.AppSettings.Get("GoogleMap"); }
        }
        /// <summary>
        /// return Action type base from the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ActionType GetActionType(string data)
        {
            ActionType type = default(ActionType);

            if (data.ToLower().Contains("transmit"))
                type = ActionType.Transmit;
            else if (data.ToLower().Contains("diconnect"))
                type = ActionType.Diconnect;
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
        Transmit,
        Diconnect,
        Ping,
        Pong,
        Unknown
    }
}
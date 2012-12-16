namespace BusTerminalMonitoringServerApp.Connection
{
    using System;
    using System.Windows.Forms;

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

        /// <summary>
        /// Logger to be able to see the events and operations in the server
        /// </summary>
        /// <param name="control"></param>
        /// <param name="message"></param>
        public static void Log(Control control, string message)
        {
            /// Invoke the message to the controll
            /// http://msdn.microsoft.com/en-us/library/system.windows.forms.methodinvoker.aspx
            control.Invoke(((MethodInvoker)delegate
            {
                control.Text += string.Format("\r\n[{0}] {1}", DateTime.Now.ToString("MM-dd-yy hh:mm:ss"), message);
            }));
        }
    }
}
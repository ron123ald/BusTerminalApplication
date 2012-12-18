namespace BusTerminalMonitoringServerApp.Connection
{
    using System;
    using System.Windows.Forms;
    using BusTerminalMonitoringServerApp.Database;

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

            if (data.Contains("transmit"))
                type = ActionType.Transmit;
            else if (data.Contains("request_disconnection"))
                type = ActionType.Diconnect;
            else if (data.Contains("ping"))
                type = ActionType.Ping;
            else if (data.Contains("pong"))
                type = ActionType.Pong;
            else
                type = ActionType.Unknown;
            return type;
        }

        /// <summary>
        /// Parse data to Bus object
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Bus ParseData(string data)
        {
            Bus bus = default(Bus);
            data = data.Replace("{", "").Replace("}", "").Replace("\"", "");
            string[] splittedbycomma = data.Split(',');
       
            bus = new Bus
            {
                Action = ActionType.Transmit,
                BusNumber = splittedbycomma[0].Split(':')[1],
                Lattitude = splittedbycomma[1].Split(':')[1],
                Longitude = splittedbycomma[2].Split(':')[1],
                Capacity = splittedbycomma[3].Split(':')[1],
                Vacancy = splittedbycomma[4].Split(':')[1],
                Occupied = splittedbycomma[5].Split(':')[1],
                Details = splittedbycomma[6].Split(':')[1]
            };
            return bus;
        }

        /// <summary>
        /// Logger to be able to see the events and operations in the server
        /// </summary>
        /// <param name="control"></param>
        /// <param name="message"></param>
        public static void Log(RichTextBox control, string message)
        {
            string formatted = string.Format("\r\n[{0}] {1}", DateTime.Now.ToString("MM-dd-yy hh:mm:ss"), message);
            /// Invoke the message to the controll
            /// http://msdn.microsoft.com/en-us/library/system.windows.forms.methodinvoker.aspx
            if (!control.IsDisposed)
            {
                if (!control.InvokeRequired)
                {
                    control.AppendText(formatted);
                    control.ScrollToCaret();
                }
                else
                {
                    control.Invoke(((MethodInvoker)delegate
                    {
                        control.AppendText(formatted);
                        control.ScrollToCaret();
                    }));
                } 
            }
        }
    }
}
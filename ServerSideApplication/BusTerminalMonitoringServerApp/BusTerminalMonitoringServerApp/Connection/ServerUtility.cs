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

        /// <summary>
        /// Parse data to Bus object
        /// ("bus_number"&"lattitude"&"longitude"&"capacity"&"vacant"&"occupied"&"details)
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Bus ParseData(string data)
        {
            string substringdata = data.Substring(data.IndexOf("("));
            string substringremove = substringdata.Substring(substringdata.IndexOf(")"));

            substringdata = substringdata.Replace("(","").Replace(substringremove, "");
            string[] splittedbycomma = substringdata.Split('&');

            Bus bus = new Bus
            {
                Action = ActionType.Transmit,
                BusNumber = splittedbycomma[0],
                Lattitude = splittedbycomma[1],
                Longitude = splittedbycomma[2],
                Capacity = splittedbycomma[3],
                Vacancy = splittedbycomma[4],
                Occupied = splittedbycomma[5],
                Details = splittedbycomma[6],
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
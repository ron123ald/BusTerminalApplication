namespace BusTerminalMonitoringServerApp.Connection
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Text;
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
            ILogger logger = Logger.InstanceContext;
            logger.LogToDisk(message, DateTime.Now);
        }

        public static bool IsPhoneNumberValid(this string phoneNumber)
        {
            bool flag = false;
            string phoneNumbers = ConfigurationManager.AppSettings.Get("GSM_NUMBERS");
            if (!string.IsNullOrEmpty(phoneNumber) && !string.IsNullOrEmpty(phoneNumbers))
            {
                foreach (string item in phoneNumbers.Split(','))
                {
                    if (item.Equals(phoneNumber))
                    {
                        flag = true;
                        break;
                    }
                }
            }
            return flag;
        }

        public static string GetPhoneNumber(this string message)
        {
            string phoneNumber = string.Empty;
            try
            {
                phoneNumber = message.Replace("\r\n+CMGR: \"REC UNREAD\",\"", "");
                if (phoneNumber.Contains("+63"))
                    phoneNumber = phoneNumber.Substring(3, 10);
                else if (phoneNumber.Contains("09"))
                    phoneNumber = phoneNumber.Substring(1, 10);
            }
            catch
            {
            }
            return phoneNumber;
        }

        public static string GenerateDocument(this List<Bus> bus, string startData, string endDate)
        {
            StringBuilder document = new StringBuilder();
            if (bus != null && bus.Count > 0)
            {
                document.Append("\r\n\r\n                      BUS MONITORING SYSTEM LOGS\r\n\r\n" + 
                                "Start date : " + startData + "\r\nEnd date   : " + endDate + "\r\n\r\n" +
                                "+===========================================================================+\r\n" +
                                "| ID  | NUMBER |   LAT   |   LONG   | CAP | VAC | OCC |      DATE/TIME      |\r\n" +
                                "+=====+========+=========+==========+=====+=====+=====+=====================+\r\n");
                foreach (Bus item in bus)
                {
                    document.Append("|" + ItemBuilder(item.ID, 5));
                    document.Append("|" + ItemBuilder(item.BusNumber, 9));
                    document.Append("|" + ItemBuilder(item.Lattitude, 9));
                    document.Append("|" + ItemBuilder(item.Longitude, 9));
                    document.Append("|" + ItemBuilder(item.Capacity, 5));
                    document.Append("|" + ItemBuilder(item.Vacancy, 5));
                    document.Append("|" + ItemBuilder(item.Occupied, 5));
                    document.Append("|" + ItemBuilder((DateTime.Parse(item.DateTime).ToString()), 21) + "|\r\n");
                    document.Append("+-----+--------+---------+----------+-----+-----+-----+---------------------+\r\n");
                }
            }
            return document.ToString();
        }

        public static string ItemBuilder(string data, int spaces)
        {
            string response = string.Empty;
            if (data.Length > spaces)
            {
                int diff = data.Length - spaces;
                response = RemoveExcess(data, diff);
            }
            else if (data.Length < spaces)
            {
                int diff = spaces - data.Length;
                response = data + AddEmptySpaces(diff);
            }
            else
            {

            }



            return response;
        }

        private static string AddEmptySpaces(int noOfSpaces)
        {
            string spaces = "";
            for (int i = 0; i < noOfSpaces; i++)
            {
                spaces += ' ';
            }
            return spaces;
        }

        public static string RemoveExcess(string data, int noOfExcess)
        {
            string response = string.Empty;
            for (int i = 0; i < data.Length-noOfExcess; i++)
            {
                response += data[i];
            }
            return response;
        }
    }
}
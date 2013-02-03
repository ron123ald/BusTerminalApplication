namespace BusTerminalMonitoringServerApp.Connection
{
    using System;
using System.Collections.Generic;
using System.Configuration;
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

        public static string GenerateDocument(this List<Bus> bus)
        {
            string document = string.Empty;
            if (bus != null && bus.Count > 0)
            {

            }
            return document;
        }
    }
}
namespace Skyline.DataMiner.Utils.Alarms.Protocol
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Alarm class from the SLProtocolScripts DLL.
    /// </summary>
    public class Alarm
    {
        /// <summary>
        /// Creates new alarm.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="value">The value.</param>
        /// <param name="severity">The severity.</param>
        /// <returns>String array that needs to be passed along to a NotifyDataMiner(106) call.</returns>
        public string[] NewAlarm(int element, int parameter, string value, string severity)
        {
            string code = GetCode(severity);
            string[] strArray =
            {
                "30",
                GetTime(),
                code,
                "5",
                value,
                "0",
                "10",
                code == "13" ? "11" : "12",
                element.ToString(),
                parameter.ToString()
            };
            return strArray;
        }

        /// <summary>
        /// Creates new alarmtable.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="value">The value.</param>
        /// <param name="severity">The severity.</param>
        /// <param name="index">The index.</param>
        /// <returns>String array that needs to be passed along to a NotifyDataMiner(106) call.</returns>
        public string[] NewAlarmTable(int element, int parameter, string value, string severity, string index)
        {
            string code = GetCode(severity);
            string[] strArray =
            {
                "30",
                GetTime(),
                code,
                "5",
                value,
                "0",
                "10",
                code == "13" ? "11" : "12",
                element.ToString(),
                parameter.ToString(),
                "0",
                "",
                "0",
                "",
                "",
                index
            };
            return strArray;
        }

        /// <summary>
        /// Adds the alarm.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="value">The value.</param>
        /// <param name="severity">The severity.</param>
        /// <param name="rootKey">The root key.</param>
        /// <returns>String array that needs to be passed along to a NotifyDataMiner(106) call.</returns>
        public string[] AddAlarm(int element, int parameter, string value, string severity, int rootKey)
        {
            string code = GetCode(severity);
            string[] strArray = 
            {
                "30",
                GetTime(),
                code,
                "5",
                value,
                "0",
                "10",
                code == "13" ? "11" : "12",
                element.ToString(),
                parameter.ToString(),
                "0",
                rootKey.ToString()
            };
            return strArray;
        }

        /// <summary>
        /// Adds the alarm table.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="value">The value.</param>
        /// <param name="severity">The severity.</param>
        /// <param name="rootKey">The root key.</param>
        /// <param name="index">The index.</param>
        /// <returns>String array that needs to be passed along to a NotifyDataMiner(106) call.</returns>
        public string[] AddAlarmTable(int element, int parameter, string value, string severity, int rootKey, string index)
        {
            string code = GetCode(severity);
            string[] strArray =
            {
                "30",
                GetTime(),
                code,
                "5",
                value,
                "0",
                "10",
                code == "13" ? "11" : "12",
                element.ToString(),
                parameter.ToString(),
                "0",
                rootKey.ToString(),
                "0",
                "",
                "",
                index
            };
            return strArray;
        }

        private static string GetCode(string severity)
        {
            string upper = severity.ToUpper();
            string code = "";
            switch (upper)
            {
                case "CRITICAL":
                    code = "1";
                    break;
                case "MAJOR":
                    code = "2";
                    break;
                case "MINOR":
                    code = "3";
                    break;
                case "WARNING":
                    code = "4";
                    break;
                case "NORMAL":
                    code = "5";
                    break;
                case "HIGH":
                    code = "6";
                    break;
                case "LOW":
                    code = "7";
                    break;
                case "ESCALATED":
                    code = "8";
                    break;
                case "DROPPED":
                    code = "9";
                    break;
                case "NEW ALARM":
                    code = "10";
                    break;
                case "CLEARED":
                    code = "11";
                    break;
                case "OPEN":
                    code = "12";
                    break;
                case "INFORMATION":
                    code = "13";
                    break;
                case "DATAMINER":
                    code = "16";
                    break;
                case "TIMEOUT":
                    code = "17";
                    break;
                case "ERROR":
                    code = "24";
                    break;
                case "NOTICE":
                    code = "28";
                    break;
                case "EXTERNAL":
                    code = "30";
                    break;
            }

            return code;
        }

        private static string GetTime()
        {
            return DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture);
        }
    }
}
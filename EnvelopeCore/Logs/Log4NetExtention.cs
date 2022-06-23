using log4net;
using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Logs
{
    public static class Log4NetExtention
    {
        private static readonly Level logicLevel = new Level(50000, "LOGIC");

        private static readonly Level osLevel = new Level(60000, "OS");

        public static void Logic(this ILog log, string message)
        {
            log.Logger.Log(MethodBase.GetCurrentMethod().DeclaringType, logicLevel, message, null);
        }

        public static void LogicFormat(this ILog log, string message, params object[] args)
        {
            string message2 = string.Format(message, args);
            log.Logger.Log(MethodBase.GetCurrentMethod().DeclaringType, logicLevel, message2, null);
        }

        public static void OS(this ILog log, string message)
        {
            log.Logger.Log(MethodBase.GetCurrentMethod().DeclaringType, osLevel, message, null);
        }

        public static void OSFormat(this ILog log, string message, params object[] args)
        {
            string message2 = string.Format(message, args);
            log.Logger.Log(MethodBase.GetCurrentMethod().DeclaringType, osLevel, message2, null);
        }
    }
}

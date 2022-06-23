using log4net;
using log4net.Config;
using System.Reflection;

namespace Logs
{
    public static class Log
    {
        private static ILog Logger;

        public static bool EnableConsole { get; set; }

        static Log()
        {
            Logger = null;
            EnableConsole = false;
            XmlConfigurator.Configure(new FileInfo("log4net.config"));
            Logger = LogManager.GetLogger("Logs");
        }

        //
        // 摘要:
        //     业务信息
        //
        // 参数:
        //   format:
        //
        //   args:
        public static void Info(string message, params object[] args)
        {
            if (args == null || args.Length == 0)
            {
                Logger.Info(message);
            }
            else
            {
                Logger.InfoFormat(message, args);
            }

            if (EnableConsole)
            {
                Console.WriteLine("{0} [{1}] Console - {2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,fff"), Thread.CurrentThread.ManagedThreadId, string.Format(message, args));
            }
        }

        //
        // 摘要:
        //     异常日志
        //
        // 参数:
        //   format:
        //
        //   args:
        public static void Error(string message, params object[] args)
        {
            if (args == null || args.Length == 0)
            {
                Logger.Error(message);
            }
            else
            {
                Logger.ErrorFormat(message, args);
            }
        }

        //
        // 摘要:
        //     异常日志
        //
        // 参数:
        //   format:
        //
        //   args:
        public static void Exception(string message, Exception exception)
        {
            Logger.Error(message, exception);
            Exception[] array = null;
            if (exception.InnerException != null)
            {
                array = new Exception[1] { exception.InnerException };
            }

            if (exception is AggregateException)
            {
                array = (exception as AggregateException).InnerExceptions.ToArray();
            }
            else if (exception is ReflectionTypeLoadException)
            {
                array = (exception as ReflectionTypeLoadException).LoaderExceptions;
            }

            if (array != null)
            {
                Exception[] array2 = array;
                foreach (Exception exception2 in array2)
                {
                    Exception("InnerException", exception2);
                }
            }
        }

        //
        // 摘要:
        //     调试信息
        //
        // 参数:
        //   format:
        //
        //   args:
        public static void Debug(string message, params object[] args)
        {
            if (args == null || args.Length == 0)
            {
                Logger.Debug(message);
            }
            else
            {
                Logger.DebugFormat(message, args);
            }
        }

        //
        // 摘要:
        //     Windows事件
        //
        // 参数:
        //   format:
        //
        //   args:
        public static void OS(string message, params object[] args)
        {
            if (args == null || args.Length == 0)
            {
                Logger.OS(message);
            }
            else
            {
                Logger.OSFormat(message, args);
            }
        }

        //
        // 摘要:
        //     业务日志
        //
        // 参数:
        //   format:
        //
        //   args:
        public static void Logic(string message, params object[] args)
        {
            if (args == null || args.Length == 0)
            {
                Logger.Logic(message);
            }
            else
            {
                Logger.LogicFormat(message, args);
            }
        }
    }
}
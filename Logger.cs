using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using log4net;

namespace LogExample
{
    public static class Logger
    {

        private static readonly string LOG_CONFIG_FILE = @"log4net.config";

        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger("TestLogger");

        public static void Debug(object message)
        {
            SetLog4NetConfiguration();
            _log.Debug(message);
            _log.Warn(message);
          
            _log.Info(message);
        }

        public static void WriteError(string message, Exception e)
        {
            SetLog4NetConfiguration();
            _log.Error(message,e);
        }

        private static void SetLog4NetConfiguration()
        {
            XmlDocument log4netConfig = new XmlDocument();
            log4netConfig.Load(File.OpenRead(LOG_CONFIG_FILE));

            var repo = LogManager.CreateRepository(
                Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));

            log4net.Config.XmlConfigurator.Configure(repo, log4netConfig["log4net"]);
        }
    }

}

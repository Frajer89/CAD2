using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAD_
{
    public static class Log
    {
        public static void Trace(string message)
        {
            File.AppendAllText("testlog.log", DateTime.Now.ToString() + "|TRACE|" + message + "\r\n");
        }
        public static void Debug(string message)
        {
            File.AppendAllText("testlog.log", DateTime.Now.ToString() + "|DEBUG|" + message + "\r\n");
        }
        public static void Info(string message)
        {
            File.AppendAllText("testlog.log", DateTime.Now.ToString() + "|INFO|" + message + "\r\n");
        }
        public static void Warn(string message)
        {
            File.AppendAllText("testlog.log", DateTime.Now.ToString() + "|WARN|" + message + "\r\n");
        }
        public static void Error(string message)
        {
            File.AppendAllText("testlog.log", DateTime.Now.ToString() + "|ERROR|" + message + "\r\n");
        }
        public static void Fatal(string message)
        {
            File.AppendAllText("testlog.log", DateTime.Now.ToString() + "|FATAL|" + message + "\r\n");
        }
    }
}

using System;
using System.IO;

namespace UsbCopier
{
    public static class Logger
    {
        private static object _locker = new object();

        public static string LogFile
        {
            get { return Path.Combine(Program.BaseDirectory, "copier-" + DateTime.Now.ToString("yyyyMMdd") + ".log"); }
        }

        public static void WriteLine(string message)
        {
            lock (_locker)
            {
                File.AppendAllText(LogFile, DateTime.Now.ToString() + ": " + message + Environment.NewLine);
            }
        }
    }
}

using System;

namespace SocketAsync.Service
{
    public class LogEventArgs : EventArgs
    {
        public string Log { get; set; }

        public LogEventArgs(string _log)
        {
            Log = _log;
        }
    }
}
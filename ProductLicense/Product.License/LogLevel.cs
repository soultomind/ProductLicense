using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    public class LogLevel
    {        
        public static readonly LogLevel Trace = new LogLevel("TRACE", 0);
        public static readonly LogLevel Debug = new LogLevel("DEBUG", 1);
        public static readonly LogLevel Info = new LogLevel("INFO", 2);
        public static readonly LogLevel Warn = new LogLevel("WARN", 3);
        public static readonly LogLevel Error = new LogLevel("ERROR", 4);
        public static readonly LogLevel Fatal = new LogLevel("FATAL", 5);
        public static readonly LogLevel Off = new LogLevel("Off", 6);

        private static readonly IList<LogLevel> allLevels = 
            new List<LogLevel> { Trace, Debug, Info, Warn, Error, Fatal, Off }.AsReadOnly();

        private static readonly IList<LogLevel> allLoggingLevels = 
            new List<LogLevel> { Trace, Debug, Info, Warn, Error, Fatal }.AsReadOnly();

        /// <summary>
        /// Gets all the available log levels (Trace, Debug, Info, Warn, Error, Fatal, Off).
        /// </summary>
        public static IEnumerable<LogLevel> AllLevels => allLevels;

        /// <summary>
        ///  Gets all the log levels that can be used to log events (Trace, Debug, Info, Warn, Error, Fatal)
        ///  i.e <c>LogLevel.Off</c> is excluded.
        /// </summary>
        public static IEnumerable<LogLevel> AllLoggingLevels => allLoggingLevels;

        internal static LogLevel MaxLevel => Fatal;

        internal static LogLevel MinLevel => Trace;

        private readonly int _ordinal;
        private readonly string _name;

        private LogLevel(string name, int ordinal)
        {
            _name = name;
            _ordinal = ordinal;
        }

        public string Name => _name;

        public int Ordinal => _ordinal;

        public static LogLevel FromOrdinal(int ordinal)
        {
            switch (ordinal)
            {
                case 0:
                    return Trace;
                case 1:
                    return Debug;
                case 2:
                    return Info;
                case 3:
                    return Warn;
                case 4:
                    return Error;
                case 5:
                    return Fatal;
                case 6:
                    return Off;

                default:
                    throw new ArgumentException($"Unknown loglevel: {ordinal.ToString()}.", nameof(ordinal));
            }
        }
        public override string ToString()
        {
            return _name;
        }
    }
}

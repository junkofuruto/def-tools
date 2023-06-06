using System;
using System.Linq;

namespace Runas
{
    internal enum LogType
    {
        Warning     = ConsoleColor.Yellow,
        Error       = ConsoleColor.Red,
        Info        = ConsoleColor.Cyan,
    }

    internal static class Logger
    {
        public static void Post(string message)
        {
            Post(message, LogType.Info);
        }
        public static void Post(string message, LogType type) 
        {
            Console.ForegroundColor = (ConsoleColor) type;
            Console.WriteLine($"[{type.ToString().First()}] {message}");
            Console.ResetColor();
        }
    }
}

using System;

namespace Runas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                RunasArgumentObject obj = Shell.ParceArguments(args);
                Executer.Run(obj);
            }
            catch (Exception ex)
            {
                Logger.Post($"{ex.Message} {ex.InnerException?.Message}", LogType.Error);
            }
        }
    }
}

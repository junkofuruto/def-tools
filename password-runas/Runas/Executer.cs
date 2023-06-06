using System;
using System.Data.Odbc;
using System.Diagnostics;
using System.Security;

namespace Runas
{
    internal static class Executer
    {
        public static void Run(RunasArgumentObject args)
        {
            try
            {
                Logger.Post($"Executing: {args.Filename} {args.Arguments}");

                Process process = new Process();
                process.StartInfo.Verb = "runas";
                process.StartInfo.Domain = args.Domain;
                process.StartInfo.UserName = args.Username;
                process.StartInfo.Password = args.Password;
                process.StartInfo.FileName = args.Filename;
                process.StartInfo.Arguments = args.Arguments;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.Start();
                process.WaitForExit();

                string error = process.StandardError.ReadToEnd();
                string output = process.StandardOutput.ReadToEnd();

                if (process.ExitCode != 0)
                {
                    Logger.Post($"Runtime Error: program exited with code {process.ExitCode}", LogType.Error);
                }
                if (output != string.Empty)
                {
                    Logger.Post($"Output: {output}");
                }
                if (error != string.Empty)
                {
                    Logger.Post($"Runtime Error: {error}", LogType.Error);
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("Execution Error:", ex);
            }
        }
    }
}

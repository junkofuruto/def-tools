using System;
using System.Linq;
using System.Security;

namespace Runas
{
    internal static class Shell
    {
        public static RunasArgumentObject ParceArguments(string[] args)
        {
            if (args.Length < 2)
            {
                throw new Exception("Usage: runas.exe username@domain:password filename.exe ...");
            }
            RunasArgumentObject obj = new RunasArgumentObject();
            try
            {
                obj.Username = args[0].Split('@').First();
                obj.Password = ToSecureString(args[0].Split(':').Last());
                obj.Domain = args[0].Split('@').Last().Split(':').First();
                obj.Filename = args[1];
                obj.Arguments = string.Join(" ", args.Skip(2)).Replace('\'', '"');

                Logger.Post($"Running as {obj.Username}@{obj.Domain}...");
            }
            catch
            {
                throw new Exception("Invalid arguments");
            }
            return obj;
        }
        public static SecureString ToSecureString(string str)
        {
            if (str == null)
                return null;

            SecureString secureString = new SecureString();
            foreach (char c in str.ToCharArray())
            {
                secureString.AppendChar(c);
            }
            return secureString;
        }
    }
}

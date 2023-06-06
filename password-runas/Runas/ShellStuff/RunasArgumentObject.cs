using System.Security;

namespace Runas
{
    internal class RunasArgumentObject
    {
        public SecureString Password { get; set; }
        public string Username { get; set; }
        public string Filename { get; set; }
        public string Arguments { get; set; }
        public string Domain { get; set; }
    }
}

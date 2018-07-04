using System.Collections.Generic;

namespace xServer.Core.Commands
{
    /* THIS PARTIAL CLASS SHOULD CONTAIN VARIABLES NECESSARY FOR VARIOUS COMMANDS (if needed). */
    public static partial class CommandHandler
    {
        public static Dictionary<int, string> CanceledDownloads = new Dictionary<int, string>();
        public static Dictionary<int, string> RenamedFiles = new Dictionary<int, string>();
        private const string DELIMITER = ".";
    }
}
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace ProxyWebService.Classes
{
    public class BaseProcardRequestClass
    {
        public char __numberPaddingChar = ConfigurationManager.AppSettings["ProcardOperation_Alta_NumberPaddingChar"].First();
        public char __space = ' ';
        public string __operation__ { get; set; }
        string separator { get { return ConfigurationManager.AppSettings["ProcardMessageSeparator"]; } }
        string Username { get { return ConfigurationManager.AppSettings["ProcardUsername"]; } }
        string Password { get { return ConfigurationManager.AppSettings["ProcardPassword"]; } }

        /// <summary>
        /// Returns a string "{ProcardUsername}{ProcardMessageSeparator}{ProcardPassword}"
        /// </summary>
        public string ProcardCredentials { get { return string.Join(separator, Username, Password);} }

        /// <summary>
        /// Builds the message in the format "{operation}{ProcardMessageSeparator}{values added in set order with the set separator in "ProcardMessageSeparator" in the web.config file}"
        /// </summary>
        /// <param name="values"></param>
        /// <returns>stringf formatted to send to the PROCARD SOCKET</returns>
        public string BuildProcardMessage(params string[] values)
        {
            List<string> pcmsg = new List<string> { __operation__ };
            pcmsg.AddRange(values);
            return string.Join(separator, pcmsg);
        }

    }
}
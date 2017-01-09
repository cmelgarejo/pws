using ProxyWebService.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace ProxyWebService.Classes
{
    public class ProcardResponse
    {
        public bool success { get; set; }
        public string response_code { get; set; }
        public string response_message { get; set; }
        public string original_message { get; set; }
        public Dictionary<string, string> result { get; set; }
        IBaseProcardRequestClass _request;

        public ProcardResponse(IBaseProcardRequestClass request)
        {
            _request = request;
            success = false;
            response_code = ConfigurationManager.AppSettings["Procard_Response_Default"];
        }

        public ProcardResponse(IBaseProcardRequestClass request, string message)
        {
            _request = request;
            success = false;
            response_code = ConfigurationManager.AppSettings["Procard_Response_Default"];
            Parse(message);
        }

        public void Parse(string strMsg)
        {
            try
            {
                string[] split_result = strMsg.Split(ConfigurationManager.AppSettings["ProcardMessageSeparator"].ToCharArray());
                response_code = split_result.First().PadLeft(2, '0');
                if (split_result.Length > 1)
                    if (response_code == ConfigurationManager.AppSettings["Procard_Response_Accepted"] ||
                        _request.GetType() == typeof(ConsultaRequest))
                        success = true;
                response_message = ConfigurationManager.AppSettings[string.Format("Procard_Response_{0}", response_code)];
                original_message = strMsg;
                //if (success)
                result = _request.ResponseParams().Zip(split_result.Skip(1), (key, value) => new { key, value })
                                                 .ToDictionary(kv => kv.key, kv => kv.value);
            }
            catch (Exception ex)
            {
                response_code = ConfigurationManager.AppSettings["Procard_Response_Default"];
                success = false;
                original_message = ex.Message;
            }
        }
    }
}
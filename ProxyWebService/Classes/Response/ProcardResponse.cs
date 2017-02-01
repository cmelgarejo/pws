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
        public string original_procard_request { get; set; }
        public string original_procard_response { get; set; }
        public Dictionary<string, string> result { get; set; }
        IBaseProcardRequestClass _request;


        public ProcardResponse(IBaseProcardRequestClass request)
        {
            _request = request;
            original_procard_request = _request.ProcardMessage();
            success = false;
            response_code = ConfigurationManager.AppSettings["Procard_Response_Default"];
        }

        public ProcardResponse(IBaseProcardRequestClass request, string message)
        {
            _request = request;
            original_procard_request = _request.ProcardMessage();
            success = false;
            response_code = ConfigurationManager.AppSettings["Procard_Response_Default"];
            Parse(message);
        }

        public void Parse(string strMsg)
        {
            try
            {
                original_procard_response = strMsg;
                string[] split_result = strMsg.Split(ConfigurationManager.AppSettings["ProcardMessageSeparator"].ToCharArray());
                response_code = split_result.First().PadLeft(2, '0');
                if (split_result.Length > 1)
                {
                    if (_request.GetType() == typeof(ConsultaRequest))// && response_code == ConfigurationManager.AppSettings["Procard_Response_Accepted_Consulta"])
                    {
                        success = true;
                        response_code = ConfigurationManager.AppSettings["Procard_Response_Accepted"];
                    }
                    if (response_code == ConfigurationManager.AppSettings["Procard_Response_Accepted"])
                        success = true;
                    response_message = ConfigurationManager.AppSettings[string.Format("Procard_Response_{0}", response_code)];
                }
                if (string.IsNullOrEmpty(response_message))
                    response_message = original_procard_response;
                //if (success)
                result = _request.ResponseParams().Zip(split_result.Skip(1), (key, value) => new { key, value })
                                                 .ToDictionary(kv => kv.key, kv => kv.value.Replace("\r\n", string.Empty).Trim());
                if (result.Keys.Count > 0 && _request.GetType() == typeof(ConsultaRequest)) // && response_code == ConfigurationManager.AppSettings["Procard_Response_Accepted_Consulta"])
                {
                    success = true;
                    response_code = ConfigurationManager.AppSettings["Procard_Response_Accepted"];
                }
                else
                {
                    success = false;
                    response_code = ConfigurationManager.AppSettings["Procard_Response_Default"];
                }
            }
            catch (Exception ex)
            {
                response_code = ConfigurationManager.AppSettings["Procard_Response_Default"];
                success = false;
                response_message = ex.Message;
            }
        }
    }
}
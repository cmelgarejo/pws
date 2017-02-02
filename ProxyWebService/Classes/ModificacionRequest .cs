using ProxyWebService.Classes.Interfaces;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System;

namespace ProxyWebService.Classes
{
    public class ModificacionRequest : BaseProcardRequestClass, IBaseProcardRequestClass
    {
        string _document = string.Empty;

        public string change_code { get; set; }
        public string sequence_number { get; set; }
        public string identity_document { get; set; }
        public string entity_code { get; set; }
        public string card_class { get; set; }
        public string card_number { get; set; }
        public string user_number { get; set; }
        public string data { get; set; }
        public string date { get; set; } //YYYYMMDD
        public string time { get; set; } //HHMMSS

        public ModificacionRequest()
        {
            __operation__ = ConfigurationManager.AppSettings["ProcardOperation_Modificacion"];
        }


        public string ProcardMessage()
        {
            return BuildProcardMessage(change_code, sequence_number, identity_document, entity_code, card_class, card_number,
                user_number, data, date, time, ProcardCredentials);
        }

        /*
         Parámetros de salida
            00 – Aprobado.  Cualquier valor distinto de 00 No Aprobado
            Autorización	Código de Autorización – Viene el código de autorización asignado en Procard
            Estado	Estado de conexión 0-Ok, 1-Incorrecto
         */
        public string[] ResponseParams()
        {
            List<string> outParams = new List<string>();
            foreach (var item in ConfigurationManager.AppSettings.AllKeys.Where(p => p.Contains("ProcardOperation_Modificacion_OutParam_")).OrderBy(p => p))
                outParams.Add(ConfigurationManager.AppSettings[item]);
            return outParams.ToArray();
        }

        public static Dictionary<string, string> ChangeCodes(string id = "")
        {
            if (string.IsNullOrEmpty(id))
            {
                List<string> changeCodes = new List<string>();
                foreach (var item in ConfigurationManager.AppSettings.AllKeys.Where(p => p.Contains("ProcardOperation_Modificacion_ChangeCode_")))
                    changeCodes.Add(ConfigurationManager.AppSettings[item]);
                return ConfigurationManager.AppSettings.AllKeys.Where(p => p.Contains("ProcardOperation_Modificacion_ChangeCode_")).Zip(changeCodes, (key, value) => new { key, value })
                    .OrderBy(k => k.key).ToDictionary(kv => kv.key.Replace("ProcardOperation_Modificacion_ChangeCode_", string.Empty), kv => kv.value);
            }
            else
            {
                string key = string.Format("ProcardOperation_Modificacion_ChangeCode_{0}", id);
                string value = string.Empty;
                try
                {
                    value = ConfigurationManager.AppSettings[key];
                }
                catch (Exception)
                {
                    value = string.Empty;
                }
                return new Dictionary<string, string>()
                {
                    { id, value }
                };
            }
        }
    }
}
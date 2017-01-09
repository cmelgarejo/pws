using ProxyWebService.Classes.Interfaces;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace ProxyWebService.Classes
{
    public class PagoRequest : BaseProcardRequestClass, IBaseProcardRequestClass
    {
        string _document = string.Empty;

        public string operation_type { get; set; }
        public string response { get; set; }
        public string card_number { get; set; }
        public string card_class { get; set; }
        public string identity_document { get; set; }
        public string expiration { get; set; }
        public string amount { get; set; }
        public string authorization { get; set; }
        public string commerce { get; set; }
        public string quota { get; set; }
        public string coupon { get; set; }
        public string datetime { get; set; }
        public string balance { get; set; }
        public string payment_type { get; set; }
        public string bank { get; set; }
        public string cheque { get; set; }
        public string name { get; set; }
        public string terminal { get; set; }
        public string provider { get; set; }
        public string entity { get; set; }
        public string state { get; set; }

        public PagoRequest()
        {
            operation = ConfigurationManager.AppSettings["ProcardOperation_Pago"];
        }


        public string ProcardMessage()
        {
            return BuildProcardMessage(operation_type, response, card_number, card_class, identity_document, 
                expiration, amount, authorization, commerce, quota, coupon, datetime, balance, payment_type, 
                bank, cheque, name, terminal, provider, entity, ProcardCredentials, state);
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
            foreach (var item in ConfigurationManager.AppSettings.AllKeys.Where(p => p.Contains("ProcardOperation_Pago_OutParam_")))
            {
                outParams.Add(ConfigurationManager.AppSettings[item]);
            }
            return outParams.ToArray();
        }
    }
}
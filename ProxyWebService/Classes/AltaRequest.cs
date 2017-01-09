using ProxyWebService.Classes.Interfaces;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace ProxyWebService.Classes
{
    public class AltaRequest : BaseProcardRequestClass, IBaseProcardRequestClass
    {
        string _document = string.Empty;

        public string operation_type { get { return ConfigurationManager.AppSettings["ProcardOperation_Alta_Operation_Type"]; } }
        public string sequence_number { get; set; }
        public string identity_document { get; set; }
        public string entity_code { get; set; }
        public string card_class { get; set; }
        public string card_username { get; set; }
        public string address_street { get; set; }
        public string address_city { get; set; }
        public string address_barrio { get; set; }
        public string phone_particular { get; set; }
        public string phone_work { get; set; }
        public string phone_mobile { get; set; }
        public string email { get; set; }
        public string birthdate { get; set; } //DDMMYY
        public string civil_status { get; set; }
        public string gender { get; set; }
        public string credit_line_cash { get; set; }
        public string credit_line_quota { get; set; }
        public string credit_line_special { get; set; }
        public string detainer_code { get; set; }
        public string account_number { get; set; }
        public string account_type { get; set; }
        public string payment_type { get; set; }
        public string member_internal_number { get; set; }
        public string card_type { get; set; }
        public string principal_document { get; set; }
        public string date { get; set; }
        public string time { get; set; }

        public AltaRequest()
        {
            operation = ConfigurationManager.AppSettings["ProcardOperation_Alta"];
        }


        public string ProcardMessage()
        {
            return BuildProcardMessage(operation_type, sequence_number, identity_document, entity_code, card_class, card_username, 
                address_street, address_city, address_barrio, phone_particular, phone_work, phone_mobile, email, birthdate, 
                civil_status, gender, credit_line_cash, credit_line_quota, credit_line_special, detainer_code, 
                account_number, account_type, payment_type, member_internal_number, card_type, principal_document, 
                date, time, ProcardCredentials);
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
            foreach (var item in ConfigurationManager.AppSettings.AllKeys.Where(p => p.Contains("ProcardOperation_Alta_OutParam_")))
            {
                outParams.Add(ConfigurationManager.AppSettings[item]);
            }
            return outParams.ToArray();
        }
    }
}
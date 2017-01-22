using ProxyWebService.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace ProxyWebService.Classes
{
    public class PagoRequest : BaseProcardRequestClass, IBaseProcardRequestClass
    {
        string _operation_type = string.Empty;
        string _response = string.Empty;
        string _card_number = string.Empty;
        string _card_class = string.Empty;
        string _identity_document = string.Empty;
        string _expiration = string.Empty;
        string _amount = string.Empty;
        string _authorization = string.Empty;
        string _commerce = string.Empty;
        string _quota = string.Empty;
        string _coupon = string.Empty;
        string _datetime = string.Empty;
        string _balance = string.Empty;
        string _payment_type = string.Empty;
        string _bank = string.Empty;
        string _cheque = string.Empty;
        string _name = string.Empty;
        string _terminal = string.Empty;
        string _provider = string.Empty;
        string _entity = string.Empty;
        string _state = string.Empty;

        //1#75#0#2906#P1#004913675#0#100000#0#7803554#0#9999999#20161230113523#0#00#0#0#0#0#107#107#GXTARJETAM#PROCARDDES#0
        //1#75#0#2906#XL#004913675#0#100000#0#7803554#0#0000000#20170122105400#0#00#0#0#0#0#107#107#GXTARJETAM#PROCARDDES#0
        //1#00#0#2906#P1#004913675#0000#100000#99999#7803554#0#0000000#20170122110206#0#00#0#0#0#0#107#107#GXTARJETAM#PROCARDDES#0
        public string operation_type { get { return _operation_type.PadLeft(2, __numberPaddingChar); } set { _operation_type = value; } }
        public string response { get { return _response.PadLeft(1, __numberPaddingChar); } set { _response = value; } }
        public string card_number { get { return _card_number.PadLeft(4, __space); } set { _card_number = value; } }
        public string card_class { get { return _card_class.PadLeft(2, __numberPaddingChar); } set { _card_class = value; } }
        public string identity_document { get { return _identity_document.PadLeft(9, __numberPaddingChar); } set { _identity_document = value; } }
        /// <summary>
        /// -0, si el tipo de operación es 75 u 88
        /// -Vcto de la tarjeta en caso de tipo de operación 13 u 8
        /// </summary>
        public string expiration
        {
            get
            {

                if (operation_type == ConfigurationManager.AppSettings["ProcardOperation_Pago_Pago"] || operation_type == ConfigurationManager.AppSettings["ProcardOperation_Pago_Reversa_Pago"])
                    _expiration = ConfigurationManager.AppSettings["ProcardOperation_Pago_Expiration"];
                else
                    _expiration = _expiration.PadLeft(4, __numberPaddingChar);
                return _expiration;
            }
            set { _expiration = value; }
        }
        public string amount { get; set; } //{ get { return _amount; } set { _amount = value; } }
        public string authorization
        {
            get
            {

                if (operation_type == ConfigurationManager.AppSettings["ProcardOperation_Pago_Pago"] || operation_type == ConfigurationManager.AppSettings["ProcardOperation_Pago_Adelanto"])
                    _authorization = ConfigurationManager.AppSettings["ProcardOperation_Pago_AuthorizationCode"];
                //else //? if there's any other mutation on the data
                //    _authorization = _authorization.PadLeft(4, __numberPaddingChar);
                return _authorization;
            }
            set { _authorization = value; }
        }
        public string commerce { get { return _commerce.PadLeft(7, __numberPaddingChar); } set { _commerce = value; } }
        public string quota { get { return _quota.PadLeft(1, __numberPaddingChar); } set { _quota = value; } }
        public string coupon { get { return _coupon.PadLeft(7, __numberPaddingChar); } set { _coupon = value; } } //{ get; set; } 
        public string datetime { get { return string.IsNullOrEmpty(_datetime) ? DateTime.Now.ToString("yyyyMMddHHmmss") : _datetime; } set { _datetime = !string.IsNullOrEmpty(value) ? value : DateTime.Now.ToString("yyyyMMddHHmmss"); } } //AAAAMMDDHHMMSS
        public string balance { get { return _balance.PadLeft(1, __numberPaddingChar); } set { _balance = value; } }
        public string payment_type { get { return _payment_type.PadLeft(2, __numberPaddingChar); } set { _payment_type = value; } }
        public string bank { get { return _bank.PadLeft(1, __numberPaddingChar); } set { _bank = value; } }
        public string cheque { get { return _cheque.PadLeft(1, __numberPaddingChar); } set { _cheque = value; } }
        public string name { get { return _name.PadLeft(1, __numberPaddingChar); } set { _name = value; } }
        public string terminal { get { return _terminal.PadLeft(1, __numberPaddingChar); } set { _terminal = value; } }
        public string provider { get { return _provider.PadLeft(3, __numberPaddingChar); } set { _provider = value; } }
        public string entity { get { return _entity.PadLeft(3, __numberPaddingChar); } set { _entity = value; } }
        public string state { get { return _state.PadLeft(1, __numberPaddingChar); } set { _state = value; } }

        public PagoRequest()
        {
            __operation__ = ConfigurationManager.AppSettings["ProcardOperation_Pago"];
            _operation_type = ConfigurationManager.AppSettings["ProcardOperation_Pago_Pago"];
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
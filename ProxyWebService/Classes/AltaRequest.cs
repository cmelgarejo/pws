using ProxyWebService.Classes.Interfaces;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace ProxyWebService.Classes
{
    public class AltaRequest : BaseProcardRequestClass, IBaseProcardRequestClass
    {
        #region Field variables
        string _document = string.Empty;
        string _sequence_number = string.Empty;
        string _identity_document = string.Empty;
        string _entity_code = string.Empty;
        string _card_class = string.Empty;
        string _card_number = string.Empty;
        string _card_usernumber = string.Empty;
        string _card_username = string.Empty;
        string _address_street = string.Empty;
        string _address_city = string.Empty;
        string _address_neighborhood = string.Empty;
        string _phone_home = string.Empty;
        string _phone_work = string.Empty;
        string _phone_mobile = string.Empty;
        string _email = string.Empty;
        string _birthdate = string.Empty; //DDMMYY
        string _civil_status = string.Empty;
        string _gender = string.Empty;
        string _credit_line_cash = string.Empty;
        string _credit_line_quota = string.Empty;
        string _credit_line_special = string.Empty;
        string _branch_office = string.Empty;
        string _detainer_code = string.Empty;
        string _account_number = string.Empty;
        string _account_type = string.Empty;
        string _payment_type = string.Empty;
        string _member_internal_number = string.Empty;
        string _card_type = string.Empty;
        string _principal_document = string.Empty;
        string _modify_data = string.Empty;
        string _auth_code = string.Empty;
        string _reject_code = string.Empty;
        string _reject_motive = string.Empty;
        string _date = string.Empty; //YYYYMMDD
        string _time = string.Empty; //HHMMSS
        string _change_code { get { return ConfigurationManager.AppSettings["ProcardOperation_Alta_Change_Code"]; } }
        #endregion

        public string sequence_number { get { return _sequence_number.PadLeft(12, __numberPaddingChar); } set { _sequence_number = value; } }
        public string identity_document { get { return _identity_document.PadLeft(9, __numberPaddingChar); } set { _identity_document = value; } }
        public string entity_code { get { return _entity_code.PadLeft(3, __numberPaddingChar); } set { _entity_code = value; } }
        public string card_class { get { return _card_class.PadLeft(2, __numberPaddingChar); } set { _card_class = value; } }
        public string card_number { get { return _card_number.PadRight(16, __space); } set { _card_number = value; } }
        public string card_usernumber { get { return _card_usernumber.PadLeft(9, __numberPaddingChar); } set { _card_usernumber = value; } }
        public string card_username { get { return _card_username.PadRight(20, __space); } set { _card_username = value; } }
        public string address_street { get { return _address_street.PadRight(50, __space); } set { _address_street = value; } }
        public string address_city { get { return _address_city.PadRight(15, __space); } set { _address_city = value; } }
        public string address_neighborhood { get { return _address_neighborhood.PadRight(15, __space); } set { _address_neighborhood = value; } }
        public string phone_home { get { return _phone_home.PadRight(15, __space); } set { _phone_home = value; } }
        public string phone_work { get { return _phone_work.PadRight(15, __space); } set { _phone_work = value; } }
        public string phone_mobile { get { return _phone_mobile.PadRight(15, __space); } set { _phone_mobile = value; } }
        public string email { get { return _email.PadRight(50, __space); } set { _email = value; } }
        public string birthdate { get { return _birthdate; } set { _birthdate = value; } } //DDMMyy
        public string civil_status { get { return _civil_status; } set { _civil_status = value; } }
        public string gender { get { return _gender; } set { _gender = value; } }
        public string credit_line_cash { get { return _credit_line_cash.PadLeft(13, __numberPaddingChar); } set { _credit_line_cash = value; } }
        public string credit_line_quota { get { return _credit_line_quota.PadLeft(13, __numberPaddingChar); } set { _credit_line_quota = value; } }
        public string credit_line_special { get { return _credit_line_special.PadLeft(13, __numberPaddingChar); } set { _credit_line_special = value; } }
        public string branch_office { get { return _branch_office.PadLeft(2, __numberPaddingChar); } set { _branch_office = value; } }
        public string detainer_code { get { return _detainer_code.PadLeft(2, __numberPaddingChar); } set { _detainer_code = value; } }
        public string account_number { get { return _account_number.PadLeft(12, __numberPaddingChar); } set { _account_number = value; } }
        public string account_type { get { return _account_type.PadRight(1, __space); } set { _account_type = value; } }
        public string payment_type { get { return _payment_type; } set { _payment_type = value; } }
        public string member_internal_number { get { return _member_internal_number.PadLeft(12, __numberPaddingChar); } set { _member_internal_number = value; } }
        public string card_type { get { return _card_type.PadLeft(1, __numberPaddingChar); } set { _card_type = value; } }
        public string principal_document { get { return _principal_document.PadLeft(9, __numberPaddingChar); } set { _principal_document = value; } }
        public string modify_data { get { return _modify_data.PadRight(100, __space); } set { _modify_data = value; } }
        public string date { get { return _date.PadLeft(8, __numberPaddingChar); } set { _date = value; } } //yyyyMMdd
        public string time { get { return _time.PadLeft(6, __numberPaddingChar); } set { _time = value; } } //HHmmss
        public string auth_code { get { return _auth_code.PadRight(6, __space); } set { _auth_code = value; } }
        public string reject_code { get { return _reject_code.PadRight(2, __space); } set { _reject_code = value; } }
        public string reject_motive { get { return _reject_motive.PadRight(30, __space); } set { _reject_motive = value; } }

        
        public AltaRequest()
        {
            __operation__ = ConfigurationManager.AppSettings["ProcardOperation_Alta"];
        }

        /*
        Tipo Operación			
        Nro secuencial			
        Documento				
        Código entidad			
        Clase de Tarjeta		
        Nombre del Usuario/Plást
        Dirección				
        Localidad				
        Barrio					
        Teléfono Particular		
        Teléfono Laboral		
        Teléfono Celular		
        Dirección email			
        Fecha Nacimiento DDMMAA	
        Estado civil			
        Sexo					
        Línea Crédito Contado	
        Línea Crédito Cuota		
        Línea Crédito Especial	
        Sucursal				
        Código Captador			
        Número de Cuenta		
        Tipo de Cuenta			
        Forma de Pago			
        Número Interno /Socio	
        Tipo de Tarjeta			
        Documento del Principal	
        Fecha					
        Hora					
        Usuario					
        Password				
             */
        public string ProcardMessage()
        {
            return BuildProcardMessage(_change_code, sequence_number, identity_document, entity_code,
                card_class, card_usernumber, address_street, address_city, address_neighborhood,
                phone_home, phone_work, phone_mobile, email, birthdate, civil_status, gender, credit_line_cash, credit_line_quota, credit_line_special,
                branch_office, detainer_code, account_number, account_type, payment_type, member_internal_number,
                card_type, principal_document, date, time, ProcardCredentials);
            //return p;
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
            foreach (var item in ConfigurationManager.AppSettings.AllKeys.Where(p => p.Contains("ProcardOperation_Alta_OutParam_")).OrderBy(p => p))
                outParams.Add(ConfigurationManager.AppSettings[item]);
            return outParams.ToArray();
        }
    }
}
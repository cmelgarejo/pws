using ProxyWebService.Classes.Interfaces;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace ProxyWebService.Classes
{
    public class ConsultaRequest : BaseProcardRequestClass, IBaseProcardRequestClass
    {
        string _document = string.Empty;

        public string document
        {
            get
            {
                return _document;
            }
            set
            {
                _document = value.PadLeft(9, '0');
            }
        }

        public ConsultaRequest()
        {
            operation = ConfigurationManager.AppSettings["ProcardOperation_Consulta"];
        }


        public string ProcardMessage()
        {
            return BuildProcardMessage(ProcardCredentials, document);
        }

        /*
         Parámetros de salida
            Código Servicio: Código de servicio
            Terminación de la Tarjeta: Cuatro últimos dígitos de la Tarjeta
            Nombre y Apellido: Nombre y Apellido del Cliente
            Clase de Tarjeta: Código de la Clase de Tarjeta.
            Descripción: Descripción de la Tarjeta
            Monto a Pagar: Monto de Pago Mínimo o Mora
            Deuda: Deuda Actual de  la Tarjeta en Guaraníes
         */
        public string[] ResponseParams()
        {
            List<string> outParams = new List<string>();
            foreach (var item in ConfigurationManager.AppSettings.AllKeys.Where(p => p.Contains("ProcardOperation_Consulta_OutParam_")))
            {
                outParams.Add(ConfigurationManager.AppSettings[item]);
            }
            return outParams.ToArray();
        }
    }
}
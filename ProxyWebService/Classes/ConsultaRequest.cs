﻿using ProxyWebService.Classes.Interfaces;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace ProxyWebService.Classes
{
    public class ConsultaRequest : BaseProcardRequestClass, IBaseProcardRequestClass
    {
        string _identity_document = string.Empty;

        public string identity_document
        {
            get
            {
                return _identity_document;
            }
            set
            {
                _identity_document = value.PadLeft(9, '0');
            }
        }

        public ConsultaRequest()
        {
            __operation__ = ConfigurationManager.AppSettings["ProcardOperation_Consulta"];
        }


        public string ProcardMessage()
        {
            return BuildProcardMessage(ProcardCredentials, identity_document);
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
            foreach (var item in ConfigurationManager.AppSettings.AllKeys.Where(p => p.Contains("ProcardOperation_Consulta_OutParam_")).OrderBy(p => p))
                outParams.Add(ConfigurationManager.AppSettings[item]);
            return outParams.ToArray();
        }
    }
}
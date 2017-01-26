using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProxyWebService.Classes;

namespace ProxyWebService.Controllers
{
    public class ProcardController : ApiController
    {
        public ProcardResponse Get()
        {
            //return ProcardSocketClient.Get(new ConsultaRequest() { document = "1499526" }.ProcardMessage()); //Consulta Test
            //return new ProcardResponse("0");
            ConsultaRequest consulta = new ConsultaRequest()
            {
                identity_document = "180108"
            };
            ////1#75#0#2906#P1#004913675#0#100000#0#7803554#0#9999999#20161230113523#0#00#0#0#0#0#107#107#GXTARJETAM#PROCARDDES#0
            return new ProcardResponse(consulta, "1#00000000#2906#VIVIANA L FONCECA GAMARRA     #P1#CREDICARD CLASICA TARJ.MI                #+0000000067242000#+0000000069442000");
            //return new ProcardResponse(consulta, "91#      #0");

        }

        // POST procard/api/v1/consulta
        [HttpPost]
        public ProcardResponse Consulta([FromBody]ConsultaRequest consulta)
        {
            return ProcardSocketClient.Get(consulta);
        }

        // POST procard/api/v1/alta
        [HttpPost]
        public ProcardResponse Alta([FromBody]AltaRequest alta)
        {
            return ProcardSocketClient.Get(alta);
        }

        // GET procard/api/v1/modificacion
        [HttpGet]
        public Dictionary<string, string> Modificacion()
        {
            return ModificacionRequest.ChangeCodes();
        }

        // GET procard/api/v1/modificacion/:id
        [HttpGet]
        public Dictionary<string, string> Modificacion(string id)
        {
            return ModificacionRequest.ChangeCodes(id);
        }

        // POST procard/api/v1/modificacion
        [HttpPost]
        public ProcardResponse Modificacion([FromBody]ModificacionRequest modificacion)
        {
            return ProcardSocketClient.Get(modificacion);
        }

        // POST procard/api/v1/pago
        [HttpPost]
        public ProcardResponse Pago([FromBody]PagoRequest pago)
        {
            return ProcardSocketClient.Get(pago);
        }

        // POST procard/api/v1/pago_reversa
        [HttpPost]
        public ProcardResponse Pago_Reversa([FromBody]PagoRequest pago)
        {
            pago.IsReversaPago = true;
            return ProcardSocketClient.Get(pago);
        }

        // POST procard/api/v1/pago_reversa
        [HttpPost]
        public ProcardResponse Credito([FromBody]PagoRequest credito)
        {
            credito.IsPagoCredito = true;
            return ProcardSocketClient.Get(credito);
        }

    }
}

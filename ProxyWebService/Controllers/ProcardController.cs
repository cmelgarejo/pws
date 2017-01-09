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
                document = "180108"
            };
            return new ProcardResponse(consulta, "1#00000000#2906#VIVIANA L FONCECA GAMARRA     #P1#CREDICARD CLASICA TARJ.MI                #+0000000067242000#+0000000069442000");
            return new ProcardResponse(consulta, "91#      #0");

        }

        // POST procard/api/v1/consulta
        [HttpPost]
        public ProcardResponse Consulta([FromBody]ConsultaRequest consulta)
        {
            return ProcardSocketClient.Get(consulta);
        }

        // POST procard/api/v1/pago
        [HttpPost]
        public ProcardResponse Pago([FromBody]PagoRequest pago)
        {
            return ProcardSocketClient.Get(pago);
        }

    }
}

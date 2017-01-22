using ProxyWebService.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProxyWebService.Classes
{
    public class ProcardSocketClient
    {
        public static ProcardResponse Get(IBaseProcardRequestClass request)
        {
            if (request == null)
                return new ProcardResponse(new ConsultaRequest(), "9999#Internal service Error 9999");
            return new ProcardResponse(request, SynchronousSocketClient.WriteAndGetReply(request.ProcardMessage()));
        }
    }
}
using Simplyfund.Bll.ServicesInterface.ViaFirma;
using Simplyfund.Dal.DataInterface.ViaFirma;
using SimplyFund.Domain.Dto.ViaFirma;
using SimplyFund.Domain.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Simplyfund.Bll.Services.ViaFirma
{
    public class ServicesViaFirma : IServicesViaFirma
    {

        IDataViafirma dataViafirma;
        public ServicesViaFirma(IDataViafirma dataViafirma)
        {
            this.dataViafirma = dataViafirma;
        }


        public async Task<TerminosCondicionesResponses> RequestTerminosCondiciones(TerminosCondicionesRequest terminos)
        {
            try
            {
                string req = Extends.GetJson<TerminosCondicionesRequest>(terminos);

                var result = await dataViafirma.httpPostRequest(req, "messages/dispatch");

                var responses = JsonSerializer.Deserialize<TerminosCondicionesResponses>(result);
                if (responses!= null)
                {
                    return responses;
                }
                else
                {
                    throw new Exception("Actualmente tenemos un errror en la plataforma.");
                }


              
            }

            catch (Exception)
            {
                throw;   
            }
           
        }

    }
}

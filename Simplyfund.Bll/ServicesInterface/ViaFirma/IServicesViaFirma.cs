using SimplyFund.Domain.Dto.ViaFirma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplyfund.Bll.ServicesInterface.ViaFirma
{
    public interface IServicesViaFirma
    {
        Task<TerminosCondicionesResponses> RequestTerminosCondiciones(TerminosCondicionesRequest terminos);
    }
}

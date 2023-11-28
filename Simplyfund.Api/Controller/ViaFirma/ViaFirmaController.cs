using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Simplyfund.Bll.ServicesInterface.ViaFirma;
using SimplyFund.Domain.Dto.Responses;
using SimplyFund.Domain.Dto.ViaFirma;

namespace Simplyfund.Api.Controller.ViaFirma
{
    [ApiController]
    [Route("api/[controller]")]
    public class ViaFirmaController : ControllerBase
    {
        ErrorResponses errorResponses;
        IServicesViaFirma servicesViaFirma;
        public ViaFirmaController(IServicesViaFirma servicesViaFirma)
        {
            errorResponses = new ErrorResponses();
            this.servicesViaFirma = servicesViaFirma;
        }


        [HttpPost("terminosyCondiciones")]
        public  async Task<ActionResult<TerminosCondicionesResponses>> terminosyCondicionesRequest(TerminosCondicionesRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return  Ok(await servicesViaFirma.RequestTerminosCondiciones(request));
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                errorResponses = new ErrorResponses();
                errorResponses.Message = ex.Message;
                return StatusCode(500, errorResponses);
            }
        }
    }
}

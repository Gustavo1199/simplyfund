using Microsoft.AspNetCore.Mvc;
using Simplyfund.Bll.Services.Common;
using Simplyfund.Bll.ServicesInterface.Common;
using SimplyFund.Domain.Dto.Common;
using SimplyFund.Domain.Dto.Responses;

namespace Simplyfund.Api.Controller.Common
{
    [ApiController]
    [Route("api/Common/[controller]")]
    public class ValidateController : ControllerBase
    {
        ErrorResponses errorResponses;
        IServicesValidate servicesValidate;

        public ValidateController(IServicesValidate servicesValidate)
        {
            errorResponses = new ErrorResponses();
            this.servicesValidate = servicesValidate;
        }



        [HttpGet("ValidateEmail")]
        public async Task<ActionResult<bool>> ValidateEmail(string email)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(await servicesValidate.ValidateEmail(email));
                }
                else
                {
                    return BadRequest(ModelState);
                }
              

            }
            catch (Exception ex)
            {
                if (ex.Message == null)
                {
                    if (ex.InnerException != null)
                    {
                        errorResponses.Message = ex.InnerException.Message;
                    }
                }
                else
                {
                    errorResponses.Message = ex.Message;
                }
                return StatusCode(500, errorResponses);
            }
        }


        [HttpGet("ValidateidentityNumber")]
        public async Task<ActionResult<bool>> ValidateidentityNumber(string identityValue)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return await servicesValidate.ValidateidentityNumber(identityValue);
                }
                else
                {
                    return BadRequest(ModelState);
                }
                

            }
            catch (Exception ex)
            {
                if (ex.Message == null)
                {
                    if (ex.InnerException != null)
                    {
                        errorResponses.Message = ex.InnerException.Message;
                    }
                }
                else
                {
                    errorResponses.Message = ex.Message;
                }
                return StatusCode(500, errorResponses);
            }
        }


    }
}

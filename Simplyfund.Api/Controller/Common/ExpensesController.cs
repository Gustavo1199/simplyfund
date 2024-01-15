using Microsoft.AspNetCore.Mvc;
using Simplyfund.Bll.Services.Common;
using Simplyfund.Bll.ServicesInterface.Common;
using SimplyFund.Domain.Dto.Common;
using SimplyFund.Domain.Dto.Responses;

namespace Simplyfund.Api.Controller.Common
{
    [ApiController]
    [Route("api/Common/[Controller]")]
    public class ExpensesController : ControllerBase
    {
        ErrorResponses errorResponses;

        IServicesExpenses servicesExpenses;
        public ExpensesController(IServicesExpenses servicesExpenses)
        {
            this.servicesExpenses = servicesExpenses;
            errorResponses = new ErrorResponses();  
        }


        [HttpPost("GetAuthomaticExpenses")]
        public async Task<ActionResult<ExpensesModelsLists>> GetAuthomaticExpenses(ConditionRequest model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(await servicesExpenses.getAuthomaticExpenses(model));

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

using Microsoft.AspNetCore.Mvc;
using Simplyfund.Bll.Services.Auth;
using Simplyfund.Bll.ServicesInterface.Auth;
using SimplyFund.Domain.Dto.Responses;

namespace SimplyFund.Auth.Controllers.Auth
{
    [ApiController]
    [Route("api/Auth/[controller]")]
    public class RolController : ControllerBase
    {

        IServicesRol ServicesRol;
        public RolController(IServicesRol servicesRol)
        {
            ServicesRol = servicesRol;
        }

        [HttpPost("AssignUserRole")]
        public async Task<ActionResult<bool>> AssignUserRole(string userId, string roleName)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    return Ok(await ServicesRol.AssignUserRole(userId, roleName));


                }
                else
                {
                    return BadRequest(ModelState);
                }

            }
            catch (Exception ex)
            {
                ErrorResponses errorResponses = new ErrorResponses();
                errorResponses.Message = ex.Message;
                return StatusCode(500, errorResponses);
            }

        }
    }
}

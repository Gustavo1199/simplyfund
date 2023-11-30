using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Simplyfund.Bll.ServicesInterface.Auth;
using SimplyFund.Domain.Dto.Login;
using SimplyFund.Domain.Dto.Responses;

namespace Simplyfund.Auth.Controller.Auth
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IServicesAuth servicesAuth;


        public AuthController(IServicesAuth userManager)
        {
            servicesAuth = userManager;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponses>> Login([FromBody] LoginModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var login = await servicesAuth.Login(model);
                    if (login.token != null)
                    {
                        return Ok(login);
                    }
                    else
                    {
                        return Unauthorized(new { Messge = "Las credenciales no son válidas" });
                    }


                }
                else
                {
                    return BadRequest(ModelState);
                }

                //return Unauthorized();

            }
            catch (Exception ex)
            {
                ErrorResponses errorResponses = new ErrorResponses();
                errorResponses.Message = ex.Message;
                return StatusCode(500, errorResponses);
            }

        }

        [HttpPost("AssignUserRole")]
        public async Task<ActionResult<bool>> AssignUserRole(string userId, string roleName)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    return Ok(await servicesAuth.AssignUserRole(userId, roleName));


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

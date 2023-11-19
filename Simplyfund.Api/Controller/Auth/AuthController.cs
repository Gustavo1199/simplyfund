using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Simplyfund.Bll.ServicesInterface.Auth;
using SimplyFund.Domain.Dto.Login;
using SimplyFund.Domain.Dto.Responses;

namespace Simplyfund.Api.Controller.Auth
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
            if (ModelState.IsValid)
            {
              
                var login = await servicesAuth.Login(model);
                if (login != null)
                {
                    return Ok(login);
                }
                else
                {
                    return Unauthorized(new { Messge = "Las credenciales no son válidas" });
                }
               
                
            }

            // Las credenciales no son válidas
            return Unauthorized();
        }
    }
}

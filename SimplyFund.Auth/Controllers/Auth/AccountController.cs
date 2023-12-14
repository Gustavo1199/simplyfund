using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Simplyfund.Bll.ServicesInterface.Auth;
using SimplyFund.Domain.Dto.Login;
using SimplyFund.Domain.Dto.Responses;

namespace Simplyfund.Auth.Controller.Auth
{
    [ApiController]
    [Route("api/Auth/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IServicesAuth servicesAuth;


        public AccountController(IServicesAuth userManager)
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

        [HttpPost("ForgotPassword")]
        public async Task<ActionResult<object>> ForgotPassword([FromBody] ForgotPasswordDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var responses = await servicesAuth.ForgotPassword(model);
                    if (responses != null)
                    {
                        return Ok(responses);
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


            }
            catch (Exception ex)
            {
                ErrorResponses errorResponses = new ErrorResponses();
                errorResponses.Message = ex.Message;
                return StatusCode(500, errorResponses);
            }

        }

        [HttpPost("ResetPassword")]
        public async Task<ActionResult<bool>> ResetPassword([FromBody] ResetPasswordDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var responses = await servicesAuth.ResetPassword(model);

                    return Ok(responses);
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


        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var responses = await servicesAuth.ChangePassword(model);

                    return Ok(responses);
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

using Microsoft.AspNetCore.Mvc;
using Simplyfund.Bll.ServicesInterface.Common;
using SimplyFund.Domain.Dto.Common;
using SimplyFund.Domain.Dto.Responses;

namespace Simplyfund.Api.Controller.Common
{
    [ApiController]
    [Route("api/Common/[Controller]")]
    public class OptionsController : ControllerBase
    {
        IServicesOptions servicesOptions;
        ErrorResponses errorResponses;

        public OptionsController(IServicesOptions servicesOptions)
        {
            this.servicesOptions = servicesOptions;
            errorResponses = new ErrorResponses();
        }

        [HttpGet("GetCountry", Name = "GetCountry")]
        public async Task<ActionResult<List<OptionsResponses>>> GetCountry()
        {
            try
            {
                return await servicesOptions.GetCountry();

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

        [HttpGet("GetProvince", Name = "GetProvince")]
        public async Task<ActionResult<List<OptionsResponses>>> GetProvince()
        {
            try
            {
                return await servicesOptions.GetProvince();

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
        
        [HttpGet("GetCustomerTypes", Name = "GetCustomerTypes")]
        public async Task<ActionResult<List<OptionsResponses>>> GetCustomerTypes()
        {
            try
            {
                return await servicesOptions.GetCustomerTypes();

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

        [HttpGet("GetCategories")]
        public async Task<ActionResult<List<OptionsResponses>>> GetCategories()
        {
            try
            {
                return await servicesOptions.GetCategories();

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
        
        
        [HttpGet("GetIdentityTypeData", Name = "GetIdentityTypeData")]
        public async Task<ActionResult<List<OptionsResponses>>> GetIdentityTypeData()
        {
            try
            {
                return await servicesOptions.GetIdentityTypeData();

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

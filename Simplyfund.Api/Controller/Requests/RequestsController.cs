using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Simplyfund.Api.Controller.BaseController;
using Simplyfund.Bll.Services.Common;
using Simplyfund.Bll.ServicesInterface.Common;
using Simplyfund.Bll.ServicesInterface.IBaseServices;
using Simplyfund.Bll.ServicesInterface.Requests;
using SimplyFund.Domain.Base.Filter;
using SimplyFund.Domain.Dto.Request;
using SimplyFund.Domain.Dto.Responses;
using SimplyFund.Domain.Models.Requests;

namespace Simplyfund.Api.Controller.Requests
{

    [Route("api/[controller]")]
    public class RequestsController : BaseController<Request>
    {
        IServicesRequest baseServices;
        ErrorResponses errorResponses;

        public RequestsController(IServicesRequest baseServices) : base(baseServices)
        {
            errorResponses = new ErrorResponses();
            this.baseServices = baseServices;
        }

        [HttpPost("RequestLists")]
        public async Task<ActionResult<PaginatedList<RequestDto>>> RequestLists(FilterAndPaginateRequestModel? filters)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(await baseServices.RequestLists(filters));
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


        [HttpGet("GetByIdDetailsAsync/{Id}")]
        public async Task<ActionResult<RequestDatailsDto>> GetByIdDetailsAsync(int Id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userId = GetUserByToken();
                    return Ok(await baseServices.GetByIdDetailsAsync(Id, userId));
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


        [Consumes("multipart/form-data")]
        [RequestFormLimits(MultipartBodyLengthLimit = long.MaxValue)]
        [HttpPost("AddRequest")]
        public async Task<ActionResult<Request>> AddRequest([FromForm] Request entity)
        {

            

            try
            {
                if (ModelState.IsValid)
                {
                    return await baseServices.AddAndReturnAsync(entity);
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

using Microsoft.AspNetCore.Mvc;
using Simplyfund.Api.Controller.BaseController;
using Simplyfund.Bll.Services.BaseServices;
using Simplyfund.Bll.ServicesInterface.IBaseServices;
using Simplyfund.Bll.ServicesInterface.Request.Offers;
using SimplyFund.Domain.Dto.Request;
using SimplyFund.Domain.Dto.Request.Offers;
using SimplyFund.Domain.Dto.Responses;
using SimplyFund.Domain.Models.Requests.Offers;

namespace Simplyfund.Api.Controller.Requests.Offers
{
    [Route("api/Requests/[controller]")]
    public class OffersController : BaseController<OfferRequest>
    {
        IServicesOffers baseServices;
        ErrorResponses errorResponses;
        public OffersController(IServicesOffers baseServices) : base(baseServices)
        {
            this.baseServices = baseServices;
            this.errorResponses = new ErrorResponses();
        }



        [HttpGet("GetOffersByRequestId/{Id}")]
        public async Task<ActionResult<List<OfferRequestDto>>> GetOffersByRequestId(int Id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(await baseServices.GetOffersByRequestId(Id));
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



        [HttpPut("RejectInvesmentOffer/{Id}")]
        public async Task<ActionResult<bool>> RejectInvesmentOffer(int Id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(await baseServices.RejectInvesmentOffer(Id));
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



        [HttpPost("Counteroffer")]
        public async Task<ActionResult<bool>> Counteroffer(OffersRequestsCommentDto offerRequestCommentDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(await baseServices.Counteroffer(offerRequestCommentDto));
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

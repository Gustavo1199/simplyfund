using Microsoft.AspNetCore.Mvc;
using Simplyfund.Api.Controller.BaseController;
using Simplyfund.Bll.ServicesInterface.IBaseServices;
using Simplyfund.Bll.ServicesInterface.Request.Offers.AddedOffers;
using SimplyFund.Domain.Models.Requests.Offers.AddedOffers;

namespace Simplyfund.Api.Controller.Requests.Offers.AddedOffers
{
    [Route("api/Requests/Offers/[controller]")]
    public class AddedOffersController : BaseController<AddedOffer>
    {
        public AddedOffersController(IServicesAddedOffers baseServices) : base(baseServices)
        {
        }
    }
}

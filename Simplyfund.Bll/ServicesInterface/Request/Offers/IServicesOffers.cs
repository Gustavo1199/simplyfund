using Simplyfund.Bll.ServicesInterface.IBaseServices;
using SimplyFund.Domain.Dto.Request.Offers;
using SimplyFund.Domain.Models.Requests.Offers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplyfund.Bll.ServicesInterface.Request.Offers
{
    public interface IServicesOffers : IBaseServices<OfferRequest>
    {
        Task<List<OfferRequestDto>> GetOffersByRequestId(int requestId);

        Task<bool> RejectInvesmentOffer(int id);
    }
}

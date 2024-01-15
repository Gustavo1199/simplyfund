using SimplyFund.Domain.Base;
using SimplyFund.Domain.Models.Requests.Offers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Dto.Request.Offers
{
    public class OffersRequestsCommentDto : EntityBase
    {
        public string? Commnet { get; set; }
        public int OfferRequestId { get; set; }
    }
}

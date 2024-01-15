using SimplyFund.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Models.Requests.Offers
{
    public class OffersRequestsComment : EntityBase
    {
        public string? Commnet { get; set; }
        public int OfferRequestId { get; set; }
        
    }
}

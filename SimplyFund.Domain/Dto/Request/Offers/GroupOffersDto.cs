using SimplyFund.Domain.Models.Requests.Offers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Dto.Request.Offers
{
    public class GroupOffersDto
    {
        public int Quotas { get; set; }
        public decimal Interest { get; set; }
        public int Period { get; set; }
        public virtual List<OfferRequest>? Offers { get; set; }
    }
}

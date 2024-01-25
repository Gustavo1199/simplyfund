using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Dto.Request.Offers.AddedOffers
{
    public class AddedOfferDto
    {
        public decimal Amount { get; set; }
        public int InvestorId { get; set; }
    }
}

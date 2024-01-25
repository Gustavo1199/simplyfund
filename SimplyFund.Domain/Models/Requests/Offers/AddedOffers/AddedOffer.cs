using SimplyFund.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Customers = SimplyFund.Domain.Models.Client.Customer;

namespace SimplyFund.Domain.Models.Requests.Offers.AddedOffers
{
    public class AddedOffer : EntityBase
    {
        public int OfferRequestId { get; set; }
        public virtual OfferRequest? OfferRequest { get; set; }
        public decimal Amount { get; set; }
        public virtual Customers? Investor { get; set; }
        public int InvestorId { get; set; }
    }
}

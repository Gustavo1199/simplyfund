using SimplyFund.Domain.Base;
using SimplyFund.Domain.Models.Client;
using SimplyFund.Domain.Models.Common;
using SimplyFund.Domain.Models.Requests.Offers.AddedOffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Customers = SimplyFund.Domain.Models.Client.Customer;

namespace SimplyFund.Domain.Models.Requests.Offers
{
    public class OfferRequest : EntityBase
    {
        public int InvestorId { get; set; }
        public int BadgeId { get; set; }
        public decimal Amount { get; set; }
        public decimal AnnualInterest { get; set; }
        public int OffersRequestsPeriodsId { get; set; }
        public int Quotas { get; set; }
        public int OffersTypesId { get; set; }
        public int RequestId { get; set; }
        public int OffersStatusId { get; set; }
        public virtual Customers? Investor { get; set; }
        public virtual Badge? Badge { get; set; }
        public virtual OfferRequestPeriod? OffersRequestsPeriods { get; set; }
        public virtual OfferType? OffersTypes { get; set; }
        public virtual Request? Requests { get; set; }
        public virtual OfferStatus? OffersStatus { get; set; }

        public int BankAccountId { get; set; }
        public virtual BankAccount? BankAccount { get; set; }
        public bool? FundsSent { get; set; }



        public virtual ICollection<AddedOffer>? AddedOffers { get; set; }
    }
}

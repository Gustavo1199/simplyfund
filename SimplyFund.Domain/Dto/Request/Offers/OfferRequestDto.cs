using SimplyFund.Domain.Dto.Common;
using SimplyFund.Domain.Models.Common;
using SimplyFund.Domain.Models.Requests;
using SimplyFund.Domain.Models.Requests.Offers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Customers = SimplyFund.Domain.Models.Client.Customer;
using Requests = SimplyFund.Domain.Models.Requests.Request;

namespace SimplyFund.Domain.Dto.Request.Offers
{
    public class OfferRequestDto
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
       // public virtual Customers Investor { get; set; }
        public virtual BadgeDto? Badge { get; set; }
        public virtual OfferRequestPeriod? OffersRequestsPeriods { get; set; }
        public virtual OfferType? OffersTypes { get; set; }

        //public virtual Requests Requests { get; set; }
        public virtual OfferStatus? OffersStatus { get; set; }
        public int BankAccountId { get; set; }
        public bool? FundsSent { get; set; }
    }
}

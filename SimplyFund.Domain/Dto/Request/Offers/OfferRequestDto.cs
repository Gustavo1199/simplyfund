using SimplyFund.Domain.Dto.Base;
using SimplyFund.Domain.Dto.Common;
using SimplyFund.Domain.Dto.Request.Offers.AddedOffers;
using SimplyFund.Domain.Models.Common;
using SimplyFund.Domain.Models.Requests;
using SimplyFund.Domain.Models.Requests.Offers;
using SimplyFund.Domain.Models.Requests.Offers.AddedOffers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Customers = SimplyFund.Domain.Models.Client.Customer;
using Requests = SimplyFund.Domain.Models.Requests.Request;

namespace SimplyFund.Domain.Dto.Request.Offers
{
    public class OfferRequestDto : EntityBaseDto
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

        public virtual IEnumerable<AddedOfferDto>? AddedOffers { get; set; }

        [NotMapped]
        public IEnumerable<OffersRequestsComment>? OfferComments { get; set; }
    }
}

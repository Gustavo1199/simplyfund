using SimplyFund.Domain.Base;
using SimplyFund.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Models.Customer
{
    public class FundIncreaseRequest : EntityBase
    {

        public int? CustomerId { get; set; }
        public int? BadgeId { get; set; }
        public decimal? RequestedLimit { get; set; }
        public decimal? Limit { get; set; }
        public int? BankAccountId { get; set; }
        public int? FundIncreaseRequestStatusId { get; set; }
        public virtual Badge? Badge { get; set; }
        public virtual BankAccount? BankAccount { get; set; }
        public virtual FundIncreaseRequestStatus? FundIncreaseRequestStatus { get; set; }

        public virtual ICollection<FundIncreaseRequestComments>? FundIncreaseRequestComments { get; set; }




        //public int? CustomerId { get; set; }
        //public int? BadgeId { get; set; }
        //public decimal? RequestedLimit { get; set; }
        //public decimal? Limit { get; set; }
        //public decimal? Amount { get; set; }
        //public int? BankAccountId { get; set; }
        //public int? FundIncreaseRequestStatusId { get; set; }
        ////public  Customer Customer { get; set; }
        //public virtual Badge? Badge { get; set; }
        //public virtual BankAccount? BankAccount { get; set; }
        //public virtual FundIncreaseRequestStatus? FundIncreaseRequestStatus { get; set; }





    }
}

using SimplyFund.Domain.Base;
using SimplyFund.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Models.Customer
{
    public class FinancialSummary : EntityBase
    {
        public int CustomerId { get; set; }
        public string? YearOfSummary { get; set; }
        public int BadgeId { get; set; }
        public virtual Badge? Badge { get; set; }
        // --------   start of Assets
        public double NetSales { get; set; }
        public double NetProfits { get; set; }
        public double CurrentAssets { get; set; }
        public double Cash { get; set; }
        public double AccountsReceivable { get; set; }
        public double Inventary { get; set; }
        public double FixedAssets { get; set; }
        public double TotalAssets { get; set; }
        // --------   End of Assets
        public double CurrentLiabilities { get; set; }
        public double AccountsPayable { get; set; }
        public double LongTermLoans { get; set; }
        public double AnticipatedSpendings { get; set; }
        public double TotalLiabilities { get; set; }
        public double NetWorth { get; set; }

    }
}

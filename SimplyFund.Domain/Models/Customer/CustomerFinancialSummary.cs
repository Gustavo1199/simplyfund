using SimplyFund.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Models.Customer
{
    public class CustomerFinancialSummary : EntityBase
    {
        public int CustomerId { get; set; }
        public int BadgeId { get; set; }
        public double TotalCurrentAssets { get; set; } //total activo corriente
        public double TotalCurrentLiabilities { get; set; } // total pasivo corriente
        public double TotalMonthlyIncome { get; set; }

    }
}

using SimplyFund.Domain.Base;
using SimplyFund.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Models.Customer
{
    public class CompanyAdditionalInfo : EntityBase
    {
        public int CustomerId { get; set; }
        public DateTime IncorporationDate { get; set; }
        public int IncorporationCountryId { get; set; }
        public virtual Country? Country { get; set; }
        public string? CompanyActivity { get; set; }
        public string? ProductOrService { get; set; }
        public double IncomeForTheLastTaxPeriod { get; set; }
        public string? References { get; set; }

        public string? CompanyGoal { get; set; }
        public bool HasMoreThanTwoYears { get; set; }


    }
}

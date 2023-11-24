using SimplyFund.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Models.Customer
{
    public class LaborData : EntityBase
    {
        public int CustomerId { get; set; }
        public string? TypeOfIncome { get; set; }
        public string? CompanyName { get; set; }
        public string? JobTitle { get; set; }
        public string? Address { get; set; }
        public string? phone { get; set; }
        public bool HasAnotherIncomeSource { get; set; }
        public string? Explain { get; set; }

    }
}

using SimplyFund.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Models.Customer
{
    public class CustomerWorkingInfo : EntityBase
    {
  
        public int CustomerId { get; set; }
        //[ForeignKey("CustomerId")]
        //public virtual SimplyFund.Domain.Models.Client.Customer? Customer { get; set; }
        public string? IncomeType { get; set; }
        public string? CompanyName { get; set; }
        public string? JobTitle { get; set; }
        public string? CompanyAddress { get; set; }
        public string? CompanyPhone { get; set; }

        public bool HasAnotherIcomeSource { get; set; }
        public string? AnotherIcomeSourceDetail { get; set; }

    }
}

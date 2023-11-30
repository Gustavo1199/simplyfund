using SimplyFund.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Models.Common
{
    public class BankAccount : EntityBase
    {
        public int CustomerId { get; set; } // added

        [Required, MaxLength(20)]
        public string? AccountNumber { get; set; }
        public int BankId { get; set; }
        public int BankAccountTypeId { get; set; }
        public int BadgeId { get; set; }
        public int CountryId { get; set; }
        [Required, MaxLength(100)]

        public string? BeneficiaryName { get; set; }
        public int BeneficiaryIdentityTypeId { get; set; }
        [Required, MaxLength(11)]
        public string? BeneficiaryIdentityNumber { get; set; }


        public virtual IdentityType? IdentityType { get; set; }
        public virtual Country? Country { get; set; }
        public virtual Badge? Badge { get; set; }
        public virtual Bank? Bank { get; set; }
        public virtual BankAccountType? BankAccountType { get; set; }
    }
}

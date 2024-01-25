using SimplyFund.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Models.Customer
{
    public class Shareholder : EntityBase
    {
        public int CustomerId { get; set; }
        [Required, MaxLength(100)]
        public string? NameOrSocialReason { get; set; }
        public int IdentityTypeId { get; set; }
        [Required, MaxLength(100)]
        public string? IdentityNumber { get; set; }
        [Required, Range(0, 100)]
        public int PercentageOfShares { get; set; }

       // public virtual ICollection<ShareholderFile>? ShareholderFiles { get; set; }

        [NotMapped]
        public virtual List<Common.File>? File { get; set; }
    }
}

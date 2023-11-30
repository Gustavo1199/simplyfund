using SimplyFund.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Models.Common
{
    public class BankAccountType : EntityBase
    {
        [Required, MaxLength(80)]

        public string? Name { get; set; }
        [MaxLength(100)]
        public string? Description { get; set; }
    }
}

using SimplyFund.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Models.Customer
{
    public class CustomerType : BaseEntity
    {
        [Required, MaxLength(80)]
        public required string CustomerTypeName { get; set; }
        [MaxLength(100)]
        public string? Description { get; set; }

    }
}

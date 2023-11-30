using SimplyFund.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Models.Common
{
    public class IdentityType : EntityBase
    {
        [Required, MaxLength(80)]

        public required string IdentityName { get; set; }
        [MaxLength(100)]
        public string? Description { get; set; }
    }
}

using SimplyFund.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Models.Common
{
    public class Period : EntityBase
    {
        [Required, MaxLength(100)]
        public required string Name { get; set; }
        [MaxLength(250)]
        public string? Description { get; set; }
    }
}

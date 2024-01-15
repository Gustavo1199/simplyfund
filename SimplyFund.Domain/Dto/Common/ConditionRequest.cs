using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Dto.Common
{
    public class ConditionRequest
    {
        [Required]
        public decimal? Amount { get; set; }
        [Required]

        public string? Warranty { get; set; }
        [Required]

        public string? Period { get; set; }
        [Required]

        public string? Installments { get; set; }
        [Required]

        public int? CurrencyId { get; set; }
    }
}

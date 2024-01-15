using SimplyFund.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Models.Common
{
    public class Expense : EntityBase
    {
        [Required]
        [MaxLength(50)]
        public string? ExpenseName { get; set; }
        [Required]
        [MaxLength(250)]
        public string? Condition { get; set; }
        public int BadgeId { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public double Amount { get; set; }

        public virtual Badge? Badge { get; set; }

    }
}

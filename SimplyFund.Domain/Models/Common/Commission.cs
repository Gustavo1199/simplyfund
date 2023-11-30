using SimplyFund.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Models.Common
{
    public class Commission : EntityBase
    {
        public decimal AnnualPercentage { get; set; }
        public int BadgeId { get; set; }
        public decimal MinimumAmount { get; set; }
        public decimal MaximumAmount { get; set; }
        public string? Notes { get; set; }
        public virtual Badge? Badge { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Dto.Common
{

    public class ExpenseDto
    {
        public int Id { get; set; }
        public string? ExpenseName { get; set; }
        public string? Condition { get; set; }
        public int BadgeId { get; set; }
        public double Amount { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool IsActive { get; set; }
        public BadgeDto? Badge { get; set; }
    }

}

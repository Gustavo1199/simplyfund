using SimplyFund.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Models.Funds
{
    public class Fund : EntityBase
    {
        public int CustomerId { get; set; }
        public decimal? ActualLimit { get; set; }
        public decimal? AmountOccupied { get; set; }
    }
}

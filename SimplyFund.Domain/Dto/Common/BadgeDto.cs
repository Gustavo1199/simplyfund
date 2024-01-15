using SimplyFund.Domain.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Dto.Common
{
    public class BadgeDto : EntityBaseDto
    {
        public string? Currency { get; set; }
        public string? Symbol { get; set; }
        public string? Iso4217 { get; set; }

        public double Rate { get; set; }
    }
}

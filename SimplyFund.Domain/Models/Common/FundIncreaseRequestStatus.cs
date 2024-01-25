using SimplyFund.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Models.Common
{
    public class FundIncreaseRequestStatus : EntityBase
    {
        public string? Description { get; set; }
    }
}

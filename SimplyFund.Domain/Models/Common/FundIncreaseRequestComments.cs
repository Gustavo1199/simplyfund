using SimplyFund.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Models.Common
{
    public class FundIncreaseRequestComments : EntityBase
    {
        public string? Comment { get; set; }

        public int? FundIncreaseRequestId { get; set; }

    }
}

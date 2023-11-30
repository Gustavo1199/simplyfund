using SimplyFund.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Models.Common
{
    public class Bank : EntityBase
    {
        public string? Name { get; set; }
        public string? Headquarters { get; set; }
    }
}

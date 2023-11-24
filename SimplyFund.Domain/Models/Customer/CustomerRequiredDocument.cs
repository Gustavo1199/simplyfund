using SimplyFund.Domain.Base;
using SimplyFund.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Models.Customer
{
    public class CustomerRequiredDocument : EntityBase
    {
        public int CustomerTypeId { get; set; }
        public int DocumentId { get; set; }

        public virtual Document? Document { get; set; }

    }
}

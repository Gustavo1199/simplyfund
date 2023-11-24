using SimplyFund.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Models.Customer
{
    public class CustomerFile : EntityBase
    {
        public int CustomerTypeId { get; set; }
        public int DocumentId { get; set; }
        public int FileId { get; set; }
    }
}

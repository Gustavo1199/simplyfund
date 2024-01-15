using SimplyFund.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Models.Warrantys
{
    public class WarrantyField : EntityBase
    {
        public int WarrantyId { get; set; }
        public string? Field { get; set; }
        public virtual Warranty? Warranty { get; set; }

    }
}

using SimplyFund.Domain.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Dto.Warrantys
{
    public class WarrantyDto  : DtoBase
    {
        public string? Name { get; set; }
        public string? Document { get; set; }
    }
}

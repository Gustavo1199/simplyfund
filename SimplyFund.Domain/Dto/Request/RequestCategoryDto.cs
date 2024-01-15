using SimplyFund.Domain.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Dto.Request
{
    public class RequestCategoryDto : EntityBaseDto
    {
        public string? Name { get; set; }
    }
}

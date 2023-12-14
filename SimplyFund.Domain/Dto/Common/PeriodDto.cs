using SimplyFund.Domain.Dto.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Dto.Common
{
    public class PeriodDto : DtoBase
    {
        [Required, MaxLength(100)]
        public string? Name { get; set; }
        [MaxLength(250)]
        public string? Description { get; set; }
    }
}

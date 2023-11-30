using SimplyFund.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Models.Common
{
    public class Country : EntityBase
    {
        [StringLength(50)]
        public string? Name { get; set; }
    }
}

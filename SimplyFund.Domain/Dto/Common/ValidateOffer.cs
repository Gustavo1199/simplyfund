using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Dto.Common
{
    public class ValidateOffer
    {
        public int OfferId { get; set; }
        public string? Comment { get; set; }
        public int? UserId { get; set; }
    }
}

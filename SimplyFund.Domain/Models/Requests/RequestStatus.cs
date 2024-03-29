﻿using SimplyFund.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Models.Requests
{
    public class RequestStatus : EntityBase
    {
        [Required, MaxLength(80)]

        public string? Name { get; set; }
        [MaxLength(100)]
        public string? Description { get; set; }

        public bool? IsMarketPlace { get; set; }
        public bool? IsInvestments { get; set; }
        public bool? isRequest { get; set; }

    }
}

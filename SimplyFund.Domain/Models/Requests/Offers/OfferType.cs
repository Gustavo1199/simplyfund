﻿using SimplyFund.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Models.Requests.Offers
{
    public class OfferType : EntityBase
    {
        public string? Description { get; set; }
    }
}

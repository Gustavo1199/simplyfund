﻿using SimplyFund.Domain.Dto.Base;
using SimplyFund.Domain.Dto.Common;
using SimplyFund.Domain.Dto.File;
using SimplyFund.Domain.Models.Common;
using SimplyFund.Domain.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Dto.Request
{
    public class RequestDto : DtoBase
    {
        public string? RequestCategoryId { get; set; }

        public string? Description { get; set; }
        public string? Name { get; set; }
        public double AnnualInterest { get; set; }

        public double Amount { get; set; }

        public bool IsNegotiable { get; set; }

        public List<FileDto>? WarrantyFiles { get; set; }

        public  virtual PeriodDto? Period { get; set; }
        public virtual RequestCategoryDto? RequestCategory { get; set; }


    }
}

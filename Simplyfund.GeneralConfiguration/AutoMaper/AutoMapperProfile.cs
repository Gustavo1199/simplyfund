using AutoMapper;
using SimplyFund.Domain.Dto.Common;
using SimplyFund.Domain.Dto.File;
using SimplyFund.Domain.Dto.Request;
using SimplyFund.Domain.Models.Common;
using SimplyFund.Domain.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplyfund.GeneralConfiguration.AutoMaper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        
        {

            CreateMap<FileDto, SimplyFund.Domain.Models.Common.File>();
            CreateMap<RequestDto, Request>().ReverseMap();
            CreateMap<Period, PeriodDto>();
            CreateMap<RequestCategory, RequestCategoryDto>();

        }
    }
}

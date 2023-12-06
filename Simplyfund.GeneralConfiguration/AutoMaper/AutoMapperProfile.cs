using AutoMapper;
using SimplyFund.Domain.Dto.File;
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

        }
    }
}

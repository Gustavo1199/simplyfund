using AutoMapper;
using SimplyFund.Domain.Dto.Common;
using SimplyFund.Domain.Dto.Customer;
using SimplyFund.Domain.Dto.File;
using SimplyFund.Domain.Dto.Request;
using SimplyFund.Domain.Dto.Request.Offers;
using SimplyFund.Domain.Dto.Request.Offers.AddedOffers;
using SimplyFund.Domain.Dto.Warrantys;
using SimplyFund.Domain.Models.Client;
using SimplyFund.Domain.Models.Common;
using SimplyFund.Domain.Models.Requests;
using SimplyFund.Domain.Models.Requests.Offers;
using SimplyFund.Domain.Models.Requests.Offers.AddedOffers;
using SimplyFund.Domain.Models.Warrantys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = SimplyFund.Domain.Models.Common.File;

namespace Simplyfund.GeneralConfiguration.AutoMaper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        
        {
            CreateMap<FileDto, File>();

            CreateMap<FileDto,File>().ReverseMap();
            CreateMap<File,FileDto > ().ReverseMap();
            CreateMap<RequestDto, Request>().ReverseMap();
            CreateMap<Period, PeriodDto>();
            CreateMap<RequestCategory, RequestCategoryDto>();
            CreateMap<RequestDatailsDto, Request>().ReverseMap();
            CreateMap<OfferRequestDto, OfferRequest>().ReverseMap();
            CreateMap<Customer, CustomerDto>();
            CreateMap<Badge, BadgeDto>();
            CreateMap<RequestStatus, RequestStatusDto>();
            CreateMap<Warranty, WarrantyDto>();
            CreateMap<ExpenseDto, Expense>().ReverseMap();
            CreateMap<OffersRequestsCommentDto, OffersRequestsComment>().ReverseMap();
            CreateMap<AddedOfferDto, AddedOffer>().ReverseMap();





        }
    }
}

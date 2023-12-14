using AutoMapper;
using Simplyfund.Bll.Services.BaseServices;
using Simplyfund.Bll.ServicesInterface.Requests;
using Simplyfund.Dal.DataInterface.IBaseDatas;
using SimplyFund.Domain.Base.Filter;
using SimplyFund.Domain.Dto.Request;
using SimplyFund.Domain.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplyfund.Bll.Services.Requests
{
    public class ServicesRequest : BaseService<Request>, IServicesRequest
    {
        IBaseDatas<Request> baseModel;
        IMapper mapper;
        public ServicesRequest(IBaseDatas<Request> baseModel, IMapper mapper) : base(baseModel)
        {
            this.baseModel = baseModel;
            this.mapper = mapper;
        }

        public async Task<PaginatedList<RequestDto>?> RequestLists(FilterAndPaginateRequestModel? filters)
        {
            try
            {

                if (filters != null)
                {
                    var requests = await baseModel.FilterAndPaginateAsync(filters);
                    if (requests != null)
                    {
                        var map = mapper.Map<List<RequestDto>>(requests.Items);
                        PaginatedList<RequestDto> paginated = new PaginatedList<RequestDto>(map, requests.TotalPages, requests.PageIndex, filters.PageSize);

                        return paginated;


                    }
                    else
                    {
                        return null;
                    }



                }
                else
                {

                    throw new Exception("Filtro no pueden estar null");

                }


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message ?? ex.InnerException.Message);
            }
        }





    }
}

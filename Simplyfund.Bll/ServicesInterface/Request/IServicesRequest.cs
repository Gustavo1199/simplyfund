using Simplyfund.Bll.ServicesInterface.IBaseServices;
using SimplyFund.Domain.Base.Filter;
using SimplyFund.Domain.Dto.Request;
using SimplyFund.Domain.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using request1 = SimplyFund.Domain.Models.Requests.Request;


namespace Simplyfund.Bll.ServicesInterface.Requests
{
    public interface IServicesRequest : IBaseServices<request1>
    {
        Task<PaginatedList<RequestDto>?> RequestLists(FilterAndPaginateRequestModel? filters);

        Task<RequestDatailsDto> GetByIdDetailsAsync(int id,int? userId);
    }
}

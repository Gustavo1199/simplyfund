using Simplyfund.Bll.ServicesInterface.IBaseServices;
using SimplyFund.Domain.Base.Filter;
using SimplyFund.Domain.Dto.Request;
using SimplyFund.Domain.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplyfund.Bll.ServicesInterface.Requests
{
    public interface IServicesRequest : IBaseServices<Request>
    {
        Task<PaginatedList<RequestDto>?> RequestLists(FilterAndPaginateRequestModel? filters);
    }
}

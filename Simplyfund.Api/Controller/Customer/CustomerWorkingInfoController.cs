using Microsoft.AspNetCore.Mvc;
using Simplyfund.Api.Controller.BaseController;
using Simplyfund.Bll.ServicesInterface.IBaseServices;
using SimplyFund.Domain.Models.Customer;

namespace Simplyfund.Api.Controller.Customer
{
    [Route("api/[controller]")]
    public class CustomerWorkingInfoController : BaseController<CustomerWorkingInfo>
    {
        public CustomerWorkingInfoController(IBaseServices<CustomerWorkingInfo> baseServices) : base(baseServices)
        {
        }
    }
}

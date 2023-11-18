using Microsoft.AspNetCore.Mvc;
using Simplyfund.Api.Controller.BaseController;
using Simplyfund.Bll.ServicesInterface.IBaseServices;
using SimplyFund.Domain.Models.Client;

namespace Simplyfund.Api.Controller.Client
{
    [Route("api/[controller]")]
    public class ClientController : BaseController<Customer>
    {
        public ClientController(IBaseServices<Customer> baseServices) : base(baseServices)
        {
        }
    }
}

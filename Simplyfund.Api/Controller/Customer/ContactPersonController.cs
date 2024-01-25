using Microsoft.AspNetCore.Mvc;
using Simplyfund.Api.Controller.BaseController;
using Simplyfund.Bll.ServicesInterface.IBaseServices;
using SimplyFund.Domain.Models.Common;

namespace Simplyfund.Api.Controller.Customer
{
    [Route("api/[controller]")]

    public class ContactPersonController : BaseController<ContactPerson>
    {
        public ContactPersonController(IBaseServices<ContactPerson> baseServices) : base(baseServices)
        {
        }
    }
}

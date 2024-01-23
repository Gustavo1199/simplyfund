using Microsoft.AspNetCore.Mvc;
using Simplyfund.Api.Controller.BaseController;
using Simplyfund.Bll.ServicesInterface.IBaseServices;
using SimplyFund.Domain.Models.Common;

namespace Simplyfund.Api.Controller.Common
{
    [ApiController]
    [Route("api/Common/[Controller]")]
    public class BankAccountController : BaseController<BankAccount>
    {

        public BankAccountController(IBaseServices<BankAccount> baseServices) : base(baseServices)
        {
        }
    }
}

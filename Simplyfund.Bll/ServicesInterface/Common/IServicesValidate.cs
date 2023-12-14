using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplyfund.Bll.ServicesInterface.Common
{
    public interface IServicesValidate
    {
        Task<bool> ValidateidentityNumber(string identityValue);
        Task<bool> ValidateEmail(string emailValue);
    }
}

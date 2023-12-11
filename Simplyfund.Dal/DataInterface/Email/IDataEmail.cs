using SimplyFund.Domain.Dto.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplyfund.Dal.DataInterface.Email
{
    public interface IDataEmail
    {
        Task SendMail(RequestEmail request);
    }
}

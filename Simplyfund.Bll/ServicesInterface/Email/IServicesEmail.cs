using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplyfund.Bll.ServicesInterface.Email
{
    public interface IServicesEmail
    {
        Task<string> SendMail(string json);
    }
}

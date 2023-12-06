using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplyfund.Bll.ServicesInterface.Auth
{
    public interface IServicesRol
    {
        Task<bool?> AssignUserRole(string userId, string roleName);
    }
}

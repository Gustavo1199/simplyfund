using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplyfund.Dal.DataInterface.Auth
{
    public interface IDataRol
    {
        Task<bool> AssignUserRole(string userId, string roleName);

    }
}

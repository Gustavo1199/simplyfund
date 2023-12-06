using Simplyfund.Bll.ServicesInterface.Auth;
using Simplyfund.Dal.Data.Auth;
using Simplyfund.Dal.DataInterface.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplyfund.Bll.Services.Auth
{
    public class ServicesRol : IServicesRol
    {
        private readonly IDataRol dataRol;
        public ServicesRol(IDataRol dataRol)
        {
            this.dataRol = dataRol;
        }

        public async Task<bool?> AssignUserRole(string userId, string roleName)
        {
            try
            {
                return await dataRol.AssignUserRole(userId, roleName);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}

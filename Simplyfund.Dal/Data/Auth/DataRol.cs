using Microsoft.AspNetCore.Identity;
using Simplyfund.Dal.DataInterface.Auth;
using SimplyFund.Domain.Dto.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplyfund.Dal.Data.Auth
{
    public class DataRol : IDataRol
    {
        private readonly UserManager<User> _userManager;

        public DataRol(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> AssignUserRole(string userName, string roleName)
        {
            var usuario = await _userManager.FindByNameAsync(userName);

            if (usuario != null)
            {
                var result = await _userManager.AddToRoleAsync(usuario, roleName);

                if (result.Succeeded)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new Exception($"Usuario con ID {userName} no encontrado.");
            }
        }

    }
}

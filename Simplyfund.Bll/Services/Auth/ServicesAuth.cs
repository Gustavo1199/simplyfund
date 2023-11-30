using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Simplyfund.Bll.ServicesInterface.Auth;
using Simplyfund.Dal.Data.IBaseDatas.Auth;
using SimplyFund.Domain.Dto.Login;
using SimplyFund.Domain.Dto.Responses;
using SimplyFund.Domain.Models.Auth;
using SimplyFund.Domain.Models.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplyfund.Bll.Services.Auth
{
    public class ServicesAuth : IServicesAuth
    {
       
        private readonly IDataAuth dataAuth;

        public ServicesAuth(UserManager<User> userManager, IConfiguration configuration, IDataAuth dataAuth, RoleManager<Role> rolesManager)
        {
           
            this.dataAuth = dataAuth;
        }


        public async Task<LoginResponses> Login(LoginModel model)
        {
            try
            {          
               return await dataAuth.Login(model);
            }
            catch (Exception)
            {

                throw;
            }

        }  
        
        public async Task<bool> AssignUserRole(string userId, string roleName)
        {
            try
            {          
               return await dataAuth.AssignUserRole(userId,roleName);
            }
            catch (Exception)
            {

                throw;
            }

        }  

    }
}

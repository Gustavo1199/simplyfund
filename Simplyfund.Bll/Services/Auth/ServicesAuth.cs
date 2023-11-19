using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Simplyfund.Bll.ServicesInterface.Auth;
using Simplyfund.Dal.Data.IBaseDatas.Auth;
using SimplyFund.Domain.Dto.Login;
using SimplyFund.Domain.Dto.Responses;
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
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IDataAuth dataAuth;

        public ServicesAuth(UserManager<User> userManager, IConfiguration configuration, IDataAuth dataAuth)
        {
            _userManager = userManager;
            _configuration = configuration;
            this.dataAuth = dataAuth;
        }


        public async Task<LoginResponses> Login(LoginModel model)
        {
            try
            {
                LoginResponses login = new LoginResponses();

                var user = await _userManager.FindByNameAsync(model.UserName);

                if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    var token = await dataAuth.GenerateTokenAsync(user.Id,"Ernest","Admin");

                    login.token = token;
                    login.Expire = DateTime.Now.AddDays(1);
                    login.userId = user.UserId.ToString();
                    login.UserName = user.UserName;
                }
                return login;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}

using SimplyFund.Domain.Dto.Login;
using SimplyFund.Domain.Dto.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplyfund.Dal.Data.IBaseDatas.Auth
{
    public interface IDataAuth
    {
        Task<string> GenerateTokenAsync(string userId, string userName, List<string> roles);
        Task<LoginResponses> Login(LoginModel model);

        Task<bool> AssignUserRole(string userId, string roleName);
    }
}

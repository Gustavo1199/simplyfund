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
        Task<LoginResponses> Login(LoginModel model);
        Task<bool> ResetPassword(ResetPasswordDto model);
        Task<object> ForgotPassword(ForgotPasswordDto model);

        Task<string> CreateUser(User user);
    }
}

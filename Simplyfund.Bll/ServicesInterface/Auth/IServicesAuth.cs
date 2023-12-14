using SimplyFund.Domain.Dto.Login;
using SimplyFund.Domain.Dto.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplyfund.Bll.ServicesInterface.Auth
{
    public interface IServicesAuth
    {
        Task<object> ForgotPassword(ForgotPasswordDto model);
        Task<bool> ResetPassword(ResetPasswordDto model);
        Task<LoginResponses> Login(LoginModel loginModel);

        Task<bool> ChangePassword(ChangePasswordDto model);
    }
}

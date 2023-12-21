using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Dto.Login
{
    public class ChangePasswordDto
    {
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
        public string? Email { get; set; }
    }
}

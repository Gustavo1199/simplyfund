using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Dto.Login
{
    public class LoginModel
    {
        [Required]
        public required string UserName { get; set; }

        [Required]
        public required string Password { get; set; }
    }
}

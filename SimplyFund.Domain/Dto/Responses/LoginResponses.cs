using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Dto.Responses
{
    public class LoginResponses
    {
        public string? token { get; set; }
        public string? userId { get; set; }

        public DateTime? Expire {  get; set; }
        public string? UserName { get; set; }
    }
}

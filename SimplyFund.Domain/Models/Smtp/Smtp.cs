using SimplyFund.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Models.Smtp
{
    public class Smtp : EntityBase
    {
        public required string EmailAddress { get; set; }
        public string? Name { get; set; }
        public required string Server { get; set; }
        public int Port { get; set; }
        public bool UseSSL { get; set; }
        public bool UseDefaultCredentials { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public string? TestMail { get; set; }
    }
}

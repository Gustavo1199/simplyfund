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
        public string? EmailAddress { get; set; }
        public string? Name { get; set; }
        public string? Server { get; set; }
        public int Port { get; set; }
        public bool UseSSL { get; set; }
        public bool UseDefaultCredentials { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? TestMail { get; set; }
    }
}

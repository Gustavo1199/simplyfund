using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Dto.Email
{
    public class RequestEmail
    {
        public string? Subject { get; set; }
        public Dictionary<string, string>? Entity { get; set; }
        public string? code { get; set; }
        public List<string>? Recipients { get; set; }
        public required string? Action { get; set; }
        public required string? Module { get; set; }
        public string? Body { get; set; }
    }
}

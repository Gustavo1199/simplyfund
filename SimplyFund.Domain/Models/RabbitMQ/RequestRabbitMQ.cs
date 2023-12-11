using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Models.RabbitMQ
{
    public class RequestRabbitMQ
    {
        public string? queue {  get; set; }
        public string? exchange { get; set; }
        public string? routingkey { get; set; }
        public object? message { get; set; }
    }
}

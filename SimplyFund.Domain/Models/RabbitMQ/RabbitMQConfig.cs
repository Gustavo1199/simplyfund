using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Models.RabbitMQ
{
    //public class RabbitMQConfig
    //{
    //    public string? Host { get; set; }
    //    public int Port { get; set; }
    //    public string? UserName { get; set; }
    //    public string? Password { get; set; }
    //    public string? VirtualHost { get; set; }
    //    public string? Exchanges { get; set; }
    //    public string? Queues { get; set; }
    //    public string? RoutingKey { get; set; }
    //}


    public class Binding
    {
        public string? QueueName { get; set; }
        public string? ExchangeName { get; set; }
        public string? RoutingKey { get; set; }
    }

    public class Exchange
    {
        public string? Name { get; set; }
        public string? Type { get; set; }
        public bool Durable { get; set; }
    }

    public class Queue
    {
        public string? Name { get; set; }
        public bool Durable { get; set; }
        public bool Exclusive { get; set; }
        public bool AutoDelete { get; set; }
    }

    public class RabbitMQConfig
    {
        public string? Host { get; set; }
        public int Port { get; set; }
        public  string? UserName { get; set; }
        public string?  Password { get; set; }
        public string? VirtualHost { get; set; }
        public List<Exchange>? Exchanges { get; set; }
        public List<Queue>? Queues { get; set; }
        public List<Binding>? Bindings { get; set; }
    }
}

using Microsoft.Extensions.Configuration;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplyfund.Bll.Services.RabbitMQ
{
    public  class ConfigurationEmailConsumer
    {
        public static void AddEmailConsumer(IConfiguration configuration)
        {
            var factory = new ConnectionFactory
            {
                HostName = configuration.GetSection("Bus:RabbitMQ:Hostname").Value
            };

            var connection = factory.CreateConnection();

            using
            var channel = connection.CreateModel();

            channel.QueueDeclarePassive("emailQueue");

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, eventArgs) => {
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);


            };

            channel.BasicConsume(queue: "emailQueue", autoAck: true, consumer: consumer);
        }

    }
}

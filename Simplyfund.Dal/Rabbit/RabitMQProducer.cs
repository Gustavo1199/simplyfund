using EasyNetQ;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using SimplyFund.Domain.Models.RabbitMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplyfund.Dal.Rabbit
{
    public class RabitMQProducer : IRabitMQProducer
    {
        IConfiguration configuration;
        public RabitMQProducer(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void SendProductMessage(RequestRabbitMQ requestRabbitMQ)
        {
            try
            {

                var factory = new ConnectionFactory
                {
                    HostName = configuration.GetSection("Bus:RabbitMQ:Hostname").Value
                };

                var connection = factory.CreateConnection();
                using
                var channel = connection.CreateModel();


                channel.QueueDeclarePassive(requestRabbitMQ.queue);

                var json = JsonConvert.SerializeObject(requestRabbitMQ.message);
                var body = Encoding.UTF8.GetBytes(json);

                channel.BasicPublish(exchange: requestRabbitMQ.exchange, routingKey: requestRabbitMQ.routingkey, body: body);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

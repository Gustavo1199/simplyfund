using Castle.Core.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using Simplyfund.Bll.Services.Email;
using Simplyfund.Bll.ServicesInterface.Email;
using SimplyFund.Domain.Models.RabbitMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Simplyfund.GeneralConfiguration.Dependecy
{
    public static class ServicesRabbitmqRegistration
    {

        public static void AddRegisterRabbitmqProducer()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("RabbitMQConfig.json")
                .Build();

            var rabbitMQConfig = configuration.GetSection("RabbitMQ").Get<RabbitMQConfig>();

            if (rabbitMQConfig != null)
            {
                var factory = new ConnectionFactory
                {
                    HostName = rabbitMQConfig.Host
                 
                };

                using (var connection = factory.CreateConnection())
                {


                    using (var channel = connection.CreateModel())
                    {
                        if (rabbitMQConfig.Exchanges != null)
                        {
                            foreach (var exchangeConfig in rabbitMQConfig.Exchanges)
                            {
                                try
                                {
                                    channel.ExchangeDeclare(exchangeConfig.Name, exchangeConfig.Type, exchangeConfig.Durable);

                                }
                                catch (OperationInterruptedException)
                                {
                                    Console.WriteLine($"Exchange '{exchangeConfig.Name}' not found. Creating...");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Error handling Exchange '{exchangeConfig.Name}': {ex.Message}");
                                }
                            }
                        }

                        if (rabbitMQConfig.Queues != null)
                        {
                            foreach (var queueConfig in rabbitMQConfig.Queues)
                            {
                                try
                                {
                                    channel.QueueDeclare(queueConfig.Name, queueConfig.Durable, queueConfig.Exclusive, queueConfig.AutoDelete);
                                }
                                catch (OperationInterruptedException)
                                {
                                    Console.WriteLine($"Queue '{queueConfig.Name}' not found. Creating...");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Error handling Queue '{queueConfig.Name}': {ex.Message}");
                                }
                            }
                        }

                        if (rabbitMQConfig.Bindings != null)
                        {
                            foreach (var bindingConfig in rabbitMQConfig.Bindings)
                            {
                                try
                                {
                                    channel.QueueBind(bindingConfig.QueueName, bindingConfig.ExchangeName, bindingConfig.RoutingKey);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Error handling Binding '{bindingConfig.QueueName}': {ex.Message}");
                                }
                            }
                        }
                    }
                }
            }
        }

    
    }
}


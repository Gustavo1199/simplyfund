using Microsoft.AspNetCore.Connections;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SimplyFund.Mail.Controllers.Email;
using System.Text;
using Simplyfund.GeneralConfiguration.Dependecy;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRegister(builder.Configuration);
builder.Services.AddScoped<EmailController>();


if (builder.Services != null)
{
    IServiceProvider serviceProvider = builder.Services.BuildServiceProvider();

    ConfigureRabbitMQConsumer(serviceProvider);
}


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//void ConfigureRabbitMQConsumer(IServiceProvider services, IServiceCollection servicesCollection)
//{
//    var factory = new ConnectionFactory() { HostName = "localhost" };

//    using (var connection = factory.CreateConnection())
//    using (var channel = connection.CreateModel())
//    {
//        var exchangeName = "emailexchange";
//        var queueName = "emailqueue";

//        channel.ExchangeDeclare(exchange: exchangeName, type: ExchangeType.Fanout);
//        channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
//        channel.QueueBind(queue: queueName, exchange: exchangeName, routingKey: "");

//        Console.WriteLine($"[*] Esperando mensajes en la cola '{queueName}'. Para salir, presiona CTRL+C");

//        var consumer = new EventingBasicConsumer(channel);
//        consumer.Received += (model, ea) =>
//        {
//            var body = ea.Body.ToArray();
//            var message = Encoding.UTF8.GetString(body);

           
         
//        };

//        channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
//    }




//}


void ConfigureRabbitMQConsumer(IServiceProvider services)
{

        var controller = services.GetService<EmailController>();
        if (controller != null)
        {
             controller.RecibeImagen();
        }
    
}
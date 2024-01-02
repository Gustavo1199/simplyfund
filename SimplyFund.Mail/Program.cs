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

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureRabbitMQConsumer(IServiceProvider services)
{

        var controller = services.GetService<EmailController>();
        if (controller != null)
        {
             controller.InitializeConsumerEmail();
        }
    
}
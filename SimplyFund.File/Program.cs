using Simplyfund.GeneralConfiguration.Dependecy;
using SimplyFund.File.Controllers.File;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRegister(builder.Configuration);
builder.Services.AddScoped<FileController>();

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
app.UseStaticFiles();
app.MapControllers();

app.Run();



void ConfigureRabbitMQConsumer(IServiceProvider services)
{

    var controller = services.GetService<FileController>();
    if (controller != null)
    {
        controller.InitializeConsumerFiles();
    }

}

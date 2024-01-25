using Simplyfund.GeneralConfiguration.Dependecy;
using SimplyFund.File.Controllers.File;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRegister(builder.Configuration);
builder.Services.AddScoped<FileController>();

if (builder.Services != null)
{
    IServiceProvider serviceProvider = builder.Services.BuildServiceProvider();

    ConfigureRabbitMQConsumer(serviceProvider);
}


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins().AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors();

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

using Microsoft.OpenApi.Models;
using Simplyfund.Bll.Services.BaseServices;
using Simplyfund.Bll.ServicesInterface.IBaseServices;
using Simplyfund.GeneralConfiguration.Dependecy;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSwaggerGen(options =>
{
    options.MapType<SimplyFund.Domain.Dto.ViaFirma.Document>(() => new OpenApiSchema { Type = "Documents" });

    options.ResolveConflictingActions(apiDescription =>
    {
        var firstAction = apiDescription.First();
        return firstAction;
    });
});

//ServicesRabbitmqRegistration.AddRegisterRabbitmqProducer();

builder.Services.AddControllers();

builder.Services.AddRegister(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("*")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});

var app = builder.Build();



// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();




app.UseHttpsRedirection();

app.UseCors();


app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.Run();

app.Run();


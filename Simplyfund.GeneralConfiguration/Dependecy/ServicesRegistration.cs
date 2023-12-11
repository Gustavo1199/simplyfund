using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Simplyfund.Bll.Services.Auth;
using Simplyfund.Bll.Services.BaseServices;
using Simplyfund.Bll.Services.Common;
using Simplyfund.Bll.Services.Customers;
using Simplyfund.Bll.Services.Email;
using Simplyfund.Bll.Services.Files;
using Simplyfund.Bll.Services.ViaFirma;
using Simplyfund.Bll.ServicesInterface.Auth;
using Simplyfund.Bll.ServicesInterface.Common;
using Simplyfund.Bll.ServicesInterface.Customers;
using Simplyfund.Bll.ServicesInterface.Email;
using Simplyfund.Bll.ServicesInterface.File;
using Simplyfund.Bll.ServicesInterface.IBaseServices;
using Simplyfund.Bll.ServicesInterface.ViaFirma;
using Simplyfund.Dal.Data.Auth;
using Simplyfund.Dal.Data.BaseData;
using Simplyfund.Dal.Data.Email;
using Simplyfund.Dal.Data.IBaseDatas.Auth;
using Simplyfund.Dal.Data.ViaFirma;
using Simplyfund.Dal.DataBase;
using Simplyfund.Dal.DataInterface.Auth;
using Simplyfund.Dal.DataInterface.Email;
using Simplyfund.Dal.DataInterface.IBaseDatas;
using Simplyfund.Dal.DataInterface.ViaFirma;
using Simplyfund.Dal.Rabbit;
using Simplyfund.GeneralConfiguration.AutoMaper;
using SimplyFund.Domain.Dto.Login;
using SimplyFund.Domain.Models.Auth;
using SimplyFund.Domain.Models.Client;
using System;
using System.Data;
using System.Text;

namespace Simplyfund.GeneralConfiguration.Dependecy
{
    public static class ServicesRegistration
    {
        public static void AddRegister(this IServiceCollection services, IConfiguration configuration)
        {

            #region automapper

            services.AddAutoMapper(typeof(AutoMapperProfile));

            #endregion

            #region context

            services.AddDbContext<SimplyfundDbContext>(options =>
                options.UseLazyLoadingProxies().UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure();
                }),ServiceLifetime.Scoped);

            

            #endregion

            //Dependecy Inyeccion
            #region services
            services.AddScoped(typeof(IBaseServices<>), typeof(BaseService<>));
            services.AddScoped<IServicesAuth, ServicesAuth>();
            services.AddScoped<IServicesOptions, ServicesOptions>();
            services.AddScoped<IServiceCustomer, ServiceCustomer>();
            services.AddScoped<IServicesViaFirma, ServicesViaFirma>();
            services.AddScoped<IServicesRol, ServicesRol>();
            services.AddScoped<IServicesFile, ServicesFile>();
            services.AddScoped<IServicesEmail, ServicesEmail>();
        



            #endregion

            #region data
            services.AddScoped(typeof(IBaseDatas<>), typeof(BaseDatas<>));
            services.AddScoped<IDataAuth, DataAuth>();
            services.AddScoped<IDataViafirma, DataViaFirma>(); 
            services.AddScoped<IDataRol, DataRol>();
            services.AddScoped<IDataEmail, DataEmail>();
        
            services.AddScoped<IRabitMQProducer, RabitMQProducer>();
       



            #endregion

            #region autentication

            services.AddIdentity<User, Role >()
                    .AddEntityFrameworkStores<SimplyfundDbContext>()
                    .AddDefaultTokenProviders();


            services.Configure<IdentityOptions>(options =>
            {
                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;

                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;

                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;

                options.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultProvider;
                options.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultProvider;
                options.Tokens.ChangeEmailTokenProvider = TokenOptions.DefaultProvider;

            });



            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "your-issuer",
                    ValidAudience = "your-audience",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your-secret-key"))
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
                options.AddPolicy("Customer", policy => policy.RequireRole("Customer"));
                options.AddPolicy("Analyst", policy => policy.RequireRole("Analyst"));
            });



            #endregion


            #region generalconfig

            services.AddHttpClient();

            services.AddControllersWithViews()
            .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
            #endregion

        }

    }
}

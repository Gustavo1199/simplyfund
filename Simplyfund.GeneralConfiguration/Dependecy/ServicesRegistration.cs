﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Simplyfund.Bll.Services.Auth;
using Simplyfund.Bll.Services.BaseServices;
using Simplyfund.Bll.Services.Common;
using Simplyfund.Bll.Services.Customers;
using Simplyfund.Bll.ServicesInterface.Auth;
using Simplyfund.Bll.ServicesInterface.Common;
using Simplyfund.Bll.ServicesInterface.Customers;
using Simplyfund.Bll.ServicesInterface.IBaseServices;
using Simplyfund.Dal.Data.Auth;
using Simplyfund.Dal.Data.BaseData;
using Simplyfund.Dal.Data.IBaseDatas;
using Simplyfund.Dal.Data.IBaseDatas.Auth;
using Simplyfund.Dal.DataBase;
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
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            #endregion

            //Dependecy Inyeccion
            #region services
            services.AddScoped(typeof(IBaseServices<>), typeof(BaseService<>));
            services.AddScoped<IServicesAuth, ServicesAuth>();
            services.AddScoped<IServicesOptions, ServicesOptions>();
            services.AddScoped<IServiceCustomer, ServiceCustomer>();
            #endregion

            #region data
            services.AddScoped(typeof(IBaseDatas<>), typeof(BaseDatas<>));
            services.AddScoped<IDataAuth, DataAuth>();


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



        }

    }
}

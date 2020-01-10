﻿using System;
using System.Text;
using GolFullStack.Integration.Data;
using GolFullStack.Integration.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace GolFullStack.Integration.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)        {            services.AddDbContext<ApplicationDbContext>(options =>            {                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));            });            services.AddDefaultIdentity<IdentityUser>()                .AddRoles<IdentityRole>()                .AddEntityFrameworkStores<ApplicationDbContext>()                .AddErrorDescriber<IdentityMessagePortuguese>()                .AddDefaultTokenProviders();

            //Json Web Token (JWT)

            var appSettingsSection = configuration.GetSection("AppSettings");            services.Configure<AppSettings>(appSettingsSection);            var appSettings = appSettingsSection.Get<AppSettings>();            var Key = Encoding.ASCII.GetBytes(appSettings.Secret);            services.AddAuthentication(x =>            {                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;            }).AddJwtBearer(x =>            {                x.RequireHttpsMetadata = false;                x.SaveToken = true;                x.TokenValidationParameters = new TokenValidationParameters                {                    ValidateIssuerSigningKey = true,                    IssuerSigningKey = new SymmetricSecurityKey(Key),                    ValidateAudience = true,                    ValidAudience = appSettings.ValidIn,                    ValidIssuer = appSettings.Emissor                };            });            return services;        }
    }
}

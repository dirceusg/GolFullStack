using System;
using GolFullStack.Domain.Repository.Interface.Business;
using GolFullStack.Domain.Service.Interface.Business;
using GolFullStack.Domain.Service.Service.Business;
using GolFullStack.Domain.Validation.GolValidation;
using GolFullStack.Domain.Validation.GolValidation.Interface;
using GolFullStack.Repository.Context;
using GolFullStack.Repository.Repository.Business;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace GolFullStack.Integration.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)        {            services.AddScoped<GolContext>();            services.AddScoped<INotification, Notifier>();




            #region Repository

            #region business

            services.AddScoped<IAirplaneRepository, AirplaneRepository>();

            #endregion

            #endregion

            #region Service

            #region business

            services.AddScoped<IAirplaneService, AirplaneService>();

            #endregion

            #endregion

            #region Swagger

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();


            #endregion

            return services;        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Persons.Application.Application;
using Persons.Application.Interface;
using Persons.CrossCutting.WebApiServices;
using Persons.Domain.Interfaces;
using Persons.Domain.Services;
using Persons.Infra.Data.Context;
using Persons.Infra.Data.Repositories;
using Persons.Infra.Data.UoW;

namespace Persons.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IWebApiService, WebApiService>();

            services.AddScoped<IAccountApplication, AccountApplication>();

            services.AddScoped<IAccountService, AccountService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void UseSwaggerCustom(this IApplicationBuilder application)
        {
            application.UseSwagger();
            application.UseSwaggerUI(cfg => cfg.SwaggerEndpoint("/swagger/api/swagger.json", "API"));
        }
    }
}

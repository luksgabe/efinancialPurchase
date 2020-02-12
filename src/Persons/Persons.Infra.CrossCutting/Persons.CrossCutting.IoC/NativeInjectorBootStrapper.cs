using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Persons.Application.Application;
using Persons.Application.AutoMapper;
using Persons.Application.Interface;
using Persons.CrossCutting.Security.Hash;
using Persons.CrossCutting.WebApiServices;
using Persons.Domain.Interfaces;
using Persons.Domain.Services;
using Persons.Infra.Data.Context;
using Persons.Infra.Data.UoW;
using System;

namespace Persons.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            AddAutoMapperSetup(services);

            services.AddSingleton<IHash, Hash>();

            services.AddSingleton<IWebApiService, WebApiService>();

            services.AddScoped<IAccountApplication, AccountApplication>();
            services.AddScoped<IUserApplication, UserApplication>();

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ApplicationDbContext>();
        }

        public static void UseSwaggerCustom(this IApplicationBuilder application)
        {
            application.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "Persons");
            });
        }

        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var mappingConfig = AutoMapperConfig.RegisterMappings();
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}

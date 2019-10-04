using Microsoft.Extensions.DependencyInjection;
using Persons.Domain.Interfaces;
using Persons.Infra.Data.Context;
using Persons.Infra.Data.UoW;

namespace Persons.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ApplicationDbContext>();

        }
    }
}

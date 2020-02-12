using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persons.CrossCutting.IoC;
using Persons.Infra.Data.Context;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.Hosting;
using DotNetCore.AspNetCore;

namespace Persons.Ui.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddCors();
            services.AddControllers();
            //services.AddMvcJson();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            RegisterServices(services);
            services.AddSwaggerDocument();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                //app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //app.UseAuthorization();
            app.UseOpenApi();
            app.UseSwaggerCustom();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }

        private static void RegisterServices(IServiceCollection services)
        {
            //Adiciona dependencias de outras camadas (isolada da camada Ux)
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}

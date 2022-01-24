using AutoMapper;
using System;
using System.IO;
using System.Reflection;
using dotnet6_web_api.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace web_api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // Add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("defaultConnectionLocal")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new() { Title = "web_api", Version = "v1" });

                //Configura archivo xml para documentación
                var archivoXML = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var rutaXML = Path.Combine(AppContext.BaseDirectory, archivoXML);
                c.IncludeXmlComments(rutaXML);
            });

            services.AddAutoMapper(typeof(Startup));
        }

        // Configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "web_api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

    }
}
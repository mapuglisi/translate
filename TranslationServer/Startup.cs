using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace TranslationServer
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
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
            services.AddControllers();
            
            AddSwagger(services);
            
            services.AddControllers().AddNewtonsoftJson();

            services.AddCors(options =>
            {
                //  For debug reasons, when in production this should be handled in a better manner
                options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Removing https redirections due to localhost implementation
            // Once in a production environment with real signed certificates this can be used again
            //app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Foo API V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            // Due to local implementation using http, allow CORS, In production implementation this should change 
            app.UseCors("Open");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"Translation service {groupName}",
                    Version = groupName,
                    Description = "A translation service API",
                    Contact = new OpenApiContact
                    {
                        Name = "MP Consultants",
                        Email = string.Empty,
                        Url = new Uri("https://www.linkedin.com/in/mariopu91"),
                    }
                });
            });
            services.AddSwaggerGenNewtonsoftSupport();
        }
    }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}

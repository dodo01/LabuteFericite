using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabuteCalatoare.Infrastructure.EnvironmentUtils;
using LabuteFericite.WebApi.Filters;
using LabuteFericite.WebApi.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace LabuteFericite
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public LabuteCalatoare.DataBase.Initialization.Startup dbStartup = new LabuteCalatoare.DataBase.Initialization.Startup();

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
           
            dbStartup.ConfigureServices(services, Configuration.GetConnectionString("Database"));
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile(EnvironmentVariableUtils.DefineConfigFile()).Build();
            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(EntityNotFoundExceptionFilterAttribute));
            })
            .AddNewtonsoftJson(option =>
            {
                option.SerializerSettings.ContractResolver = new DefaultContractResolver();
                option.SerializerSettings.Converters.Add(new StringEnumConverter());
                option.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });


            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "LabuteFericite API", Version = "v1" });

            });
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSwagger();
            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint("/swagger/v1/swagger.json", "LabuteFericite v1");
                option.RoutePrefix = String.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseMiddleware(typeof(ExceptionHandlingMiddleware));
           
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

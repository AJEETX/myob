﻿using Swashbuckle.AspNetCore.Examples;
using MYOB.Demo.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System.Reflection;
using System.IO;
using System;
using MYOB.Demo.Domain;

namespace MYOB.Demo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ISalaryConfigService, SalaryConfigService>()
                .AddScoped<ISalaryRatesService, SalaryRatesService>()
                .AddScoped<ISalaryTaxTableHandler, SalaryTaxTableHandler>()
                .AddScoped<ISalaryService, SalaryService>()
                .AddScoped<ISalaryCalculatorService, SalaryCalculatorService>();

            services.AddSwaggerGen(config => {
                config.SwaggerDoc("v1", new Info { Title = "MYOB Demo API", Version = "V1" });
                config.OperationFilter<ExamplesOperationFilter>();
                config.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
            });

            services.AddMvc();
            //// Add our Config object so it can be injected
            //services.Configure<SalaryTaxTableHandlers>(Configuration.GetSection("SalaryTaxTableHandlers"));
            //// *If* you need access to generic IConfiguration this is **required**
            //services.AddSingleton(Configuration);
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc().UseSwagger().UseSwaggerUI(config => {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "MYOB Demo API");
            });
        }
    }
}

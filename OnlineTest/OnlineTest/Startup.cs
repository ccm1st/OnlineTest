﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OnlineTest.Service.Implementation;
using OnlineTest.Service.Interface;
using Refit;

namespace OnlineTest
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
            services.AddMvc();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ITrolleyService, TrolleyService>();
            services.AddScoped<IProductAPI>(s =>
            {
                return RestService.For<IProductAPI>(Configuration["ResourceEndpoint"]);
            });
            services.AddScoped<IShopperHistoryAPI>(s =>
            {
                return RestService.For<IShopperHistoryAPI>(Configuration["ResourceEndpoint"]);
            });
            services.AddScoped<ITrolleyAPI>(s =>
            {
                return RestService.For<ITrolleyAPI>(Configuration["ResourceEndpoint"]);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

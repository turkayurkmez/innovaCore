﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using miniShop.Business;
using miniShop.DataAccess.Repositories;
using miniShop.EFCore;
using miniShop.Infrastructure;
using miniShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniShop
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
            services.AddControllersWithViews();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepostiory, FakeProductRepository>();
            services.AddScoped<IRepository<Category>, FakeCategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();

            var connectionString = Configuration.GetConnectionString("db");
            services.AddDbContext<InnovaShopDbContext>(opt => opt.UseSqlServer(connectionString));


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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //Tüm pipeline'ı tek bir middleware'e yönlendir:
            //app.Run(async (context) =>
            //{
            //    context.Response.ContentType = "text/plain";
            //    await  context.Response.WriteAsync("Talep middleware'a ulasti");
            //});

            app.Map("/test", async (appBuilder) =>
            {
                appBuilder.Run(async (context) =>
                {
                    if (context.Request.Query.ContainsKey("flag"))
                    {
                        context.Response.ContentType = "text/utf8";
                        await context.Response.WriteAsync($"Flag değeri: {context.Request.Query["flag"]} olarak geldi");
                    }
                    else
                    {
                        await context.Response.WriteAsync($"Flag değeri gelmediği  için test yapılamadı");

                    }
                });
            });

            app.UseMiddleware<ResponseDirectMiddleware>();

            // app.UseWelcomePage();

            app.UseHttpsRedirection().UseStaticFiles().UseRouting();


            // app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "",
                    pattern: "Products/category{categoryId}",
                    defaults: new { controller = "Home", action = "Index" }
                    );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApniShop.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ApniShop
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
            services.AddDbContext<RegistrationAppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Myconnection")));
            services.AddDbContext<LoginAppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Myconnection")));
            services.AddDbContext<ProductAppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Myconnection")));
            services.AddDbContext<ProductImageAppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Myconnection")));
            services.AddDbContext<Sell_Item_Context>(options => options.UseSqlServer(Configuration.GetConnectionString("Myconnection")));
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=LandingPage}/{action=LandingPage}/{id?}");
            });
        }
    }
}

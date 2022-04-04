using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Projek_UTSAren.Data;
using Projek_UTSAren.Repositories.AlumniRepository;
using Projek_UTSAren.Services.AlumniService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projek_UTSAren
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
            services.AddDbContext<AppDbContext>(o =>
            {
                o.UseMySQL(Configuration.GetConnectionString("mysql"));
            });

            services.AddAuthentication("CookieAuth")
                .AddCookie("CookieAuth", options =>
                {
                    options.LoginPath = "/Akun/Masuk";
                });

            services.AddScoped<IAlumniService, AlumniService>();
            services.AddScoped<IAlumniRepository, AlumniRepository>();

            services.AddControllersWithViews();
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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Akun}/{action=Masuk}/{id?}");
            });
        }
    }
}

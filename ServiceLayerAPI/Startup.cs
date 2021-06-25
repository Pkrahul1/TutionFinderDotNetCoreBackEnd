using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace ServiceLayerAPI
{ 
    public class Startup
    {
        public IConfiguration _config { get; }

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>(
               options => options.UseSqlServer(_config.GetConnectionString("UserDBConnection")));
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>() ;
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<ITeacherRepository, TeacherRepository>();
            services.AddTransient<ICommonRepository, CommonRepository>();
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
            app.UseAuthentication();//adding authentication before mvc middleware.
            app.UseMvcWithDefaultRoute();//will open index in home controller at local url if no attribute at controller and method used
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello,no middleware to handle request, this if from default middleware");
            });
        }
    }
}

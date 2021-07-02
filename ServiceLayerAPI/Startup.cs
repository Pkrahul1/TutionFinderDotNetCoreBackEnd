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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Security.Claims;
using ServiceLayerAPI.CustomeRequirements;
using ServiceLayerAPI.Customize;

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
            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>()
                                                         .AddDefaultTokenProviders()
                                                         .AddTokenProvider<CustomeTokenProvider<AppUser>>("CustomeTokenProviders");
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 5;
                options.SignIn.RequireConfirmedEmail = true;

                options.Tokens.EmailConfirmationTokenProvider = "CustomeTokenProviders";
            });//same can be done in services.AddIdentity<IdentityUser, IdentityRole>()
            services.Configure<DataProtectionTokenProviderOptions>(options =>
            {
                options.TokenLifespan = TimeSpan.FromHours(1);//set lifespan of all token to 1 hour.
            });
            services.Configure<CustomeTokenProviderOtions>(options=>
            {
                options.TokenLifespan = TimeSpan.FromDays(2);
            });
            services.AddMvc(options=>
            {
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();
                options.Filters.Add(new AuthorizeFilter(policy));//always use allowanonymous at login
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddAuthentication();
                    
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<ITeacherRepository, TeacherRepository>();
            services.AddTransient<ICommonRepository, CommonRepository>();
            services.AddTransient<IAdminRepository, AdminRepository>();
            services.AddCors();
            services.AddAuthorization(options=>
            {
                //owner will have below 2  policies to create roles
                options.AddPolicy("CreateDeleteAnyRolePolicy",
                    policy => policy.RequireClaim("Create Role")
                                    .RequireClaim("Delete Role") 
                                    .RequireRole("Owner"));
                options.AddPolicy("OwnerRolePolicy",
                    policy => policy.RequireClaim(ClaimTypes.Role, "Owner"));

                options.AddPolicy("CustomePolicy",
                    policy => policy.AddRequirements(new OnlyMeRequirement()));

                options.AddPolicy("CreateTutionPolicy",
                    policy => policy.RequireAssertion(context =>
                              (context.User.IsInRole("Admin") || context.User.IsInRole("Student"))
                               && context.User.HasClaim(claim => claim.Type == "Create Tution" && 
                                                             claim.Value == "true")
                               || context.User.IsInRole("Owner")));

                options.AddPolicy("DeleteTutionPolicy",
                    policy => policy.RequireAssertion(context =>
                              (context.User.IsInRole("Admin") || context.User.IsInRole("Student"))
                               && context.User.HasClaim(claim => claim.Type == "Delete Tution" &&
                                                             claim.Value == "true")
                               || context.User.IsInRole("Owner")));


                options.AddPolicy("EditTutionPolicy",
                    policy => policy.RequireAssertion(context =>
                              (context.User.IsInRole("Admin") || context.User.IsInRole("Student"))
                               && context.User.HasClaim(claim => claim.Type == "Edit Tution" &&
                                                             claim.Value == "true")
                               || context.User.IsInRole("Owner")));

                options.AddPolicy("ApplyTutionPolicy",
                    policy => policy.RequireClaim("Apply Tution", "true")
                                    .RequireRole("Teacher"));

                //below not in use
                string[] cities = { "Chapra", "Patna" };
                options.AddPolicy("IsCityCorrectPolicy",
                    policy => policy.RequireClaim("Available City",cities));
                                    
            });
            services.AddSingleton<IAuthorizationHandler, OnlyMeRequirementHandler>();
            services.AddSingleton<IAuthorizationHandler, IsOwnerOrAdmin>();
            services.AddSingleton<DataProtectionPurposeStrings>();
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
            app.UseCors(options =>
            {
                options.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader();
            });
            app.UseAuthentication();//adding authentication before mvc middleware.
            app.UseMvcWithDefaultRoute();//will open index in home controller at local url if no attribute at controller and method used
            
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello,no middleware to handle request, this if from default middleware");
            });
        }
    }
}

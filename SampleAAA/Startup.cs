using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SampleAAA.Models;

namespace SampleAAA
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            string Connection = configuration.GetConnectionString("MyCon");
            services.AddDbContext<PersonDbContext>(c => c.UseSqlServer(Connection));
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddIdentity<MyUser, IdentityRole>(option=> {
                option.Password.RequiredLength = 4;
                option.Password.RequireUppercase = false;
                option.Password.RequireLowercase = false;
                option.Password.RequireNonAlphanumeric = false;
                option.User.RequireUniqueEmail = true;

            })                
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<PersonDbContext>();
            services.ConfigureApplicationCookie(c => c.LoginPath = "/Admin/Login");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStatusCodePages();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(option=> {
                option.MapRoute(name: "Default", template: "{controller=default}/{action=index}/{id?}");
            });
            
        }
    }
}

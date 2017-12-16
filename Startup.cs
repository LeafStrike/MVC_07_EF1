using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MVC_EF1.Services;
using Microsoft.EntityFrameworkCore;

namespace MVC_EF1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /*private const string ConnectionString =
            "Server=(localdb)\\mssqllocaldb;" +
            "Database=StudentsDb;" +
            "Trusted_Connection=True;" +
            "MultipleActiveResultSets=True;";*/
        private readonly string ConnectionString =
        @"Data Source=neonrebel\sqlexpress;
            Initial Catalog=MVC_Students;
            Integrated Security=True;
            Connect Timeout=60;
            Encrypt=False;
            TrustServerCertificate=True;
            ApplicationIntent=ReadWrite;
            MultiSubnetFailover=False";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<StudentsDBContext>(x => x.UseSqlServer(ConnectionString));
            services.AddMvc();
            services.AddTransient<StudentService,StudentService>();
            services.AddSingleton<StudentsSource>();
        }

        private StudentService StudentServiceFactory(IServiceProvider serviceProvider)
        {
            return new StudentService(serviceProvider.GetService<StudentsDBContext>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Student}/{action=List}/{id?}");
            });
        }
    }
}

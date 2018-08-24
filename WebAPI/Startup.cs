using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using DAL.UnitOfWork;
using DAL.AutoMapper;
using BLL.Interfaces;
using BLL.Services;

namespace WebAPI
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
            services.AddCors(options =>
            {
                options.AddPolicy("default", policy =>
                {
                    policy.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });

            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")
                    //c => c.MigrationsAssembly("DAL")
                );
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton(s => AutoMapperConfig.Instance);

            services.AddScoped<IEmployeeService, EmployeeService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                if (Configuration["InitializeDatabase"] == "true")
                {
                    using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
                    {
                        var _applicationContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationContext>();
                        DbInitializer.InitializeDatabase(_applicationContext);
                    }
                }
            }

            app.UseMvc();
            app.UseCors("default");
        }
    }
}

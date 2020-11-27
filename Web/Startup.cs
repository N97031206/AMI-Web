using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Model.AMI.Repository.Provider;
using Model.AMI.Service.Interface;
using Model.AMI.Service.Provider;
using Models.Repository;

namespace Web
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
            #region DI Repository & Service
            services.AddTransient<AccountRepository>();
            services.AddTransient<IAccountService, AccountService>();

            services.AddTransient<RoleRepository>();
            services.AddTransient<IRoleService, RoleService>();

            #endregion

            services.AddScoped<AMIDbContext>();

            var connection = new SqliteConnection("datasource=:memory:");
            connection.Open();
            connection.EnableExtensions(true);

            services.AddDbContext<AMIDbContext>(options =>
            {
                options.UseSqlite(connection);
            });

            services.AddRazorPages();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}

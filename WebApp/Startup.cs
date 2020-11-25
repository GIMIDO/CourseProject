using WebApp.MiddleWares;
using WebApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // ���������� �������� ����������� ��� ������ � ��������� �������
            services.AddControllersWithViews(options =>
            {
                options.CacheProfiles.Add("Cache",
                    new CacheProfile()
                    {
                        Duration = 266
                    });
                options.CacheProfiles.Add("NoCache",
                    new CacheProfile()
                    {
                        Location = ResponseCacheLocation.None,
                        NoStore = true
                    });
            });
            // ���������� ��������� ������ �� ������� �����������, ���������� � ����� appsettings.json
            services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlServerConnection")));
            services.AddDbContext<IdentityDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlServerConnection")));
            services.AddIdentity<User, IdentityRole>(options => { options.User.RequireUniqueEmail = true; }).AddEntityFrameworkStores<IdentityDbContext>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseDbInitializeMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

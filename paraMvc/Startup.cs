using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using paraMvc.Data;
using paraMvc.Data.Services;
using paraMvc.Models;
using System.Configuration;
using System.Data.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;

using Microsoft.AspNetCore.Hosting;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;

namespace paraMvc
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
           
                services.AddDbContext<AppDbContext>(options=>options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
           
            //service
            services.AddScoped<IFournisseurService , FournisseurService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrdersService, OrdersService>();
            services.AddScoped<IDemandeService, DemandeService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddIdentity<ApplicationUser, Microsoft.AspNetCore.Identity.IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
                    
            services.AddMvc();
            services.AddMemoryCache();
            services.AddCors();
            services.AddControllers();

        
            services.AddSession();
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            });
            services.AddControllersWithViews();

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();


            //Authentication & Authorization
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                 
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
          
            //Seed database
            AppDbInitializer.Seed(app);
          //  AppDbInitializer.SeedUsersAndRolesAsync(app).Wait();

        }
         
    
    
    }
}




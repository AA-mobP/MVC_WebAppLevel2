using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Mvc_WebApp_Level2.Models;
using Mvc_WebApp_Level2.Models.BusinessLogic;
using Mvc_WebApp_Level2.Models.Interfaces_Layer;

namespace Mvc_WebApp_Level2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddSession();
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer("Server=DESKTOP-ECE5S76\\SQL2022;Database=MVC_Level2;Integrated Security=True;Encrypt=False;Trust Server Certificate=True"));
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;

                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<AppDbContext>();

            builder.Services.AddScoped<IclsDepartment, clsDepartment>();
            builder.Services.AddScoped<IclsInstructor, clsInstructor>();
            builder.Services.AddScoped<IclsCourse, clsCourse>();
            builder.Services.AddScoped<IclsTrainee, clsTrainee>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

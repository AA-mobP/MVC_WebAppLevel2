using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing;
namespace Mvc_WebApp_Level2.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Department> departments { get; set; }
        public DbSet<Instructor> instructors { get; set; }
        public DbSet<Trainee> trainees { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<CourseResult> coursesResult { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-35EK0UQ\\SQL2022;Database=MVC_Level2;User ID=sa;Password=y8882gy98;Trust Server Certificate=True");
        }
    }
}

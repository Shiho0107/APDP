using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using SystemTask = System.Threading.Tasks.Task;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using Azure.Identity;
using System.ComponentModel.DataAnnotations;
using Task = System.Threading.Tasks.Task;
namespace WebApplication1.Data
{
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> options)
            : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    Password = "admin",
                    Email = "admin@fpt.edu.vn"
                });

        }


    }
}

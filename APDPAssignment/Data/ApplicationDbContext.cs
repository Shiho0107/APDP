using APDPAssignment.Models;
using Microsoft.EntityFrameworkCore;

namespace APDPAssignment.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Account> Account { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<EnrollmentList> EnrollmentList { get; set; }
        public DbSet<Lecturer> Lecturer { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Student> Student { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasOne(a => a.Student)
                .WithOne(s => s.Account)
                .HasForeignKey<Student>(s => s.StudentId);

            modelBuilder.Entity<Account>()
                .HasOne(a => a.Admin)
                .WithOne(ad => ad.Account)
                .HasForeignKey<Admin>(ad => ad.AdminId);

            modelBuilder.Entity<Account>()
                .HasOne(a => a.Role)
                .WithMany(r => r.Accounts)
                .HasForeignKey(a => a.RoleId);

            modelBuilder.Entity<Account>()
                .HasOne(a => a.Lecturer)
                .WithOne(l => l.Account)
                .HasForeignKey<Lecturer>(l => l.LecturerId);

            modelBuilder.Entity<Roles>()
                .HasMany(r => r.Accounts)
                .WithOne(a => a.Role)
                .HasForeignKey(a => a.RoleId);


            // Roles Id and Names
            modelBuilder.Entity<Roles>().HasData(
                new Roles { RoleId = 1, RoleName = "Admin" },
                new Roles { RoleId = 2, RoleName = "Lecturer" },
                new Roles { RoleId = 3, RoleName = "Student" }
            );
        }
    }
}
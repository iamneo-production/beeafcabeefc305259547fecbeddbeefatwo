using KathakBookingSystem.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace KathakBookingSystem.Data
{
        public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships, constraints, and validations
            modelBuilder.Entity<Class>()
                .HasMany(r => r.Students)
                .WithOne(c => c.Class)
                .HasForeignKey(c => c.ClassID);
        }
    }

}

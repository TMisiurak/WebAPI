using Microsoft.EntityFrameworkCore;
using ProjectCore.Models;

namespace DAL.EF
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasOne(e => e.Gender)
                      .WithMany(g => g.Employees)
                      .HasForeignKey(e => e.GenderId);
                
                entity.HasOne(e => e.Position)
                      .WithMany(p => p.Employees)
                      .HasForeignKey(e => e.PositionId);
            });
        }
    }
}

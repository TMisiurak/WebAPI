using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjectCore.Models;

namespace DAL.EF
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Position> Positions { get; set; }

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

                entity.Property(e => e.IsDeleted)
                      .HasDefaultValue(false);

                entity.Property(c => c.CreatedAt)
                      .HasDefaultValueSql("SYSDATETIME()");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(c => c.CreatedAt)
                      .HasDefaultValueSql("SYSDATETIME()");
            });

            foreach (var rel in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                rel.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}

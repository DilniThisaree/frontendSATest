using Microsoft.EntityFrameworkCore;
using RecruitmentPlatform.API.Models;

namespace RecruitmentPlatform.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);

                entity.HasIndex(u => u.Email)
                      .IsUnique();

                entity.Property(u => u.FullName)
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(u => u.Email)
                      .HasMaxLength(255)
                      .IsRequired();

                entity.Property(u => u.PasswordHash)
                      .HasMaxLength(255)
                      .IsRequired();

                entity.Property(u => u.Role)
                      .HasMaxLength(30)
                      .IsRequired();

                entity.Property(u => u.IsActive)
                      .HasDefaultValue(true);

                entity.Property(u => u.CreatedAt)
                      .IsRequired();
            });
        }
    }
}
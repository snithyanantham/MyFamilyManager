using Microsoft.EntityFrameworkCore;
using MyFamilyManager.API.Core.Models;

namespace MyFamilyManager.API.Repositories
{
    public class MyFamilyManagerDbContext : DbContext
    {
        public DbSet<Family> Families { get; set; }
        public MyFamilyManagerDbContext(DbContextOptions<MyFamilyManagerDbContext> options):base(options)
        {
            this.Database.EnsureCreated();
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Family>(e => {
                e.ToTable("Families").HasKey(k => k.Id);
                e.Property(p => p.Id).ValueGeneratedOnAdd();
                e.HasIndex(i => i.Name).IsUnique();
            });
            base.OnModelCreating(builder);
        }

    }
}

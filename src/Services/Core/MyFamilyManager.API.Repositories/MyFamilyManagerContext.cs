using Microsoft.EntityFrameworkCore;
using MyFamilyManager.API.Core.Models;

namespace MyFamilyManager.API.Repositories
{
    public class MyFamilyManagerDbContext : DbContext
    {
        public DbSet<Family> Families { get; set; }
        public DbSet<FamilyMember> FamilyMembers { get; set; }
        public DbSet<FamilyMemberType> FamilyMemberTypes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public MyFamilyManagerDbContext(DbContextOptions<MyFamilyManagerDbContext> options) : base(options)
        {
            // this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Family>(e =>
            {
                e.ToTable("Families").HasKey(k => k.Id);
                e.Property(p => p.Id).ValueGeneratedOnAdd();
                e.HasIndex(i => i.Name).IsUnique();
                e.Property(p => p.CreatedAt).ValueGeneratedOnAdd();
            });
            builder.Entity<FamilyMember>(e =>
            {
                e.ToTable("FamilyMembers").HasKey(k => k.Id);
                e.Property(p => p.Id).ValueGeneratedOnAdd();
                e.Property(p => p.CreatedAt).ValueGeneratedOnAdd();
                
            });
            builder.Entity<FamilyMemberType>(e =>
            {
                e.ToTable("FamilyMemberTypes").HasKey(k => k.Id);
                e.Property(p => p.Id).ValueGeneratedOnAdd();
                e.Property(p => p.CreatedAt).ValueGeneratedOnAdd();
            });
            builder.Entity<Category>(e =>
            {
                e.ToTable("Categories").HasKey(k => k.Id);
                e.Property(p => p.Id).ValueGeneratedOnAdd();
                e.Property(p => p.CreatedAt).ValueGeneratedOnAdd();
            });
            builder.Entity<SubCategory>(e =>
            {
                e.ToTable("SubCategories").HasKey(k => k.Id);
                e.Property(p => p.Id).ValueGeneratedOnAdd();
                e.Property(p => p.CreatedAt).ValueGeneratedOnAdd();
            });
            builder.Entity<Transaction>(e =>
            {
                e.ToTable("Transations").HasKey(k => k.Id);
                e.Property(p => p.Id).ValueGeneratedOnAdd();
                e.Property(p => p.CreatedAt).ValueGeneratedOnAdd();
            });
            base.OnModelCreating(builder);
        }

    }
}

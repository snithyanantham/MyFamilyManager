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
                e.ToTable("Families").HasKey(k => k.FamilyId);
                e.Property(p => p.FamilyId).ValueGeneratedOnAdd();
                e.HasIndex(i => i.Name).IsUnique();
            });
            builder.Entity<FamilyMember>(e =>
            {
                e.ToTable("FamilyMembers").HasKey(k => k.FamilyMemberId);
                e.Property(p => p.FamilyMemberId).ValueGeneratedOnAdd();
            });
            builder.Entity<FamilyMemberType>(e =>
            {
                e.ToTable("FamilyMemberTypes").HasKey(k => k.FamilyMemberTypeId);
                e.Property(p => p.FamilyMemberTypeId).ValueGeneratedOnAdd();
            });
            builder.Entity<Category>(e =>
            {
                e.ToTable("Categories").HasKey(k => k.CategoryId);
                e.Property(p => p.CategoryId).ValueGeneratedOnAdd();
            });
            builder.Entity<SubCategory>(e =>
            {
                e.ToTable("SubCategories").HasKey(k => k.SubCategoryId);
                e.Property(p => p.SubCategoryId).ValueGeneratedOnAdd();
            });
            builder.Entity<Transaction>(e =>
            {
                e.ToTable("Transations").HasKey(k => k.TransationId);
                e.Property(p => p.TransationId).ValueGeneratedOnAdd();
                e.Property(p => p.CreatedOn).ValueGeneratedOnAdd();
            });
            base.OnModelCreating(builder);
        }

    }
}

using Microsoft.EntityFrameworkCore;
using MyFamilyManager.API.Core.Models;
using System;

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
                e.HasData(
                     new Category { Id = new Guid("baf5cfac-b37e-11ea-b3de-0242ac130004"), Name = "Income", Description = "Income" },
                     new Category { Id = new Guid("baf5dfac-b37e-11ea-b3de-0242ac130004"), Name = "Expenses", Description = "Expenses" }
                    );
            });
            builder.Entity<SubCategory>(e =>
            {
                e.ToTable("SubCategories").HasKey(k => k.Id);
                e.Property(p => p.Id).ValueGeneratedOnAdd();
                e.Property(p => p.CreatedAt).ValueGeneratedOnAdd();
                e.HasData(
                     new SubCategory { Id = new Guid("baf5d1e6-b37e-11ea-b3de-0242ac130004"), CategoryId = new Guid("baf5cfac-b37e-11ea-b3de-0242ac130004"), Name = "Salary", Description = "Salary" },
                     new SubCategory { Id = new Guid("baf5d2e6-b37e-11ea-b3de-0242ac130004"), CategoryId = new Guid("baf5dfac-b37e-11ea-b3de-0242ac130004"), Name = "Rent", Description = "Rent" },
                     new SubCategory { Id = new Guid("baf5d3e6-b37e-11ea-b3de-0242ac130004"), CategoryId = new Guid("baf5dfac-b37e-11ea-b3de-0242ac130004"), Name = "Others", Description = "Others" }
                    );
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

using Microsoft.EntityFrameworkCore;
using MyFamilyManager.API.Core.Model;

namespace MyFamilyManager.API.Repositories
{
    public class MyFamilyManagerContext : DbContext
    {
        public DbSet<Family> Families { get; set; }

    }
}

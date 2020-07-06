using MyFamilyManager.API.Core.Interfaces;
using MyFamilyManager.API.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyFamilyManager.API.Repositories
{
    public class SubCategoryRepository : BaseRepository<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(MyFamilyManagerDbContext context) : base(context)
        {
        }

        public List<SubCategory> GetAllByCategoryId(Guid categoryId)
        {
            return base.entities.Where(x => x.CategoryId == categoryId).ToList();
        }
    }
}

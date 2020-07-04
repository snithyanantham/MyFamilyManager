using MyFamilyManager.API.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFamilyManager.API.Core.Interfaces
{
    public interface ISubCategoryRepository : IBaseRepository<SubCategory>
    {
        List<SubCategory> GetAllByCategoryId(Guid categoryId);
    }
}

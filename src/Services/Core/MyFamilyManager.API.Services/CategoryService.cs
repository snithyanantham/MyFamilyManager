using MyFamilyManager.API.Core.Dtos;
using MyFamilyManager.API.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFamilyManager.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public CategoryListDto GetAllCategories()
        {
            var categories = _unitOfWork.CategoryRepository.GetAll();
            CategoryListDto categoryList = new CategoryListDto
            {
                categories = new List<CategoryDto>()
            };

            if (categories != null)
            {
                foreach (var item in categories)
                {
                    categoryList.categories.Add(new CategoryDto
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description
                    });
                }
            }

            return categoryList;
        }
    }
}

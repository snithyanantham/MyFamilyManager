using MyFamilyManager.API.Core.Dtos;
using MyFamilyManager.API.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFamilyManager.API.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SubCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public SubCategoryListDto GetAllSubCategories()
        {
            var subCategories = _unitOfWork.SubCategoryRepository.GetAll();
            SubCategoryListDto subCategoryList = new SubCategoryListDto
            {
                SubCaetgories = new List<SubCategoryDto>()
            };

            if (subCategories != null)
            {
                foreach (var item in subCategories)
                {
                    subCategoryList.SubCaetgories.Add(new SubCategoryDto
                    {
                        Id = item.Id,
                        CategoryId = item.CategoryId,
                        Name = item.Name,
                        Description = item.Description
                    });
                }
            }

            return subCategoryList;
        }
    }
}

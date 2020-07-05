using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MyFamilyManager.API.Core.Dtos;
using MyFamilyManager.API.Core.Interfaces;

namespace MyFamilyManager.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;
        public CategoryController(ICategoryService categoryService, ISubCategoryService subCategoryService)
        {
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
        }

        [HttpGet]
        public ActionResult<CategoryListDto> Get()
        {
            return _categoryService.GetAllCategories();
        }

        [HttpGet]
        [Route("{categoryId}/subcategories")]
        public ActionResult<SubCategoryListDto> Get(Guid categoryId)
        {
            return _subCategoryService.GetAllSubCategoriesByCategoryId(categoryId);
        }
    }
}

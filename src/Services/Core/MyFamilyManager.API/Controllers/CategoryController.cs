using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFamilyManager.API.Core.Dtos;
using MyFamilyManager.API.Core.Interfaces;

namespace MyFamilyManager.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult<CategoryListDto> Get()
        {
            return _categoryService.GetAllCategories();
        }
    }
}

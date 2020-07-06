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
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategoryService _subCategoryService;

        public SubCategoryController(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }

        [HttpGet]
        public ActionResult<SubCategoryListDto> Get()
        {
            return _subCategoryService.GetAllSubCategories();
        }
    }
}

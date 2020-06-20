using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFamilyManager.API.Core.Dtos;
using MyFamilyManager.API.Core.Interfaces;
using MyFamilyManager.API.Core.Models;

namespace MyFamilyManager.API.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class FamilyController : ControllerBase
    {
        private readonly IFamilyService _familyService;
        public FamilyController(IFamilyService familyService)
        {
            _familyService = familyService;
        }

        [HttpGet]
        public Family Get(Guid Id)
        {
            return _familyService.GetFamily(Id);
        }

        [HttpPost]
        public void Post(FamilyDto family)
        {
            _familyService.SaveFamily(family);
        }
    }
}
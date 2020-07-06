using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<FamilyDto> Get(Guid Id)
        {
            var family = _familyService.GetFamily(Id);
            if (family != null)
            {
                return family;
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post(FamilyDto family)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                _familyService.SaveFamily(family);
                return StatusCode(201);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
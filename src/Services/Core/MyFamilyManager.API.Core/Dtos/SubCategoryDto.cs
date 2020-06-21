using System;
using System.Collections.Generic;
using System.Text;

namespace MyFamilyManager.API.Core.Dtos
{
    public class SubCategoryDto :IdNameDescriptionDto
    {
        public Guid CategoryId { get; set; }
    }
}

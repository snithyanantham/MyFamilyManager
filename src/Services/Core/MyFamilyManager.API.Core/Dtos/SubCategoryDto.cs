using System;
using System.Collections.Generic;
using System.Text;

namespace MyFamilyManager.API.Core.Dtos
{
    public class SubCategoryDto :CategoryDto
    {
        public Guid CategoryId { get; set; }
    }
}

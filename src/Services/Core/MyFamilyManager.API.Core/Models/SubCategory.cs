using System;
using System.Collections.Generic;
using System.Text;

namespace MyFamilyManager.API.Core.Models
{
    public class SubCategory : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}

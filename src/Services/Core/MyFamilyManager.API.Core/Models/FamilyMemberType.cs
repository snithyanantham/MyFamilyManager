using System;
using System.Collections.Generic;
using System.Text;

namespace MyFamilyManager.API.Core.Models
{
    public class FamilyMemberType : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

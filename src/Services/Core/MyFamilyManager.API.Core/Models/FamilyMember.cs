using System;
using System.Collections.Generic;
using System.Text;

namespace MyFamilyManager.API.Core.Models
{
    public class FamilyMember : BaseEntity
    {
        public string UserId { get; set; }
        public Guid FamilyId { get; set; }
        public Guid FamilyMemberTypeId { get; set; }

        public virtual FamilyMemberType FamilyMemberType { get; set; }
        public virtual Family Family { get; set; }
    }
}

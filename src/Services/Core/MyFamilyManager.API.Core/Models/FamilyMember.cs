using System;
using System.Collections.Generic;
using System.Text;

namespace MyFamilyManager.API.Core.Models
{
    public class FamilyMember
    {
        public int FamilyMemberId { get; set; }
        public string UserId { get; set; }
        public int FamilyId { get; set; }
        public int FamilyMemberTypeId { get; set; }
    }
}

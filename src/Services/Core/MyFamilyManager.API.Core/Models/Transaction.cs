using System;

namespace MyFamilyManager.API.Core.Models
{
    public class Transaction : BaseEntity
    {
        public Guid CategoryId { get; set; }
        public Guid SubCategoryId { get; set; }
        public Guid FamilyId { get; set; }
        public string UserId { get; set; }
        public double Amount { get; set; }

        public virtual Category Category { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public virtual Family Family { get; set; }
    }
}

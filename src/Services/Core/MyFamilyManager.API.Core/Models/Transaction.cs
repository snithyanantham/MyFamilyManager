using System;

namespace MyFamilyManager.API.Core.Models
{
    public class Transaction
    {
        public int TransationId { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int FamilyId { get; set; }
        public string UserId { get; set; }
        public double Amount { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}

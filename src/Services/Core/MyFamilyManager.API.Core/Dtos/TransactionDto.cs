using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyFamilyManager.API.Core.Dtos
{
    public class TransactionDto
    {
        [Required]
        public Guid CategoryId { get; set; }
        [Required]
        public Guid SubCategoryId { get; set; }
        [Required]
        public Guid FamilyId { get; set; }
        [Required]
        public double Amount { get; set; }
    }
}

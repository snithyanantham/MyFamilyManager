using System;
using System.Collections.Generic;
using System.Text;

namespace MyFamilyManager.API.Core.Dtos
{
    public class TransactionResponseDto : TransactionDto
    {
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}

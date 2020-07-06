using System;
using System.Collections.Generic;
using System.Text;

namespace MyFamilyManager.Mobile.Models
{
    public class Transaction
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public double Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}

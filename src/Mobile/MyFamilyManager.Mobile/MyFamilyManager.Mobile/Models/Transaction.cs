using System;
using System.Collections.Generic;
using System.Text;

namespace MyFamilyManager.Mobile.Models
{
    public class Transaction
    {
        public string CategoryId { get; set; }
        public string SubCategoryId { get; set; }
        public double Amount { get; set; }
    }
}

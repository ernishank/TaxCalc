using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.TaxCalculator.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EnumItemType ItemType { get; set; }
        public double Amount { get; set; }
        public bool IsImported { get; set; }
    }
}

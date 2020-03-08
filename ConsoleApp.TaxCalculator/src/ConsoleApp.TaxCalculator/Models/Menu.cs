using ConsoleApp.TaxCalculator.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.TaxCalculator.Models
{
    public class Menu
    {
        static List<Product> _products;
        private TaxCalculation taxCalculation = new TaxCalculation();
        public static int DisplayMenu()
        {
            Console.WriteLine("Welcome to tax calculator!!\nPlease select your items: \n");
            Console.WriteLine("1. Add new item");
            Console.WriteLine("2. List added items");
            Console.WriteLine("3. Exit");

            var choosedOption = Console.ReadLine();
            if (Convert.ToInt32(choosedOption) > 3)
            {
                Console.Clear();
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!Please select correct option!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine("====================================");
                return 0;
            }
            return Convert.ToInt32(choosedOption);
        }

        public static void AddNewItem()
        {
            _products = new List<Product>();
            string addMoreItem = "n";
            int prodId = 0;
            do
            {
                Product product = new Product();
                product.Id = prodId + 1;
                Console.WriteLine("Please select item type: ");

                Console.WriteLine("1. Food \t 2. Medicine\t 3. Others");

                int itemType = Convert.ToInt32(Console.ReadLine());
                GetItemTypeMethod(product, itemType);

                Console.Write("Is this imported item(Y/N)? ");

                product.IsImported = Convert.ToBoolean(Console.ReadLine().ToLower() == "y" ? true : false);

                Console.Write("Please enter item name: ");
                product.Name = Console.ReadLine();

                Console.Write("Please enter item amount: ");
                product.Amount = Convert.ToDouble(Console.ReadLine());

                _products.Add(product);

                Console.WriteLine("Do you want to add more item (Y/N)? ");
                addMoreItem = Console.ReadLine().ToLower();

            } while (addMoreItem != "n");
        }

        private static void GetItemTypeMethod(Product product, int itemType)
        {
            if (itemType == 1)
                product.ItemType = EnumItemType.Food;
            else if (itemType == 2)
                product.ItemType = EnumItemType.Medicine;
            else
                product.ItemType = EnumItemType.Others;
        }

        public void DisplayBill()
        {
            (double taxAmount, double amount) = CalculateValue();

            Console.WriteLine("ProductId \t ProductName \t Amount");
            foreach (var product in _products)
            {
                Console.WriteLine(product.Id + " \t " + product.Name + " \t " + product.Amount);
            }
            Console.WriteLine("Total tax amount is: "+ taxAmount);
            Console.WriteLine("Total amount is: " + amount);
            Console.WriteLine("Thanks for shopping with us. Please visit again!!");
        }

        public (double, double) CalculateValue()
        {
            double taxAmount = 0;
            double amount = 0;

            foreach (var product in _products)
            {
                amount += product.Amount;

                if (product.IsImported && product.ItemType == EnumItemType.Others)
                {
                    taxAmount += taxCalculation.ImportDutyAndTaxCalculation(product);
                }
                else if (product.IsImported && product.ItemType != EnumItemType.Others)
                {
                    taxAmount += taxCalculation.ImportDutyCalculationOnExemptedItems(product);
                }
                else if (!product.IsImported && product.ItemType == EnumItemType.Others)
                {
                    taxAmount += taxCalculation.TaxCalculationOnNonImportedItems(product);
                }
                else
                    taxAmount += taxCalculation.NoCalculationOnExemptedItems(product);
            }

            return (taxAmount, amount);
        }
    }
}

using ConsoleApp.TaxCalculator.Interface;
using ConsoleApp.TaxCalculator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.TaxCalculator.Services
{
    public class TaxCalculation : ITaxCalculation
    {
        double tax;
        double taxRate = 7;
        double importDuty = 10;
        public double ImportDutyAndTaxCalculation(Product product)
        {
            var output = (taxRate * importDuty * product.Amount) / 100;
            return (tax += output);
        }

        public double ImportDutyCalculationOnExemptedItems(Product product)
        {
            var output = (importDuty * product.Amount) / 100;
            return (tax += output);
        }

        public double TaxCalculationOnNonImportedItems(Product product)
        {
            var output = (taxRate * product.Amount) / 100;
            return (tax += output);
        }

        public double NoCalculationOnExemptedItems(Product product)
        {
            return 0;
        }
    }
}

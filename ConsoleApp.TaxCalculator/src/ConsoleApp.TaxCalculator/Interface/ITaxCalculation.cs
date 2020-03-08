using ConsoleApp.TaxCalculator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.TaxCalculator.Interface
{
    public interface ITaxCalculation
    {
        double ImportDutyCalculationOnExemptedItems(Product product);
        double ImportDutyAndTaxCalculation(Product product);
        double NoCalculationOnExemptedItems(Product product);
        double TaxCalculationOnNonImportedItems(Product product);
    }
}

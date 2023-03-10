using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.PricingAndAccounting.Model
{
    public class CreateAccountingModel
    {
        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = true;

        [JsonPropertyName("unitSales")]
        public double UnitSales { get; set; }

        [JsonPropertyName("totalSales")]
        public double TotalSales { get; set; }
    }
}


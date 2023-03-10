using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.PricingAndAccounting.Model;

public class UpdateAccountingModel
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("unitSales")]
    public double UnitSales { get; set; }

    [JsonPropertyName("totalSales")]
    public double TotalSales { get; set; }
}


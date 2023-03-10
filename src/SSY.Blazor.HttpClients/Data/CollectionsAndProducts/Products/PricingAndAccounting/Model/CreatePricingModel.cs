using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.PricingAndAccounting.Model;

public class CreatePricingModel
{

    [JsonPropertyName("isActive")]
    public bool IsActive { get; set; } = true;

    [JsonPropertyName("retailPrice")]
    public double RetailPrice { get; set; }

    [JsonPropertyName("shippingPremium")]
    public double ShippingPremium { get; set; }

    [JsonPropertyName("netPrice")]
    public double NetPrice { get; set; }
}


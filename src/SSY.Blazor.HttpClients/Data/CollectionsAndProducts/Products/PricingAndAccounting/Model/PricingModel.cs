using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.PricingAndAccounting.Model;

public class PricingModel
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("retailPrice")]
    public double RetailPrice { get; set; }

    [JsonPropertyName("shippingPremium")]
    public double ShippingPremium { get; set; }

    [JsonPropertyName("netPrice")]
    public double NetPrice { get; set; }
}
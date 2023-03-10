using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.Statuses.Model;

public class ProductStatusListModel
{
    [JsonPropertyName("productStatuses")]
    public List<ProductStatusModel> ProductStatuses { get; set; } = new();
}


using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.Statuses.Model;

public class GetProductStatusOutputModel
{
    [JsonPropertyName("result")]
    public ProductStatusModel Result { get; set; } = new();
}


using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.DesignStatuses.Model;

public class CollectionDesignStatusModel
{
    [JsonPropertyName("isActive")]
    public bool IsActive { get; set; }
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("label")]
    public string Label { get; set; }
    [JsonPropertyName("value")]
    public string Value { get; set; }
    [JsonPropertyName("orderNumber")]
    public int OrderNumber { get; set; }
}
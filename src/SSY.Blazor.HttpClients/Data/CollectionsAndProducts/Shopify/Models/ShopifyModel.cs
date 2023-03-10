using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Shopify.Models;

public class ShopifyModel
{
    [JsonPropertyName("isActive")]
    public bool IsActive { get; set; } = true;

    [JsonPropertyName("published")]
    public bool Published { get; set; }

    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    [JsonPropertyName("productId")]
    public Guid ProductId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("number")]
    public string Number { get; set; }

    [JsonPropertyName("shopifyId")]
    public long? ShopifyId { get; set; }

    [JsonPropertyName("publishedAt")]
    public DateTime? PublishedAt { get; set; }

    [JsonPropertyName("price")]
    public double Price { get; set; }

    [JsonPropertyName("fabricComposition")]
    public string FabricComposition { get; set; }

    [JsonPropertyName("tags")]
    public string Tags { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    // CareInstruction ginaya ko sa materialmodel kapag hindi ganto setup tangal yung tatlo sa baba
    [JsonPropertyName("careInstruction")]
    public string CareInstruction { get; set; }

    // Images
    [JsonPropertyName("mediaFiles")]
    public List<ShopifyMediaFileModel> MediaFiles { get; set; }


    public List<string> ListTags { get; set; }

    public ShopifyModel()
    {
        MediaFiles = new();
        ListTags = new();
    }

}

using System.Text.Json.Serialization;
using SSY.Blazor.HttpClients.Models.Products.MediaFiles;


namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Shopify.Models;

public class ShopifyOutputModel
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("productId")]
    public Guid ProductId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("number")]
    public string Number { get; set; }

    [JsonPropertyName("price")]
    public double Price { get; set; }

    [JsonPropertyName("fabricComposition")]
    public string FabricComposition { get; set; }

    [JsonPropertyName("tags")]
    public string Tags { get; set; }

    public List<string> ListTags { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }


    // CareInstruction ginaya ko sa materialmodel kapag hindi ganto setup tangal yung tatlo sa baba
    [JsonPropertyName("careInstruction")]
    public string CareInstruction { get; set; }

    // Images

    [JsonPropertyName("mediaFiles")]
    public List<MediaFileModel> MediaFiles { get; set; }

    public ShopifyOutputModel()
    {
        MediaFiles = new();
    }

}
using System;
using System.Text.Json.Serialization;
using SSY.Blazor.HttpClients.Models.Products.MediaFiles;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Shopify.Models
{
    public class ShopifyMediaFileModel
    {
        [JsonPropertyName("orderNumber")]
        public int OrderNumber { get; set; }

        [JsonPropertyName("mediaFileId")]
        public Guid MediaFileId { get; set; }

        [JsonPropertyName("mediaFile")]
        public MediaFileModel MediaFile { get; set; }

        public ShopifyMediaFileModel()
        {
            MediaFile = new();
        }
    }
}
using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Shopify.Models
{
    public class CreateShopifyMediaFileModel
    {
        [JsonPropertyName("orderNumber")]
        public int OrderNumber { get; set; }
        [JsonPropertyName("mediaFileId")]
        public Guid MediaFileId { get; set; }
    }
}
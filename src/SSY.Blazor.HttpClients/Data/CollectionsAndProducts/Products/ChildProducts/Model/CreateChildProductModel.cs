using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.ChildProducts.Model
{
    public class CreateChildProductModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("childSku")]
        public string ChildSku { get; set; }

        [JsonPropertyName("colorId")]
        public int ColorId { get; set; }

        [JsonPropertyName("productTypeId")]
        public int ProductTypeId { get; set; }

        [JsonPropertyName("colorOptionId")]
        public Guid ColorOptionId { get; set; }

        [JsonPropertyName("productId")]
        public Guid ProductId { get; set; }

        [JsonPropertyName("collectionId")]
        public Guid CollectionId { get; set; }
    }
}


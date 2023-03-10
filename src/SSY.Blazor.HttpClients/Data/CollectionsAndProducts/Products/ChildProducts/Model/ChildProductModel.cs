using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.ChildProducts.Model
{
    public class ChildProductModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("productId")]
        public Guid? ProductId { get; set; }

        [JsonPropertyName("productName")]
        public string ProductName { get; set; }

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

        [JsonPropertyName("colorOptionTitle")]
        public string ColorOptionTitle { get; set; }

        [JsonPropertyName("productOptionId")]
        public Guid? ProductOptionId { get; set; }

        [JsonPropertyName("threeDVirtualFittingId")]
        public Guid? ThreeDVirtualFittingId { get; set; }

        [JsonPropertyName("creationTime")]
        public DateTime CreationTime { get; set; }

        [JsonPropertyName("lastModificationTime")]
        public DateTime? LastModificationTime { get; set; }

    }
}


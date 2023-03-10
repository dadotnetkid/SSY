using System;
using System.Text.Json.Serialization;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.ProductSizes.Model;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Dto
{
	public class CollectionSizeDto
	{
		public CollectionSizeDto()
		{
            Size = new();
        }

        [JsonPropertyName("tenantId")]
        public Guid? TenantId { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("collectionId")]
        public Guid CollectionId { get; set; }

        [JsonPropertyName("size")]
        public ProductSizeModel Size { get; set; }
    }
}


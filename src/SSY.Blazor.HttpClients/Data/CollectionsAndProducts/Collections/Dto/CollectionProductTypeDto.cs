using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Dto
{
	public class CollectionProductTypeDto
	{
		public CollectionProductTypeDto()
		{
            ProductType = new();
        }

        [JsonPropertyName("tenantId")]
        public Guid? TenantId { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }


        [JsonPropertyName("collectionId")]
        public Guid CollectionId { get; set; }

        [JsonPropertyName("productType")]
        public Items ProductType { get; set; }

        [JsonPropertyName("materialTypeId")]
        public int MaterialTypeId { get; set; }

        [JsonPropertyName("materialTypeShortCode")]
        public string MaterialTypeShortCode { get; set; }

        [JsonPropertyName("materialTypeValue")]
        public string MaterialTypeValue { get; set; }
    }
}


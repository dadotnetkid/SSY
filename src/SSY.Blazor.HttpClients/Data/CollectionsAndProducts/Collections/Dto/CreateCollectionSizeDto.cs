using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Dto
{ 
    public class CreateCollectionSizeDto
	{
        [JsonPropertyName("tenantId")]
        public Guid? TenantId { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }


        [JsonPropertyName("collectionId")]
        public Guid CollectionId { get; set; }

        [JsonPropertyName("sizeId")]
        public int SizeId { get; set; }
    }
}


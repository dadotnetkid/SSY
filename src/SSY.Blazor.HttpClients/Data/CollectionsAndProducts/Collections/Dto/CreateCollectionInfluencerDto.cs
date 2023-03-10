using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Dto
{
	public class CreateCollectionInfluencerDto
	{
        [JsonPropertyName("tenantId")]
        public Guid? TenantId { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }


        [JsonPropertyName("collectionId")]
        public Guid CollectionId { get; set; }

        [JsonPropertyName("influencerId")]
        public Guid InfluencerId { get; set; }

        [JsonPropertyName("influencerFullName")]
        public string InfluencerFullName { get; set; }

        [JsonPropertyName("influencerName")]
        public string InfluencerName { get; set; }

        [JsonPropertyName("influencerSurname")]
        public string InfluencerSurname { get; set; }
    }
}


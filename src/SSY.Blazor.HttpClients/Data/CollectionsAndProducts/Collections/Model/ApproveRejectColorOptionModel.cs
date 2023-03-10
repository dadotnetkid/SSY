using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Model
{
	public class ApproveRejectColorOptionModel
	{
        [JsonPropertyName("collectionId")]
        public Guid CollectionId { get; set; }

        [JsonPropertyName("colorOptionId")]
        public Guid ColorOptionId { get; set; }

        [JsonPropertyName("approvedBy")]
        public string ApprovedBy { get; set; }

        [JsonPropertyName("isOnSite")]
        public bool IsOnSite { get; set; }
    }
}


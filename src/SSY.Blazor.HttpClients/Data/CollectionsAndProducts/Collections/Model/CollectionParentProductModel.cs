using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Model
{
    public class CollectionParentProductModel
    {
        [JsonPropertyName("CollectionId")]
        public Guid CollectionId { get; set; }

        [JsonPropertyName("ProductIds")]
        public List<Guid> ProductIds { get; set; } = new();
    }
}


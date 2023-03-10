using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.AdditionRequests.Model
{
    public class AssignAdditionRequestModel
    {
        [JsonPropertyName("collectionId")]
        public Guid CollectionId { get; set; }

        [JsonPropertyName("id")]
        public Guid Id { get; set; }
    }
}


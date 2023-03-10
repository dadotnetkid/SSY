using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.AdditionRequests.Model
{
    public class DeleteAdditionRequestModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
    }
}


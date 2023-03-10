using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Types.Model
{
    public class DeleteTypeModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}


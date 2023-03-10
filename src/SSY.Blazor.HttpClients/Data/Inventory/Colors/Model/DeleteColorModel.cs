using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Colors.Model
{
    public class DeleteColorModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}


using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Materials.Model
{
    public class GetMaterialOutputModel
    {
        [JsonPropertyName("result")]
        public MaterialModel Result { get; set; } = new();
    }
}


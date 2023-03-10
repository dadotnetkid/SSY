using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.SubMaterials.Model
{
    public class GraphSubMaterialModel
    {
        [JsonPropertyName("result")]
        public Dictionary<string, double> Result { get; set; }
    }
}


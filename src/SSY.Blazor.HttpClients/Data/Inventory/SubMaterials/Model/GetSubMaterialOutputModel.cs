using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.SubMaterials.Model
{
    public class GetSubMaterialOutputModel
    {
        [JsonPropertyName("result")]
        public SubMaterialModel Result { get; set; } = new();
    }
}

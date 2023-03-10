using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Materials.Model
{
    public class GraphMaterialModel
    {
        [JsonPropertyName("result")]
        public Dictionary<string, double> Result { get; set; }

    }

}

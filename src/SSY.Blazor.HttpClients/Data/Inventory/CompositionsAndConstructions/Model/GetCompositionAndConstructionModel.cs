using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.CompositionsAndConstructions.Model
{
    public class GetCompositionAndConstructionModel
    {
        [JsonPropertyName("result")]
        public CompositionAndConstructionModel Result { get; set; }

    }
}

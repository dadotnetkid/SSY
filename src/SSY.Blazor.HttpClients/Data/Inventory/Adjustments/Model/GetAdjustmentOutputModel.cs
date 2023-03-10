using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Adjustments.Model
{
    public class GetAdjustmentOutputModel
    {
        [JsonPropertyName("result")]
        public AdjustmentModel Result { get; set; } = new();
    }
}


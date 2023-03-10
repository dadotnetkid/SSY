using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Adjustments.Model
{
    public class AdjustmentListModel
    {
        [JsonPropertyName("adjustments")]
        public List<AdjustmentModel> Adjustments { get; set; } = new();
    }
}


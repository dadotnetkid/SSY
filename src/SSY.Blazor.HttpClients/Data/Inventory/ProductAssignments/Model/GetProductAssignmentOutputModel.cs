using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.ProductAssignments.Model
{
    public class GetProductAssignmentOutputModel
    {
        [JsonPropertyName("result")]
        public ProductAssignmentModel Result { get; set; }
    }
}


using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.RollsAndLocations.Model
{
    public class GetRollAndLocationOutputModel
    {
        [JsonPropertyName("result")]
        public RollAndLocationModel Result { get; set; }
    }
}


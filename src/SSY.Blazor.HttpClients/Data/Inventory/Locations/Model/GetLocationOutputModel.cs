using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Locations.Model
{
    public class GetLocationOutputModel
    {
        [JsonPropertyName("result")]
        public LocationModel Result { get; set; }
    }
}


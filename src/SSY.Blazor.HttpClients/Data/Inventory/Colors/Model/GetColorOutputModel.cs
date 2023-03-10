using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Colors.Model
{
    public class GetColorOutputModel
    {
        [JsonPropertyName("result")]
        public ColorModel Result { get; set; }
    }
}


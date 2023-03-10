using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.SwatchList.Model
{
    public class GetSwatchListOutputModel
    {
        [JsonPropertyName("result")]
        public SwatchListModel Result { get; set; }
    }
}


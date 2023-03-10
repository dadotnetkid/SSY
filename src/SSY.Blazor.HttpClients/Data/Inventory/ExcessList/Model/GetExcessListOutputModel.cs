using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.ExcessList.Model
{
    public class GetExcessListOutputModel
    {
        [JsonPropertyName("result")]
        public ExcessListModel Result { get; set; }
    }
}


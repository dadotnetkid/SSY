using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.FinalSelectionList.Model
{
    public class GetFinalSelectionListOutputModel
    {
        [JsonPropertyName("result")]
        public FinalSelectionListModel Result { get; set; }
    }
}


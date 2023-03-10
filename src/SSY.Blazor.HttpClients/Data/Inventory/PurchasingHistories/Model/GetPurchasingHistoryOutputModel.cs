using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.PurchasingHistories.Model
{
    public class GetPurchasingHistoryOutputModel
    {
        [JsonPropertyName("result")]
        public PurchasingHistoryModel Result { get; set; }
    }
}


using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.PurchaseDetails.Model
{
    public class GetPurchaseDetailOutputModel
    {
        [JsonPropertyName("result")]
        public PurchaseDetailModel Result { get; set; }
    }
}


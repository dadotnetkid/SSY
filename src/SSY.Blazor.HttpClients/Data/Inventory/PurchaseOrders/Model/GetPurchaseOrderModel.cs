using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.PurchaseOrders.Model
{
    public class GetPurchaseOrderModel
    {
        [JsonPropertyName("result")]
        public PurchaseOrderModel Result { get; set; }
    }
}


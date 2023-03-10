using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.PurchaseOrders.Model
{
    public class DeletePurchaseOrderModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
    }
}


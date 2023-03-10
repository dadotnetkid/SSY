using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.BulkPurchaseOrderRequests.Model
{
    public class DeleteBulkPurchaseOrderRequestModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
    }
}


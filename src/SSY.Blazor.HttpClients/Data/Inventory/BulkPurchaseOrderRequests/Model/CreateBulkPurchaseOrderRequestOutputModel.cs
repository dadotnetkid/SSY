using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.BulkPurchaseOrderRequests.Model
{
    public class CreateBulkPurchaseOrderRequestOutputModel
    {
        [JsonPropertyName("result")]
        public BulkPurchaseOrderRequestModel Result { get; set; }
    }
}


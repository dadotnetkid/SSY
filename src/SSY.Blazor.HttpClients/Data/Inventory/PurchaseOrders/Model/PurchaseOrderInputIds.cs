using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace SSY.Blazor.HttpClients.Data.Inventory.PurchaseOrders.Model;

public class PurchaseOrderInputIds

{

    [JsonPropertyName("purchaseOrderIds")]
    public List<Guid> PurchaseOrderIds { get; set; }
}


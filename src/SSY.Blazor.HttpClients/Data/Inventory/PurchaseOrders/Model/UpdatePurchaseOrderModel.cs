using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.PurchaseOrders.Model;

public class UpdatePurchaseOrderModel
{
    [JsonPropertyName("tenantId")]
    public int TenantId { get; set; } = 1;

    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("isActive")]
    public bool IsActive { get; set; } = true;

    [JsonPropertyName("number")]
    [Required]
    public string Number { get; set; }

    [JsonPropertyName("document")]
    public string? Document { get; set; }

    [JsonPropertyName("price")]
    public double? Price { get; set; }

    [JsonPropertyName("issuedDate")]
    [Required]
    public DateTime IssuedDate { get; set; }

    [JsonPropertyName("shippingInvoice")]
    public string? ShippingInvoice { get; set; }

    [JsonPropertyName("etd")]
    public DateTime? ETD { get; set; }

    [JsonPropertyName("eta")]
    public DateTime? ETA { get; set; }

    [JsonPropertyName("packingList")]
    public string? PackingList { get; set; }

    [JsonPropertyName("blawb")]
    public string? Blawb { get; set; }

    [JsonPropertyName("fabricInspectionReport")]
    public string? FabricInspectionReport { get; set; }

    [JsonPropertyName("fabricTestingReport")]
    public string? FabricTestingReport { get; set; }

    [JsonPropertyName("companyId")]
    public int? CompanyId { get; set; }

    [Required]
    [JsonPropertyName("purchaseOrderTypeId")]
    public int PurchaseOrderTypeId { get; set; } = new();

    [JsonPropertyName("requestId")]
    public string? RequestId { get; set; }

}


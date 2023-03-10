using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SSY.Blazor.HttpClients.Data.Inventory.Companies.Model;
using SSY.Blazor.HttpClients.Data.Inventory.PurchaseOrderTypes.Model;

namespace SSY.Blazor.HttpClients.Data.Inventory.PurchaseOrders.Model;

public class PurchaseOrderModel
{
    [JsonPropertyName("tenantId")]
    public int TenantId { get; set; } = 1;

    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("isActive")]
    public bool IsActive { get; set; } = true;

    [JsonPropertyName("number")]
    [Required(ErrorMessage = "This field is required.")]
    public string Number { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("document")]
    public string? Document { get; set; }

    [JsonPropertyName("price")]
    public double? Price { get; set; }

    [JsonPropertyName("issuedDate")]
    [Required(ErrorMessage = "This field is required.")]
    public DateTime IssuedDate { get; set; } = DateTime.Now;

    [JsonPropertyName("shippingInvoice")]
    public string? ShippingInvoice { get; set; }

    [JsonPropertyName("etd")]
    public DateTime? ETD { get; set; } = DateTime.Now;

    [JsonPropertyName("eta")]
    public DateTime? ETA { get; set; } = DateTime.Now;

    [JsonPropertyName("packingList")]
    public string? PackingList { get; set; }

    [JsonPropertyName("blawb")]
    public string? Blawb { get; set; }

    [JsonPropertyName("fabricInspectionReport")]
    public string? FabricInspectionReport { get; set; }

    [JsonPropertyName("fabricTestingReport")]
    public string? FabricTestingReport { get; set; }

    [JsonPropertyName("requestId")]
    public string? RequestId { get; set; }

    /// <summary>
    /// Supplier type ForeignKey
    /// </summary>
    [JsonPropertyName("companyId")]
    public int? CompanyId { get; set; }

    [JsonPropertyName("company")]
    public CompanyModel Company { get; set; } = new();

    [JsonPropertyName("purchaseOrderTypeId")]
    [Required(ErrorMessage = "This field is required.")]
    public int? PurchaseOrderTypeId { get; set; }

    [JsonPropertyName("purchaseOrderType")]
    [Required(ErrorMessage = "This field is required.")]
    public PurchaseOrderTypeModel PurchsaeOrderType { get; set; } = new();

    [JsonPropertyName("materialTypeText")]
    public string? MaterialTypeText { get; set; }
}
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SSY.Blazor.HttpClients.Data.Inventory.Accountabilities.Model;
using SSY.Blazor.HttpClients.Data.Inventory.Locations.Model;
using SSY.Blazor.HttpClients.Data.Inventory.PurchaseDetails.Model;

namespace SSY.Blazor.HttpClients.Data.Inventory.SubMaterials.Model
{
    public class UpdateSubMaterialModel
    {
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; } = 1;

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = true;

        [JsonPropertyName("id")]
        public Guid Id { get; set; }


        #region Accountability

        [JsonPropertyName("accountability")]
        public UpdateAccountabilityModel Accountability { get; set; }

        #endregion



        #region Overview

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("categoryId")]
        public int CategoryId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("typeId")]
        public int typeId { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("colorId")]
        public int ColorId { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("weight")]
        public double? Weight { get; set; } = null;

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("weightUnitId")]
        public int WeightUnitId { get; set; }

        #endregion


        #region Inventory

        [JsonPropertyName("totalCount")]
        public double TotalCount { get; set; }

        [JsonPropertyName("unitOfMeasurementId")]
        public int UnitOfMeasurementId { get; set; }

        [JsonPropertyName("minimumStockLevel")]
        public double? MinimumStockLevel { get; set; }

        [JsonPropertyName("incomingCount")]
        public double IncomingCount { get; set; }

        [JsonPropertyName("reservedCount")]
        public double ReservedCount { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("availableCount")]
        public double AvailableCount { get; set; }

        [JsonPropertyName("usedCount")]
        public double UsedCount { get; set; }

        [JsonPropertyName("onHandCount")]
        public double OnHandCount { get; set; }

        #endregion


        #region Roll And Location
        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("location")]
        public UpdateLocationModel Location { get; set; }

        #endregion


        #region Supplier

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("companyId")]
        public int CompanyId { get; set; }

        #endregion



        #region Purchase Detail

        [JsonPropertyName("purchaseDetail")]
        public UpdatePurchaseDetailModel PurchaseDetail { get; set; }

        #endregion


        [JsonPropertyName("poNumber")]
        public string? PONumber { get; set; }

        [JsonPropertyName("shippedCount")]
        public double? ShippedCount { get; set; }

        [JsonPropertyName("receivedCount")]
        public double? ReceivedCount { get; set; }
    }
}
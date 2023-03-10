using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SSY.Blazor.HttpClients.Data.Inventory.PurchaseDetails.Model;
using SSY.Blazor.HttpClients.Data.Inventory.Accountabilities.Model;
using SSY.Blazor.HttpClients.Data.Inventory.Locations.Model;

namespace SSY.Blazor.HttpClients.Data.Inventory.SubMaterials.Model
{
    public class CreateSubMaterialModel
    {
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; } = 1;

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = true;


        #region Accountability

        [JsonPropertyName("accountability")]
        public CreateAccountabilityModel Accountability { get; set; }

        #endregion



        #region Overview

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("categoryId")]
        public int CategoryId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required]
        [JsonPropertyName("typeId")]
        public int TypeId { get; set; }

        [Required]
        [JsonPropertyName("colorId")]
        public int ColorId { get; set; }

        [Required]
        [JsonPropertyName("weight")]
        public double? Weight { get; set; } = null;

        [Required]
        [JsonPropertyName("weightUnitId")]
        public int WeightUnitId { get; set; }

        #endregion


        #region Inventory

        [JsonPropertyName("totalCount")]
        public double? TotalCount { get; set; }

        [Required]
        [JsonPropertyName("unitOfMeasurementId")]
        public int UnitOfMeasurementId { get; set; }

        [Required]
        [JsonPropertyName("minimumStockLevel")]
        public double? MinimumStockLevel { get; set; }

        [JsonPropertyName("incomingCount")]
        public double? IncomingCount { get; set; }

        [JsonPropertyName("reservedCount")]
        public double? ReservedCount { get; set; }

        [JsonPropertyName("availableCount")]
        public double? AvailableCount { get; set; }

        [JsonPropertyName("usedCount")]
        public double? UsedCount { get; set; }

        [JsonPropertyName("onHandCount")]
        public double? OnHandCount { get; set; }

        #endregion


        #region Roll And Location
        [Required]
        [JsonPropertyName("location")]
        public CreateLocationModel Location { get; set; }

        #endregion


        #region Supplier

        [Required]
        [JsonPropertyName("companyId")]
        public int CompanyId { get; set; }

        #endregion



        #region Purchase Detail
        [Required]
        [JsonPropertyName("purchaseDetail")]
        public CreatePurchaseDetailModel PurchaseDetail { get; set; }

        #endregion

        [JsonPropertyName("poNumber")]
        public string? PONumber { get; set; }

        [JsonPropertyName("shippedCount")]
        public double? ShippedCount { get; set; }

        [JsonPropertyName("receivedCount")]
        public double? ReceivedCount { get; set; }



        public CreateSubMaterialModel()
        {
            Location = new();
            PurchaseDetail = new();
        }
    }
}

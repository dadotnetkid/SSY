using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using SSY.Blazor.HttpClients.Data.Inventory.Accountabilities.Model;
using SSY.Blazor.HttpClients.Data.Inventory.Companies.Model;
using SSY.Blazor.HttpClients.Data.Inventory.Locations.Model;
using SSY.Blazor.HttpClients.Data.Inventory.PurchaseDetails.Model;
using SSY.Blazor.HttpClients.Data.Inventory.Reservations.Model;


namespace SSY.Blazor.HttpClients.Data.Inventory.SubMaterials.Model
{
    public class SubMaterialModel
    {

        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; } = 1;

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = true;


        #region Accountability

        [JsonPropertyName("accountabilityId")]
        public Guid? AccountabilityId { get; set; }

        [JsonPropertyName("accountability")]
        public AccountabilityModel Accountability { get; set; } = new();

        #endregion


        #region Overview


        [JsonPropertyName("image")]
        public string Image { get; set; }


        [JsonPropertyName("categoryId")]
        public int CategoryId { get; set; }
        [JsonPropertyName("categoryLabel")]
        public string CategoryLabel { get; set; }
        [JsonPropertyName("categoryValue")]
        public string CategoryValue { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("typeId")]
        public int? TypeId { get; set; }
        [JsonPropertyName("typeLabel")]
        public string TypeLabel { get; set; }
        [JsonPropertyName("typeValue")]
        public string TypeValue { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("colorId")]
        public int? ColorId { get; set; }
        [JsonPropertyName("colorLabel")]
        public string ColorLabel { get; set; }
        [JsonPropertyName("colorValue")]
        public string ColorValue { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("weight")]
        public double? Weight { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("weightUnitId")]
        public int? WeightUnitId { get; set; }
        [JsonPropertyName("weightUnitLabel")]
        public string WeightUnitLabel { get; set; }
        [JsonPropertyName("weightUnitValue")]
        public string WeightUnitValue { get; set; }

        #endregion


        #region Inventory

        [JsonPropertyName("totalCount")]
        public double TotalCount { get; set; }

        [JsonPropertyName("onHandCount")]
        public double? OnHandCount { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required.")]
        [JsonPropertyName("unitOfMeasurementId")]
        public int? UnitOfMeasurementId { get; set; }

        [JsonPropertyName("unitOfMeasurementLabel")]
        public string UnitOfMeasurementLabel { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("unitOfMeasurementValue")]
        public string UnitOfMeasurementValue { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("minimumStockLevel")]
        public double? MinimumStockLevel { get; set; }

        [JsonPropertyName("incomingCount")]
        public double? IncomingCount { get; set; }

        [JsonPropertyName("reservedCount")]
        public double ReservedCount { get; set; }

        [JsonPropertyName("availableCount")]
        public double AvailableCount { get; set; }

        [JsonPropertyName("usedCount")]
        public double? UsedCount { get; set; }

        #endregion


        #region Roll And Location

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("locationId")]
        public Guid? LocationId { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("location")]
        public LocationModel Location { get; set; } = new();

        public List<ReservationOverviewModel> ReservationOverviews { get; set; } = new();

        #endregion


        #region Supplier
        [Required]
        [JsonPropertyName("companyId")]
        public int CompanyId { get; set; }

        [JsonPropertyName("company")]
        public CompanyModel Company { get; set; } = new();

        #endregion



        #region Purchase Detail

        [JsonPropertyName("purchaseDetailId")]
        public Guid? PurchaseDetailId { get; set; }

        [JsonPropertyName("purchaseDetail")]
        public PurchaseDetailModel? PurchaseDetail { get; set; } = new();

        #endregion
        [JsonPropertyName("creationTime")]
        public string CreationTime { get; set; }


        #region For Purchase Order
        [JsonPropertyName("poNumber")]
        public string? PONumber { get; set; }

        [JsonPropertyName("shippedQuantity")]
        public double? ShippedCount { get; set; }

        [JsonPropertyName("receivedQuantity")]
        public double? ReceivedCount { get; set; }

        [JsonPropertyName("isReceived")]
        public bool IsReceived { get; set; }

        [JsonPropertyName("subMaterialReservations")]
        public List<SubMaterialReservationModel> SubMaterialReservations { get; set; } = new();
        #endregion
    }
}
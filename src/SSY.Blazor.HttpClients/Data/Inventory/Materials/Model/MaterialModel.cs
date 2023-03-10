using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SSY.Blazor.HttpClients.Data.Inventory.Reservations.Model;
using SSY.Blazor.HttpClients.Data.Inventory.RollsAndLocations.Model;
using SSY.Blazor.HttpClients.Data.Inventory.CompositionsAndConstructions.Model;
using SSY.Blazor.HttpClients.Data.Inventory.ProductAssignments.Model;
using SSY.Blazor.HttpClients.Data.Inventory.Companies.Model;
using SSY.Blazor.HttpClients.Data.Inventory.PurchaseDetails.Model;
using SSY.Blazor.HttpClients.Data.Inventory.Accountabilities.Model;

namespace SSY.Blazor.HttpClients.Data.Inventory.Materials.Model
{
    public class MaterialModel
    {
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; } = 1;

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = true;

        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        #region Accountability
        /// <summary>
        /// Accountability ForeignKey
        /// </summary>
        [JsonPropertyName("accountabilityId")]
        public Guid? AccountabilityId { get; set; }

        [JsonPropertyName("accountability")]
        public AccountabilityModel Accountability { get; set; } = new();

        #endregion

        #region Overview and Description

        /// <summary>
        /// Uneditable field
        /// Supplier(1st section)(ShortCode) + Item code + Color code + Excess/New + Material type short code + Unique number
        /// Example: YTI-7526079-095A-E-GAW-001
        /// </summary>
        //[Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Product Assignments
        /// </summary>
        [JsonPropertyName("assignments")]
        public List<ProductAssignmentModel> Assignments { get; set; } = new();

        public void AddAssingment(ProductAssignmentModel assignment)
        {
            Assignments.Add(assignment);
        }

        [JsonPropertyName("assignmentIds")]
        //public string AssignmentIds { get; set; }
        public string AssignmentIds { get; set; }

        [JsonPropertyName("assignmentList")]
        public List<int> AssignmentList { get; set; } = new();

        #region MassUploadForm

        //public Guid? MediaFileId { get; set; }
        //[ForeignKey(nameof(MediaFileId))]
        //public MediaFile MediaFile { get; set; }

        /// <summary>
        /// Use MediaFile entity in the future when integrated with AWS S3 Bucket
        /// </summary>
        [JsonPropertyName("image")]
        public string Image { get; set; }

        /// <summary>
        /// Category ForeignKey
        /// </summary>
        [JsonPropertyName("categoryId")]
        public int CategoryId { get; set; }

        [JsonPropertyName("categoryLabel")]
        public string CategoryLabel { get; set; }

        [JsonPropertyName("categoryValue")]
        public string CategoryValue { get; set; }

        /// <summary>
        /// Material type ForeignKey
        /// </summary>
        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("typeId")]
        public int? TypeId { get; set; }

        [JsonPropertyName("typeLabel")]
        public string TypeLabel { get; set; }
        [JsonPropertyName("typeValue")]
        public string TypeValue { get; set; }

        /// <summary>
        /// OEM Item Code
        /// </summary>
        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("itemCode")]
        public string ItemCode { get; set; }

        /// <summary>
        /// OEM Color Code
        /// </summary>
        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("colorCode")]
        public string ColorCode { get; set; }

        /// <summary>
        /// Color ForeignKey
        /// </summary>
        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("colorId")]
        public int? ColorId { get; set; }

        [JsonPropertyName("colorLabel")]
        public string ColorLabel { get; set; }

        [JsonPropertyName("colorValue")]
        public string ColorValue { get; set; }

        /// <summary>
        /// Pantone # (TCX Code)
        /// </summary>
        [JsonPropertyName("pantone")]
        public string? Pantone { get; set; }

        /// <summary>
        /// Weight/Yarn Count
        /// </summary>
        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("weight")]
        public double? Weight { get; set; }

        /// <summary>
        /// Weight Unit ForeignKey
        /// </summary>
        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("weightUnitId")]
        public int? WeightUnitId { get; set; } = 1003;
        [JsonPropertyName("weightUnitLabel")]
        public string WeightUnitLabel { get; set; }
        [JsonPropertyName("weightUnitValue")]
        public string WeightUnitValue { get; set; }

        /// <summary>
        /// Cuttable Width
        /// </summary>
        [JsonPropertyName("cuttableWidth")]
        public string? CuttableWidth { get; set; }

        #region Use to Generate MaterialName for UI

        [JsonPropertyName("supplierShortCode")]
        public string SupplierShortCode { get; set; }

        [JsonPropertyName("excessOrNew")]
        public string ExcessOrNew { get; set; }

        [JsonPropertyName("categoryName")]
        public string CategoryName { get; set; }

        [JsonPropertyName("colorGroup")]
        public string ColorGroup { get; set; }

        [JsonPropertyName("unitOfMeasurementName")]
        public string UnitOfMeasurementName { get; set; }

        [JsonPropertyName("creationTime")]
        public string CreationTime { get; set; }

        [JsonPropertyName("typeName")]
        public string TypeName { get; set; }

        #endregion

        #endregion

        #endregion

        #region Inventory

        /// <summary>
        /// Expected Count
        /// </summary>
        [JsonPropertyName("incomingCount")]
        public double? IncomingCount { get; set; }

        /// <summary>
        /// Reserved Count
        /// </summary>
        [JsonPropertyName("reservedCount")]
        public double? ReservedCount { get; set; }

        /// <summary>
        /// Available Count
        /// </summary>
        [JsonPropertyName("availableCount")]
        public double? AvailableCount { get; set; }

        /// <summary>
        /// Used Count
        /// </summary>
        [JsonPropertyName("usedCount")]
        public double? UsedCount { get; set; }

        /// <summary>
        /// Minimum Stock Level
        /// </summary>
        [JsonPropertyName("minimumStockLevel")]
        public double? MinimumStockLevel { get; set; }

        /// <summary>
        /// On Hand Count
        /// </summary>
        [JsonPropertyName("onHandCount")]
        public double? OnHandCount { get; set; }

        #region MassUploadForm

        /// <summary>
        /// Actual Count
        /// </summary>
        [Required]
        [JsonPropertyName("totalCount")]
        public double TotalCount { get; set; }

        /// <summary>
        /// Unit of Measurement ForeignKey
        /// </summary>
        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("unitOfMeasurementId")]
        public int? UnitOfMeasurementId { get; set; }

        [JsonPropertyName("unitOfMeasurementLabel")]
        public string UnitOfMeasurementLabel { get; set; }

        [JsonPropertyName("unitOfMeasurementValue")]
        public string UnitOfMeasurementValue { get; set; }


        #endregion

        #endregion

        #region Roll And Location

        /// <summary>
        /// Rolls and Locations
        /// </summary>
        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("rollsAndLocations")]
        public List<RollAndLocationModel> RollsAndLocations { get; set; } = new();

        public List<RollReservationModel> Reservations { get; set; } = new();

        public List<ReservationOverviewModel> ReservationOverviews { get; set; } = new();


        //public List<List<RollReservationModel>> ReservationsByWar { get; set; } = new();


        // [JsonPropertyName("rollAndLocation")]
        // public RollAndLocationModel RollAndLocation { get; set; }

        /// <summary>
        /// Add Roll and Location
        /// </summary>
        /// <param name="rollAndLocation"></param>
        public void AddRollAndLocation(RollAndLocationModel rollAndLocation)
        {
            RollsAndLocations.Add(rollAndLocation);
        }

        #endregion

        #region Composition and Construction

        /// <summary>
        /// Composition and Construction ForeignKey
        /// </summary>
        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("compositionAndConstructionId")]
        public Guid CompositionAndConstructionId { get; set; }

        [JsonPropertyName("compositionAndConstruction")]
        public CompositionAndConstructionModel CompositionAndConstruction { get; set; } = new();

        #endregion

        #region Miscellanous

        /// <summary>
        /// Care Instruction type ForeignKey
        /// </summary>
        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("careInstructionTypeId")]
        public int? CareInstructionTypeId { get; set; }

        [JsonPropertyName("careInstructionTypeLabel")]
        public string CareInstructionTypeLabel { get; set; }

        [JsonPropertyName("careInstructionTypeValue")]
        public string CareInstructionTypeValue { get; set; }

        [JsonPropertyName("careInstruction")]
        public string CareInstruction { get; set; }


        #endregion

        #region Supplier

        /// <summary>
        /// Supplier type ForeignKey
        /// </summary>
        //[Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("companyId")]
        public int CompanyId { get; set; }

        [JsonPropertyName("company")]
        public CompanyModel Company { get; set; } = new();

        #endregion

        #region Purchase Detail

        [JsonPropertyName("purchaseDetail")]
        public PurchaseDetailModel PurchaseDetail { get; set; } = new();

        [JsonPropertyName("colorOptionId")]
        public Guid ColorOptionId { get; set; }

        #endregion

        public bool isDisabled { get; set; } = false;

        [JsonPropertyName("collectionName")]
        public string CollectionName { get; set; }

        [JsonPropertyName("influencerNames")]
        public List<string> InfluencerNames { get; set; }

        [JsonPropertyName("isSelected")]
        public bool IsSelected { get; set; } = false;

        [JsonPropertyName("ordinal")]
        public string Ordinal { get; set; }

        [JsonPropertyName("selectedOrdinal")]
        public string SelectedOrdinal { get; set; }
    }
}

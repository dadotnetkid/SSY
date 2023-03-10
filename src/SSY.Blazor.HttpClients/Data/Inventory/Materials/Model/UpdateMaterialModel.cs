using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.Json;
using SSY.Blazor.HttpClients.Data.Inventory.RollsAndLocations.Model;
using SSY.Blazor.HttpClients.Data.Inventory.PurchaseDetails.Model;
using SSY.Blazor.HttpClients.Data.Inventory.CompositionsAndConstructions.Model;
using SSY.Blazor.HttpClients.Data.Inventory.Accountabilities.Model;

namespace SSY.Blazor.HttpClients.Data.Inventory.Materials.Model
{
    public class UpdateMaterialModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        #region Accountability

        /// <summary>
        /// Accountability ForeignKey
        /// </summary>
        [JsonPropertyName("accountability")]
        public UpdateAccountabilityModel Accountability { get; set; }

        #endregion

        [JsonPropertyName("name")]
        public string Name { get; set; }





        #region Overview and Description

        /// <summary>
        /// Product Assignments
        /// </summary
        [JsonPropertyName("assignmentIds")]
        public string AssignmentIds { get { return JsonSerializer.Serialize(AssignmentList); } }

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

        /// <summary>
        /// Material type ForeignKey
        /// </summary>
        [Required]
        [JsonPropertyName("typeId")]
        public int? TypeId { get; set; }

        /// <summary>
        /// OEM Item Code
        /// </summary>
        [Required]
        [JsonPropertyName("itemCode")]
        public string? ItemCode { get; set; }

        /// <summary>
        /// OEM Color Code
        /// </summary>
        [Required]
        [JsonPropertyName("colorCode")]
        public string? ColorCode { get; set; }

        /// <summary>
        /// Color ForeignKey
        /// </summary>
        [Required]
        [JsonPropertyName("colorId")]
        public int? ColorId { get; set; }

        /// <summary>
        /// Pantone # (TCX Code)
        /// </summary>
        [JsonPropertyName("pantone")]
        public string? Pantone { get; set; }

        /// <summary>
        /// Weight
        /// </summary>
        [Required]
        [JsonPropertyName("weight")]
        public double? Weight { get; set; }

        /// <summary>
        /// Weight Unit ForeignKey
        /// </summary>
        [Required]
        [JsonPropertyName("weightUnitId")]
        public int? WeightUnitId { get; set; }

        /// <summary>
        /// Cuttable Width
        /// </summary>
        [JsonPropertyName("cuttableWidth")]
        public string? CuttableWidth { get; set; }

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
        /// On Hand Count
        /// </summary>
        [JsonPropertyName("onHandCount")]
        public double? OnHandCount { get; set; }

        /// <summary>
        /// Minimum Stock Level
        /// </summary>
        [JsonPropertyName("minimumStockLevel")]
        public double? MinimumStockLevel { get; set; }

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
        [Required]
        [JsonPropertyName("unitOfMeasurementId")]
        public int? UnitOfMeasurementId { get; set; }

        #endregion

        #endregion

        #region Roll And Location

        /// <summary>
        /// Rolls and Locations
        /// </summary>
        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("rollsAndLocations")]
        public List<UpdateRollAndLocationModel> RollsAndLocations { get; set; }

        #endregion

        #region Composition and Construction

        /// <summary>
        /// Composition and Construction ForeignKey
        /// </summary>
        [Required]
        [JsonPropertyName("compositionAndConstruction")]
        public UpdateCompositionAndConstructionModel? CompositionAndConstruction { get; set; }

        #endregion

        #region Miscellanous

        /// <summary>
        /// Care Instruction type ForeignKey
        /// </summary>
        [Required]
        [JsonPropertyName("careInstructionTypeId")]
        public int? CareInstructionTypeId { get; set; }

        #endregion

        #region Supplier

        /// <summary>
        /// Supplier type ForeignKey
        /// </summary>
        [Required]
        [JsonPropertyName("companyId")]
        public int? CompanyId { get; set; }

        #endregion

        #region Purchase Detail

        /// <summary>
        /// Purchase Detail type ForeignKey
        /// </summary>
        [JsonPropertyName("purchaseDetail")]
        public UpdatePurchaseDetailModel PurchaseDetail { get; set; }

        #endregion

        [JsonPropertyName("collectionName")]
        public string CollectionName { get; set; }

        [JsonPropertyName("influencerNames")]
        public List<string> InfluencerNames { get; set; }


    }
}

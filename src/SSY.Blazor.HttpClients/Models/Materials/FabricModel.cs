using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SSY.Blazor.HttpClients.Data.Inventory.Accountabilities.Model;
using SSY.Blazor.HttpClients.Data.Inventory.Companies.Model;
using SSY.Blazor.HttpClients.Data.Inventory.CompositionsAndConstructions.Model;
using SSY.Blazor.HttpClients.Data.Inventory.PurchaseDetails.Model;
using SSY.Blazor.HttpClients.Data.Inventory.RollsAndLocations.Model;

namespace SSY.Blazor.HttpClients.Models.Materials
{
    public class FabricListModel
    {
        public List<FabricModel> FabricList { get; set; }
        public FabricListModel()
        {
        }
    }

    public class FabricData
    {
        [JsonPropertyName("result")]
        public FabricResults Result { get; set; }

    }
    public class FabricResults
    {
        [JsonPropertyName("totalCount")]
        public int TotalCount { get; set; }

        [JsonPropertyName("items")]
        public List<FabricModel> Items { get; set; }
    }
    public class FabricResult
    {
        [JsonPropertyName("result")]
        public FabricModel Result { get; set; }

    }

    public class FabricModel
    {
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; } = 1;
        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        #region Accountability

        [Required]

        [JsonPropertyName("accountabilityId")]
        public Guid AccountabilityId { get; set; }
        public AccountabilityModel Accountability { get; set; }

        #endregion

        #region Overview

        [Required]

        [JsonPropertyName("overviewId")]
        public Guid OverviewId { get; set; }
        public OverviewModel Overview { get; set; }

        #endregion

        #region Inventory

        [Required]
        [JsonPropertyName("massUploadInventoryId")]
        public Guid MassUploadInventoryId { get; set; }
        public InventoryModel Inventory { get; set; }

        #endregion

        #region Composition and Construction

        [Required]
        [JsonPropertyName("compositionAndConstructionId")]
        public Guid CompositionAndConstructionId { get; set; }
        public CompositionAndConstructionModel CompositionAndConstruction { get; set; }

        #endregion

        #region Miscellanous

        [Required]
        [JsonPropertyName("miscellaneousId")]
        public Guid MiscellaneousId { get; set; }
        public MiscellaneousModel Miscellaneous { get; set; }

        #endregion

        #region Roll And Location

        public RollAndLocationModel RollAndLocation { get; set; }
        public List<RollAndLocationModel> RollsAndLocations { get; set; }

        #endregion

        #region Supplier

        [Required]
        [JsonPropertyName("companyId")]
        public Guid CompanyId { get; set; }
        public CompanyModel Supplier { get; set; }


        #endregion

        #region Purchase Detail

        [JsonPropertyName("purchaseDetailId")]
        public Guid? PurchaseDetailId { get; set; }
        public PurchaseDetailModel PurchaseDetail { get; set; }

        #endregion




        public string Name { get; set; }

        [Required(ErrorMessage = "This Field is required")]
        public int TypeId { get; set; }

        [Required(ErrorMessage = "This Field is required")]
        public int ColorId { get; set; }

        [Required(ErrorMessage = "This Field is required")]
        public string ColorCode { get; set; }

        public string? ItemCode { get; set; }
        public string? Pantone { get; set; }
        public double? Weight { get; set; }
        public int? WeightUnitId { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string Construction { get; set; }

        public string? Gauge { get; set; }

        [Required]
        public int RecycledId { get; set; }

        [Required]
        public int ExcessId { get; set; }

        [Required]
        public int PreparedForPrintId { get; set; }

        [Required]
        public int CompressionId { get; set; }

        [Required]
        public int FabricStretchId { get; set; }

        [Required]
        public int CreaseId { get; set; }

        public int? PrintRepeatId { get; set; }

        [Required]
        public List<string> HandFeel { get; set; }

        [Required]
        public string CompanyCode { get; set; }

        [Required(ErrorMessage = "This Field is required")]
        public double ActualCount { get; set; }
        public double? MinimumStockLevel { get; set; }
        public double ExpectedCount { get; set; }
        public double ReservedCount { get; set; }
        public double AvailableCount { get; set; }
        public double UsedCount { get; set; }

        [Required(ErrorMessage = "This Field is required")]
        public int UnitOfMeasurementId { get; set; }

        [Required(ErrorMessage = "This Field is required")]
        public Guid MediaFileId { get; set; }


        [Required(ErrorMessage = "This Field is required")]
        public int? CareInstructionTypeId { get; set; }

        public int? CareInstructionId { get; set; }

        public List<FabricAssignmentModel> Assignments { get; set; }
    }



}
public class FabricAssignmentModel
{
    public int TenantId { get; set; } = 1;
    public bool IsActive { get; set; }
    public int Id { get; set; }
    public string Label { get; set; }
    public string Value { get; set; }
    public int OrderNumber { get; set; }
    public List<FabricTypeModel> Type { get; set; }

}
public class FabricTypeModel
{
    public int TenantId { get; set; } = 1;
    public bool IsActive { get; set; }
    public int Id { get; set; }
    public string Label { get; set; }
    public string Value { get; set; }
    public int OrderNumber { get; set; }
    public int CategoryId { get; set; }
}
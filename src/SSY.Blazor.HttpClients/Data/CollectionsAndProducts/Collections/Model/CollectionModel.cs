using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.AssignedTo.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.ProductSizes.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.Model;
using SSY.Blazor.HttpClients.Data.Inventory.Materials.Model;
using SSY.Blazor.HttpClients.Data.Inventory.RollsAndLocations.Model;
using SSY.Blazor.HttpClients.Data.Inventory.Types.Model;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Model
{
    public class CollectionModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; } = 1;

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = true;

        [JsonPropertyName("name")]
        public string Name { get; set; }

        // Influencers
        [JsonPropertyName("influencers")]
        public string Influencers { get; set; }

        [JsonPropertyName("influencersIds")]
        public string InfluencersIds { get { return JsonSerializer.Serialize(InfluencerIdsList); } }

        [JsonPropertyName("influencerIdsList")]
        public List<Guid> InfluencerIdsList { get; set; } = new();

        [JsonPropertyName("influencersList")]
        public List<Influencer> influencers { get; set; } = new();

        [JsonPropertyName("forecastQuantity")]
        public int ForecastQuantity { get; set; } = 0;

        public List<ProductModel> ParentProducts { get; set; } = new();

        [JsonPropertyName("parentProduct")]
        public int ParentProduct { get; set; }

        [JsonPropertyName("childProduct")]
        public int ChildProduct { get; set; }

        [JsonPropertyName("collectionDevelopmentStartDate")]
        public DateTime CollectionDevelopmentStartDate { get; set; }

        [JsonPropertyName("provisionalLaunchDate")]
        public DateTime ProvisionalLaunchDate { get; set; }

        [JsonPropertyName("statusId")]
        public int StatusId { get; set; }

        [JsonPropertyName("availability")]
        public bool Availability { get; set; }

        [JsonPropertyName("factoryId")]
        public int FactoryId { get; set; }

        [JsonPropertyName("shippingTypeId")]
        public int ShippingTypeId { get; set; }

        [JsonPropertyName("pricePointId")]
        public int PricePointId { get; set; }

        [JsonPropertyName("seasonId")]
        public int SeasonId { get; set; }

        [JsonPropertyName("marketingTypeId")]
        public int MarketingTypeId { get; set; }

        [JsonPropertyName("year")]
        public int Year { get; set; }

        [JsonPropertyName("designStatusId")]
        public int DesignStatusId { get; set; }

        // Material Types
        [JsonPropertyName("materialTypeIds")]
        public string MaterialTypeIds { get { return JsonSerializer.Serialize(MaterialTypeIdList); } }

        [JsonPropertyName("materialTypeIdList")]
        public List<int> MaterialTypeIdList { get; set; } = new();

        [JsonPropertyName("materialTypeNames")]
        public string MaterialTypeNames { get; set; }

        [JsonPropertyName("materialProductTypeList")]
        public List<MaterialProductTypes> MaterialProductTypeList { get; set; } = new();


        [JsonPropertyName("colorSelection")]
        public string ColorSelections { get { return JsonSerializer.Serialize(ColorSelectionList); } }

        [JsonPropertyName("colorSelectionList")]
        public List<ColorSelection> ColorSelectionList { get; set; } = new();

        [JsonPropertyName("sizingOptionId")]
        public int SizingOptionId { get; set; }

        [JsonPropertyName("sizingOptionsName")]
        public string SizingOptionsName { get; set; } = "Select Sizes";

        [JsonPropertyName("sizingOptionIds")]
        public List<int> SizingOptionIds { get; set; } = new();

        [JsonPropertyName("sizingOptionNames")]
        public List<string> SizingOptionNames { get; set; } = new();

        [JsonPropertyName("SizingOptionList")]
        public List<ProductSizeModel> SizingOptionList { get; set; } = new();

        [JsonPropertyName("isPublished")]
        public bool IsPublished { get; set; }

        public List<ProductByCatergory> ProductByCatergories { get; set; } = new();

        public double TotalProductSalesPercentage { get; set; }

        public double TotalColorSalesPercentage { get; set; }

        public double TotalSelectedProductTypeWeightedForecastQuantity { get; set; }

        public int selectedProductTypeCount { get; set; }

        public List<SelectedProductColor> SelectedProductColors { get; set; } = new();

        public List<SelectedColorProduct> SelectedColorProducts { get; set; } = new();

        public List<SelectedMaterialProduct> SelectedMaterialProducts { get; set; } = new();

        public List<SelectedProductType> SelectedProductTypes { get; set; } = new();

        public List<SPT> SPTs { get; set; } = new();

        public AssignedToModel? AssignedTo { get; set; } = new();

        [JsonPropertyName("currentFabricCount")]
        public int CurrentFabricCount { get; set; }

        public class ColorSelection
        {
            [JsonPropertyName("id")]
            public Guid Id { get; set; }
            [JsonPropertyName("colorOptionId")]
            public Guid ColorOptionId { get; set; }
            [JsonPropertyName("collectionId")]
            public Guid CollectionId { get; set; }
            [JsonPropertyName("colorId")]
            public int ColorId { get; set; }
            [JsonPropertyName("colorValue")]
            public string ColorValue { get; set; }
            [JsonPropertyName("colorShortCode")]
            public string ColorShortCode { get; set; }

            [JsonPropertyName("hexCode")]
            public string HexCode { get; set; } = "#7B8D61";

            public List<MaterialModel> Materials { get; set; } = new();

            [JsonPropertyName("typeId")]
            public int MaterialTypeId { get; set; }
            [JsonPropertyName("typeValue")]
            public string MaterialTypeName { get; set; }
            [JsonPropertyName("fabricComposition")]
            public string FabricComposition { get; set; }
            [JsonPropertyName("careInstruction")]
            public string CareInstruction { get; set; }

            [JsonPropertyName("productTypeIds")]
            public List<int> ProductTypeIds { get; set; } = new();
            [JsonPropertyName("productTypes")]
            public List<Items> ProductTypes { get; set; } = new();

            [JsonPropertyName("colorCode")]
            public string ColorCode { get; set; }

            [JsonPropertyName("itemCode")]
            public string ItemCode { get; set; }

            [JsonPropertyName("unitOfMeasurement")]
            public string UnitOfMeasurement { get; set; }

            [JsonPropertyName("cuttableWidth")]
            public string CuttableWidth { get; set; }

            [JsonPropertyName("contentDescription")]
            public string ContentDescription { get; set; }

            [JsonPropertyName("price")]
            public double Price { get; set; }

            [JsonPropertyName("supplier")]
            public string Supplier { get; set; }

            [JsonPropertyName("materialId")]
            public Guid MaterialId { get; set; }
            [JsonPropertyName("materialName")]
            public string MaterialName { get; set; }
            [JsonPropertyName("title")]
            public string Title { get; set; }
            [JsonPropertyName("swatchImage")]
            public string SwatchImage { get; set; }

            public int MaxQuantityUnit { get; set; }
            public string RollReservationMessage { get; set; } = string.Empty;
            public List<RollAndLocationModel> RollAndLocations { get; set; } = new();
            public List<Guid> SelectedRollIds { get; set; } = new();
            public List<RollAndLocationModel> SelectedRollAndLocation { get; set; } = new();
            public List<RollAndLocationModel> SelectedRolls { get; set; } = new();
            public List<string> SelectedRollWarehouse { get; set; } = new();
            public List<string> SelectedRollNames { get; set; } = new();
            public string SelectRolls { get; set; } = "Select Rolls";
            public string collapseRoll { get; set; } = "";
            public bool isFabricOnSite { get; set; } = false;
            public double TotalRollYardage { get; set; }
            public double TotalRollYardagePercentage { get; set; }
            public double ProductTypeConsumption { get; set; }
            public double Summation { get; set; }
            public double ProductTypeForecastQuantity { get; set; }
            public double MaxQuantity { get; set; }
            public double MaxQuantityUsingAllocatedAndUnallocated { get; set; }
            public double RequiredYardage { get; set; }

            [JsonPropertyName("salesPercentage")]
            public double SalesPercentage { get; set; }
            [JsonPropertyName("weightedSalesPercentage")]
            public double WeightedSalesPercentage { get; set; }

            public double TotalWeightedForecastQuantity { get; set; }

            public bool? IsApproved { get; set; }
            public bool? IsRejected { get; set; }
            public DateTime? ApprovedOn { get; set; }
            public string? ApprovedBy { get; set; }

            public bool ApprovalIsApprove { get; set; } = false;
            public bool ApprovalIsReject { get; set; } = false;

            public int FabricCount { get; set; }
            public List<Guid> SelectedFabricIds { get; set; } = new();
            public List<FabricSelection> FabricSelectionList { get; set; } = new();

            public List<BOMMaterial> BOMMaterial { get; set; } = new();
            public bool IsAvailableInAllColors { get; set; } = false;
        }

        public class MaterialProductTypes
        {
            [JsonPropertyName("materialTypeId")]
            public int MaterialTypeId { get; set; }
            [JsonPropertyName("materialTypeShortCode")]
            public string MaterialTypeShortCode { get; set; }
            [JsonPropertyName("materialTypeName")]
            public string MaterialTypeName { get; set; }
            [JsonPropertyName("productTypeIds")]
            public List<int> ProductTypeIds { get; set; } = new();
            [JsonPropertyName("productTypeNames")]
            public List<string> ProductTypeNames { get; set; } = new();
            [JsonPropertyName("selectedProductTypeNames")]
            public string selectedProductTypeNames { get; set; } = "Select Product Types";

            [JsonPropertyName("IsApplied")]
            public bool IsApplied { get; set; } = false;

            public List<TypeModel> MaterialTypes { get; set; } = new();
            public List<Items> ProductTypes { get; set; } = new();

            public List<int> SelectedColorIds { get; set; } = new();
            public List<Items> Colors { get; set; } = new();

            [JsonPropertyName("totalForecast")]
            public double TotalForecast { get; set; }

            [JsonPropertyName("totalMaxQuantity")]
            public double TotalMaxQuantity { get; set; }
        }

        public class ProductByCatergory
        {
            public int? ProductCategoryId { get; set; }
            public List<ProductType> ProductTypes { get; set; } = new();
            public double TotalSubPercentage { get; set; }
        }

        public class ProductType
        {
            public int ProductTypeId { get; set; }
            public int MaterialTypeId { get; set; }
            public double AverageConsumption { get; set; }
            public double Percentage { get; set; }
            public double SubPercentage { get; set; }
            public double WeightedSubPercentage { get; set; }
            public double SalesPercentage { get; set; }
            public double WeightedSalesPercentage { get; set; }
            public double WeightedForecastQuantity { get; set; }
        }

        public class SelectedProductColor
        {
            public int MaterialTypeId { get; set; }
            public int ProductTypeId { get; set; }
            public List<int> ColorIds { get; set; } = new();
        }

        public class SelectedColorProduct
        {
            public int MaterialTypeId { get; set; }
            public int ColorId { get; set; }
            public string ColorValue { get; set; }
            public string Title { get; set; }
            public List<int> ProductTypeIds { get; set; } = new();
            public List<Items> ProductTypes { get; set; } = new();
            public double WeightedSalesPercentage { get; set; }
        }

        public class SelectedMaterialProduct
        {
            public int MaterialTypeId { get; set; }
            public double WeightedSalesPercentage { get; set; }
            public int ProductTypeId { get; set; }
            public double TotalProductRequiredYardage { get; set; }
            public int ColorId { get; set; }
            public Items ProductType { get; set; }
        }

        public class SelectedProductType
        {
            public int MaterialTypeId { get; set; }
            public int ProductTypeId { get; set; }
            public double RequiredYardage { get; set; }
            public int ColorId { get; set; }
            public double TotalRequiredYardage { get; set; }
        }

        public class SPT
        {
            public Guid ColorOptionId { get; set; }
            public int MaterialTypeId { get; set; }
            public int ProductTypeId { get; set; }
            public Items ProductType { get; set; }
            public double ProductTypeSalesPercentage { get; set; }
            public int ColorId { get; set; }
            public string ColorValue { get; set; }
            public string Title { get; set; }
            public double ColorSalesPercentage { get; set; }
            public double RequiredYardage { get; set; }
        }

        public class BOMMaterial
        {
            public string Thumbnail { get; set; }
            public string ItemCode { get; set; }
            public string ColorCode { get; set; }
            public int ColorId { get; set; }
            public string ColorName { get; set; }
            public double AllocatedAmount { get; set; }
            public double RemainingAllocatedAfterSold { get; set; }
            public double UnallocatedAmount { get; set; }
            public string UnitOfMeasurement { get; set; }
            public double Consumption { get; set; }
            public double MaxQuantityUsingAllocatedAndUnallocated { get; set; }
            public double MaxQuantityUsingAllocated { get; set; }
        }

        public class Influencer
        {
            public bool IsActive { get; set; }
            public Guid Id { get; set; }
            public string InfluencerFullName { get; set; }
            public string InfluencerName { get; set; }
            public string InfluencerSurame { get; set; }
            public string Email { get; set; }
        }

        public class FabricSelection
        {
            public Guid Id { get; set; }
            public Guid CollectionId { get; set; }
            public Guid ColorOptionId { get; set; }
            public Guid MaterialId { get; set; }
            public string Ordinal { get; set; }
            public int OrdinalNumber { get; set; }
            public int ColorId { get; set; }
            public List<Guid> Rolls { get; set; } = new();
            public double FabricRerservedYardage { get; set; }

            public List<RollAndLocationModel> RollAndLocations { get; set; } = new();
            public string MaterialName { get; set; }
            public string SwatchImage { get; set; }
           
            public string FabricComposition { get; set; }
            public string CareInstruction { get; set; }
            public string ColorCode { get; set; }
            public string ItemCode { get; set; }
            public string UnitOfMeasurement { get; set; }
            public string CuttableWidth { get; set; }
            public string ContentDescription { get; set; }
            public double Price { get; set; }
            public string Supplier { get; set; }

            public string HexCode { get; set; } = "#7B8D61";
            public string ColorShortCode { get; set; }
            public string ColorValue { get; set; }
            public double SalesPercentage { get; set; }

            public string collapseRoll { get; set; }
            public string SelectRolls { get; set; } = "Select Rolls";
            public List<string> SelectedRollWarehouse { get; set; } = new();
            public List<RollAndLocationModel> SelectedRolls { get; set; } = new();
            public List<Guid> SelectedRollIds { get; set; } = new();
            public string RollReservationMessage { get; set; }
            public List<RollAndLocationModel> SelectedRollAndLocation { get; set; } = new();
            public List<string> SelectedRollNames { get; set; } = new();

            public bool isFabricOnSite { get; set; } = false;

            public double TotalRollYardage { get; set; }
            public double TotalRollYardagePercentage { get; set; }
            public double ProductTypeConsumption { get; set; }
            public double Summation { get; set; }
            public double ProductTypeForecastQuantity { get; set; }
            public double MaxQuantity { get; set; }
            public double MaxQuantityUsingAllocatedAndUnallocated { get; set; }
            public double RequiredYardage { get; set; }

            [JsonPropertyName("weightedSalesPercentage")]
            public double WeightedSalesPercentage { get; set; }

            public double TotalWeightedForecastQuantity { get; set; }
        }
    }

}
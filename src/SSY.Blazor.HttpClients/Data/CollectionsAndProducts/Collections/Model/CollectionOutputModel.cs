using System;
using System.Text.Json.Serialization;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.Model;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Model
{
    public class CollectionOutputModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("TenantId")]
        public int TenantId { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("influencers")]
        public List<InfluencersOutputModel> Influencers { get; set; } = new();

        [JsonPropertyName("influencerNames")]
        public string InfluencerNames { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("seasonId")]
        public int SeasonId { get; set; }

        [JsonPropertyName("pricePointId")]
        public int PricePointId { get; set; }

        [JsonPropertyName("factoryId")]
        public int FactoryId { get; set; }

        [JsonPropertyName("shippingTypeId")]
        public int ShippingTypeId { get; set; }

        [JsonPropertyName("marketingTypeId")]
        public int MarketingTypeId { get; set; }

        [JsonPropertyName("year")]
        public int Year { get; set; }

        [JsonPropertyName("designStatusId")]
        public int DesignStatusId { get; set; }

        [JsonPropertyName("materialProductTypes")]
        public List<MaterialProductTypesOutputModel> MaterialProductTypes { get; set; } = new();

        [JsonPropertyName("colorOptions")]
        public List<CollectionColorOptionsOutputModel> ColorOptions { get; set; } = new();

        [JsonPropertyName("parentProducts")]
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

        [JsonPropertyName("statusHexCode")]
        public string StatusHexCode { get; set; }

        [JsonPropertyName("availability")]
        public bool Availability { get; set; }

        [JsonPropertyName("sizingOptions")]
        public List<CollectionSizingOptionOutputModel> SizingOptions { get; set; } = new();

        [JsonPropertyName("designerIId")]
        public int DesignerIId { get; set; }

        [JsonPropertyName("designerIIId")]
        public int DesignerIIId { get; set; }

        [JsonPropertyName("ssyMerchandiserId")]
        public int SsyMerchandiserId { get; set; }

        [JsonPropertyName("oemMerchandiserId")]
        public int OemMerchandiserId { get; set; }

        [JsonPropertyName("oemPatternMakerId")]
        public int OemPatternMakerId { get; set; }

        [JsonPropertyName("creationTime")]
        public DateTime CreationTime { get; set; }

        [JsonPropertyName("isPublished")]
        public bool IsPublished { get; set; }

        [JsonPropertyName("collectionForecastQuantity")]
        public double? CollectionForecastQuantity { get; set; }

        [JsonPropertyName("collectionForecastRevenue")]
        public double? CollectionForecastRevenue { get; set; }
    }

    public class InfluencersOutputModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("TenantId")]
        public int TenantId { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("collectionId")]
        public Guid CollectionId { get; set; }

        [JsonPropertyName("influencerId")]
        public Guid InfluencerId { get; set; }

        [JsonPropertyName("influencerFullName")]
        public string InfluencerFullName { get; set; }

        [JsonPropertyName("influencerName")]
        public string InfluencerName { get; set; }

        [JsonPropertyName("influencerSurName")]
        public string InfluencerSurName { get; set; }

        [JsonPropertyName("influencerProductQuantityForecast")]
        public double? InfluencerProductQuantityForecast { get; set; }
    }

    public class MaterialProductTypesOutputModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("TenantId")]
        public int TenantId { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("collectionId")]
        public Guid CollectionId { get; set; }

        [JsonPropertyName("typeId")]
        public int TypeId { get; set; }

        [JsonPropertyName("typeValue")]
        public string TypeValue { get; set; }

        [JsonPropertyName("productTypes")]
        public List<ProductTypesOutputModel> ProductTypes { get; set; } = new();
    }

    public class ProductTypesOutputModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("TenantId")]
        public int TenantId { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("productTypeId")]
        public int ProductTypeId { get; set; }

        [JsonPropertyName("productTypeValue")]
        public string ProductTypeValue { get; set; }
    }

    public class CollectionColorOptionsOutputModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("TenantId")]
        public int TenantId { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("collectionId")]
        public Guid CollectionId { get; set; }

        [JsonPropertyName("colorOptionId")]
        public Guid ColorOptionId { get; set; }

        [JsonPropertyName("colorOption")]
        public CollectionColorOptionOutputModel ColorOption { get; set; } = new();
    }

    public class CollectionColorOptionOutputModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("TenantId")]
        public int TenantId { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("productTypes")]
        public List<ColorOptionProductTypesOutputModel> ProductTypes { get; set; } = new();

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("colorId")]
        public int ColorId { get; set; }

        [JsonPropertyName("typeId")]
        public int TypeId { get; set; }

        [JsonPropertyName("materialId")]
        public Guid MaterialId { get; set; }

        [JsonPropertyName("rolls")]
        public List<ColorOptionRollOutputModel> Rolls { get; set; } = new();

        [JsonPropertyName("isApproved")]
        public bool? ColorOptionIsApproved { get; set; }

        [JsonPropertyName("isRejected")]
        public bool? ColorOptionIsRejected { get; set; }

        [JsonPropertyName("approvedOn")]
        public DateTime? ApprovedOn { get; set; }

        [JsonPropertyName("approvedBy")]
        public string ApprovedBy { get; set; }

    }

    public class ColorOptionProductTypesOutputModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("TenantId")]
        public int TenantId { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("productTypeId")]
        public int ProductTypeId { get; set; }

        [JsonPropertyName("productTypeValue")]
        public string ProductTypeValue { get; set; }

        [JsonPropertyName("colorOptionTypeId")]
        public int ColorOptionTypeId { get; set; }
    }

    public class ColorOptionRollOutputModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("TenantId")]
        public int TenantId { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("colorOptionId")]
        public Guid ColorOptionId { get; set; }

        [JsonPropertyName("rollId")]
        public Guid RollId { get; set; }
    }

    public class CollectionSizingOptionOutputModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("TenantId")]
        public int TenantId { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("collectionId")]
        public Guid CollectionId { get; set; }

        [JsonPropertyName("sizeId")]
        public int SizeId { get; set; }

        [JsonPropertyName("sizeValue")]
        public string SizeValue { get; set; }
    }

}


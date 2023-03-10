using System;
using System.Text.Json.Serialization;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.AssignedTo.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.DesignStatuses.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Drops.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Factories.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.MarketingTypes.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.PricePoints.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.ProductSizes.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Seasons.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.ShippingTypes.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Statuses.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.Model;
using CollectionStatusModel = SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Statuses.Model.CollectionStatusModel;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Dto
{
	public class CollectionDto
	{
		public CollectionDto()
		{
            Season = new();
            PricePoint = new();
            Factory = new();
            ShippingType = new();
            MarketingType = new();
            DesignStatus = new();
            AssignedTo = new();
            Status = new();
            Products = new();
            ProductTypes = new();
            Influencers = new();
            ColorOptions = new();
            Sizes = new();
        }

        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("tenantId")]
        public Guid? TenantId { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }


        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("availability")]
        public bool Availability { get; set; }

        [JsonPropertyName("isPublished")]
        public bool IsPublished { get; set; }

        [JsonPropertyName("year")]
        public int Year { get; set; }

        [JsonPropertyName("collectionDevelopmentStartDate")]
        public DateTime CollectionDevelopmentStartDate { get; set; }

        [JsonPropertyName("provisionalLaunchDate")]
        public DateTime ProvisionalLaunchDate { get; set; }


        [JsonPropertyName("season")]
        public SeasonModel Season { get; set; }

        [JsonPropertyName("pricePoint")]
        public PricePointModel PricePoint { get; set; }

        [JsonPropertyName("factory")]
        public FactoryModel Factory { get; set; }

        [JsonPropertyName("shippingType")]
        public ShippingTypeModel ShippingType { get; set; }

        [JsonPropertyName("marketingType")]
        public MarketingTypeModel MarketingType { get; set; }

        [JsonPropertyName("designStatus")]
        public CollectionDesignStatusModel DesignStatus { get; set; }

        [JsonPropertyName("assignedTo")]
        public AssignedToModel? AssignedTo { get; set; }

        [JsonPropertyName("status")]
        public CollectionStatusModel Status { get; set; }


        [JsonPropertyName("products")]
        public List<ProductModel> Products { get; set; }

        [JsonPropertyName("productTypes")]
        public List<CollectionProductTypeDto> ProductTypes { get; set; }

        [JsonPropertyName("influencers")]
        public List<CollectionInfluencerDto> Influencers { get; set; }

        [JsonPropertyName("colorOptions")]
        public List<ColorOptionDto> ColorOptions { get; set; }

        [JsonPropertyName("sizes")]
        public List<CollectionSizeDto> Sizes { get; set; }

        [JsonPropertyName("creationTime")]
        public DateTime CreationTime { get; set; }


        // UI Model

        [JsonPropertyName("influencerNames")]
        public string InfluencerNames { get; set; }

        [JsonPropertyName("statusHexCode")]
        public string StatusHexCode { get; set; }

        [JsonPropertyName("parentProductsCount")]
        public int ParentProductsCount { get; set; }

        [JsonPropertyName("childProductsCount")]
        public int ChildProductsCount { get; set; }

    }
}


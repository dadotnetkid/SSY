using System;
using System.Text.Json.Serialization;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.ColorOptions.Model;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Model
{
    public class UpdateCollectionInputModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; } = 1;

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = true;

        // Overview

        [JsonPropertyName("influencerIds")]
        public List<Guid> InfluencerIds { get; set; } = new();

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

        [JsonPropertyName("materialProductTypeIds")]
        public List<UpdateMaterialProductTypes> MaterialProductTypeIds { get; set; } = new();


        // Collection Material Plan

        [JsonPropertyName("colorOptions")]
        public List<CreateColorOptionModel> ColorOptions { get; set; } = new();

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

        [JsonPropertyName("sizingOptionIds")]
        public List<int> SizingOptionIds { get; set; } = new();

        [JsonPropertyName("isPublished")]
        public bool IsPublished { get; set; } = false;
    }

    public class UpdateMaterialProductTypes
    {
        [JsonPropertyName("typeId")]
        public int TypeId { get; set; }

        [JsonPropertyName("productTypeIds")]
        public List<int> ProductTypeIds { get; set; } = new();
    }

}


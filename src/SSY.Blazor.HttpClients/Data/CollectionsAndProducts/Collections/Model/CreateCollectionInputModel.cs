using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.ColorOptions.Model;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Model
{ 
    public class CreateCollectionInputModel
	{
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; } = 1;

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = true;

        // Overview

        [JsonPropertyName("influencerIds")]
        public List<Guid> InfluencerIds { get; set; }

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

        [JsonPropertyName("statusId")]
        public int StatusId { get; set; }

        [JsonPropertyName("materialProductTypeIds")]
        public List<MaterialProductTypes> MaterialProductTypeIds { get; set; }


        // Collection Material Plan

        [JsonPropertyName("colorOptions")]
        public List<CreateColorOptionModel> ColorOptions { get; set; }

        [JsonPropertyName("isPublished")]
        public bool IsPublished { get; set; } = false;
    }

    public class MaterialProductTypes
    {
        [JsonPropertyName("typeId")]
        public int TypeId { get; set; }

        [JsonPropertyName("productTypeIds")]
        public List<int> ProductTypeIds { get; set; }
    }
}


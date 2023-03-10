using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Dto
{
	public class CreateCollectionDto
	{
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

        [JsonPropertyName("designStatusId")]
        public int DesignStatusId { get; set; }

        [JsonPropertyName("statusId")]
        public int StatusId { get; set; }


        [JsonPropertyName("productTypes")]
        public List<CreateCollectionProductTypeDto> ProductTypes { get; set; } = new();

        [JsonPropertyName("influencers")]
        public List<CreateCollectionInfluencerDto> Influencers { get; set; } = new();


        [JsonPropertyName("colorOptions")]
        public List<CreateColorOptionDto> ColorOptions { get; set; } = new();
    }
}


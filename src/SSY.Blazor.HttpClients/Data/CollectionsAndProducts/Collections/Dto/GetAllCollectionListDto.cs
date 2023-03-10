using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Dto
{
    public class GetAllCollectionListDto
    {
        [JsonPropertyName("totalCount")]
        public int TotalCount { get; set; }

        [JsonPropertyName("items")]
        public List<CollectionListDto> Items { get; set; }
    }

    public class CollectionListDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("influencerNames")]
        public string InfluencerNames { get; set; }

        [JsonPropertyName("influencerIds")]
        public List<Guid> InfluencerIds { get; set; } = new();

        [JsonPropertyName("designStatusValue")]
        public string DesignStatusValue { get; set; }

        [JsonPropertyName("parentProductCount")]
        public int ParentProductCount { get; set; }

        [JsonPropertyName("childProductCount")]
        public int ChildProductCount { get; set; }

        [JsonPropertyName("statusValue")]
        public string StatusValue { get; set; }

        [JsonPropertyName("statusHexCode")]
        public string StatusHexCode { get; set; }

        [JsonPropertyName("developmentStartDate")]
        public DateTime DevelopmentStartDate { get; set; }

        [JsonPropertyName("provisionalLaunchDate")]
        public DateTime ProvisionalLaunchDate { get; set; }

        [JsonPropertyName("availability")]
        public bool Availability { get; set; }

        [JsonPropertyName("colorOptions")]
        public List<CollectionColorOptionDto> ColorOptions { get; set; } = new();

        // UI

        [JsonPropertyName("collectionForecastQuantity")]
        public double CollectionForecastQuantity { get; set; }

        [JsonPropertyName("collectionForecastRevenue")]
        public double CollectionForecastRevenue { get; set; }


    }

    public class CollectionColorOptionDto
    {
        [JsonPropertyName("colorOptionId")]
        public Guid ColorOptionId { get; set; }

        [JsonPropertyName("collectionId")]
        public Guid CollectionId { get; set; }

        [JsonPropertyName("materialId")]
        public Guid MaterialId { get; set; }

        [JsonPropertyName("fabrics")]
        public List<ColorOptionFabricDto> Fabrics { get; set; } = new();
    }
}


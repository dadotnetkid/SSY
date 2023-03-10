using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.Dto
{
    public class GetAllProductListDto
    {
        [JsonPropertyName("totalCount")]
        public int TotalCount { get; set; }

        [JsonPropertyName("items")]
        public List<ProductListDto> Items { get; set; }
    }

    public class ProductListDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("designStatusValue")]
        public string DesignStatusValue { get; set; }

        [JsonPropertyName("influencerNames")]
        public string InfluencerNames { get; set; }

        [JsonPropertyName("collectioName")]
        public string CollectioName { get; set; }

        [JsonPropertyName("sku")]
        public string Sku { get; set; }

        [JsonPropertyName("creationTime")]
        public DateTime CreationTime { get; set; }
    }
}


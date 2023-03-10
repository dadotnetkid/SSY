using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.FirstDesignDrafts.Model
{
    public class CreateFirstDesignDetailModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; }
        [JsonPropertyName("imageUrls")]
        public List<ImageFiles> ImageUrls { get; set; } = new();
        [JsonPropertyName("orderNumber")]
        public int OrderNumber { get; set; }

    }
    public class ImageFiles
    {
        public string Value { get; set; }

        public string Extension { get; set; }

    }
}
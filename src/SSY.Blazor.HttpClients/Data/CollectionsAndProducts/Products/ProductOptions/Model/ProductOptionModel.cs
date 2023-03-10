using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.ProductOptions.Model
{
    public class ProductOptionModel
    {
        [JsonPropertyName("productId")]
        public Guid ProductId { get; set; }

        [JsonPropertyName("optionId")]
        public int OptionId { get; set; }

        [JsonPropertyName("materialId")]
        public Guid? MaterialId { get; set; }

        [JsonPropertyName("materialName")]
        public string MaterialName { get; set; }

        [JsonPropertyName("rollIds")]
        public string RollIds { get; set; }

        [JsonPropertyName("rollNames")]
        public string RollNames { get; set; }

        [JsonPropertyName("consumption")]
        public double? Consumption { get; set; } = 0;

        [JsonPropertyName("unitOfMeasurementId")]
        public int? UnitOfMeasurementId { get; set; }
    }
}


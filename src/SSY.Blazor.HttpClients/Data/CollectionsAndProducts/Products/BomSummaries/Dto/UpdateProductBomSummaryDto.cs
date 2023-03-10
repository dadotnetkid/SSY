using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.BomSummaries.Dto
{
    public class UpdateProductBomSummaryDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("consumption")]
        public double Consumption { get; set; }

        [JsonPropertyName("notes")]
        public string Notes { get; set; }
    }
}


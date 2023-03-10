using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.LaunchCategories.Dtos
{
    public class GetLaunchCategoryOutputDto
    {
        [JsonPropertyName("result")]
        public LaunchCategoryDto Result { get; set; } = new();
    }
}


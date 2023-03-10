using SSY.Blazor.HttpClients.Data;
using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.Model
{
    public class GetProductOutputModel
    {
        [JsonPropertyName("result")]
        public ProductModel Result { get; set; } = new();

        [JsonPropertyName("error")]
        public ErrorMessageModel ErrorMessage { get; set; }
    }
}


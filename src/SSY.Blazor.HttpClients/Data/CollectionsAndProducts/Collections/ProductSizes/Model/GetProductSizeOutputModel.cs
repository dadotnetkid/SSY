using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.ProductSizes.Model
{
	public class GetProductSizeOutputModel
	{
        [JsonPropertyName("result")]
        public ProductSizeModel Result { get; set; } = new();
    }
}


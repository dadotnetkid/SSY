using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Product.Types.Model
{
    public class GetProductTypeOutputModel
    {
        [JsonPropertyName("result")]
        public ProductTypeModel Result { get; set; }
    }
}


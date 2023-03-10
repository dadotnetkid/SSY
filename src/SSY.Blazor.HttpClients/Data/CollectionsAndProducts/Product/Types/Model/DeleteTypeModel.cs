using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Product.Types.Model
{
    public class DeleteProductTypeModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}


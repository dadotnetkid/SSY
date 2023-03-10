using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.ShippingTypes.Model
{
    public class ShippingTypeListModel
    {
        [JsonPropertyName("shippingTypes")]
        public List<ShippingTypeModel> ShippingTypes { get; set; } = new();
    }
}


using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.ShippingTypes.Model
{
    public class GetShippingTypeOutputModel
    {
        [JsonPropertyName("result")]
        public ShippingTypeModel Result { get; set; } = new();
    }
}


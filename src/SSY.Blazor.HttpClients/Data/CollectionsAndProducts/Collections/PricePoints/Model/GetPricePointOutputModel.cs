using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.PricePoints.Model
{
	public class GetPricePointOutputModel
	{
        [JsonPropertyName("result")]
        public PricePointModel Result { get; set; } = new();
    }
}


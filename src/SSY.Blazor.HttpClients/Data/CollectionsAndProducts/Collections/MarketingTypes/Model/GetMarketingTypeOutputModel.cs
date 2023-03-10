using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.MarketingTypes.Model;

public class GetMarketingTypeOutputModel
{
    [JsonPropertyName("result")]
    public MarketingTypeModel Result { get; set; } = new();
}

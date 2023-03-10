using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.MarketingTypes.Model;

public class MarketingTypeListModel
{
    [JsonPropertyName("marketingTypes")]
    public List<MarketingTypeModel> MarketingTypes { get; set; } = new();
}


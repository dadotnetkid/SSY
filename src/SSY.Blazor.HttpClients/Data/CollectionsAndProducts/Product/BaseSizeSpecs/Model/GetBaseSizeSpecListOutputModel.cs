using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Product.BaseSizeSpecs.Model;

public class GetBaseSizeSpecListOutputModel
{
    [JsonPropertyName("result")]
    public BaseSizeSpecListModel Result { get; set; }
}
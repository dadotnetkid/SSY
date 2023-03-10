using System;
using System.Text.Json.Serialization;

namespace SSY.Web.Blazor.Core.Data.CollectionsAndProducts.Collections.Statuses.Model;

public class GetCollectionStatusOutputModel
{
    [JsonPropertyName("result")]
    public CollectionStatusModel Result { get; set; } = new();
}


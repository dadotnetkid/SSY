using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.DesignStatuses.Model;

public class GetCollectionDesignStatusOutputModel
{
    [JsonPropertyName("result")]
    public CollectionDesignStatusModel Result { get; set; } = new();
}


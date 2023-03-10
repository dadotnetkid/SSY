using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.AssignedTo.Model;

public class CreateAssignedToModel
{
    [JsonPropertyName("tenantId")]
    public int TenantId { get; set; } = 1;

    [JsonPropertyName("isActive")]
    public bool IsActive { get; set; } = true;

    [JsonPropertyName("collectionId")]
    public Guid CollectionId { get; set; }

    [JsonPropertyName("designerId")]
    public Guid DesignerId { get; set; }

    [JsonPropertyName("threeDDesignerId")]
    public Guid ThreeDDesignerId { get; set; }

    [JsonPropertyName("sSYMerchandiserId")]
    public Guid SSYMerchandiserId { get; set; }

    [JsonPropertyName("oEMMerchandiserId")]
    public Guid OEMMerchandiserId { get; set; }

    [JsonPropertyName("oEMPatternMakerId")]
    public Guid OEMPatternMakerId { get; set; }
}


using System;
using System.Text.Json.Serialization;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Model;

namespace SSY.Blazor.HttpClients.Data.Inventory.Reservations.Model;

public class SubMaterialReservationModel
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("tenantId")]
    public int TenantId { get; set; }

    [JsonPropertyName("isActive")]
    public bool IsActive { get; set; }

    [JsonPropertyName("collectionId")]
    public Guid CollectionId { get; set; }

    [JsonPropertyName("reservationId")]
    public Guid ReservationId { get; set; }

    [JsonPropertyName("subMaterialId")]
    public Guid SubMaterialId { get; set; }

    [JsonPropertyName("reservationCount")]
    public double ReservationCount { get; set; }

    [JsonPropertyName("reservationDate")]
    public DateTime ReservationDate { get; set; }

    [JsonPropertyName("collectionName")]
    public string CollectionName { get; set; }

    [JsonPropertyName("influencersNames")]
    public string InfluencersNames { get; set; }

    [JsonPropertyName("collectionInfluencers")]
    public List<InfluencersOutputModel> CollectionInfluencers { get; set; } = new();

    [JsonPropertyName("buildingOrWarehouse")]
    public string BuildingOrWarehouse { get; set; }


}



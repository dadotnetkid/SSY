using System;
using System.Text.Json.Serialization;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Model;

namespace SSY.Blazor.HttpClients.Data.Inventory.Reservations.Model;

public class RollReservationModel
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

    [JsonPropertyName("rollId")]
    public Guid RollId { get; set; }

    [JsonPropertyName("rollNumber")]
    public string RollNumber { get; set; }

    [JsonPropertyName("reservationCount")]
    public double ReservationCount { get; set; }

    [JsonPropertyName("reservationDate")]
    public DateTime ReservationDate { get; set; }

    [JsonPropertyName("collectionName")]
    public string CollectionName { get; set; }

    [JsonPropertyName("influencerName")]
    public string InfluencerNames { get; set; }

    [JsonPropertyName("rollBuildingOrWarehouse")]
    public string RollBuildingOrWarehouse { get; set; }

    [JsonPropertyName("rollTRackNumber")]
    public string RollTRackNumber { get; set; }

    [JsonPropertyName("rollRack")]
    public string RollRack { get; set; }

    [JsonPropertyName("collectionInfluencers")]
    public List<InfluencersOutputModel> CollectionInfluencers { get; set; } = new();


}



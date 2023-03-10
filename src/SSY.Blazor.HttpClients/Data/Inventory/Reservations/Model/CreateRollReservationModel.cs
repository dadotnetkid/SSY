using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Reservations.Model;
public class CreateRollReservationModel
{
    [JsonPropertyName("tenantId")]
    public int TenantId { get; set; } = 1;

    [JsonPropertyName("isActive")]
    public bool IsActive { get; set; } = true;

    [Required]
    [JsonPropertyName("materialId")]
    public Guid MaterialId { get; set; }

    [Required]
    [JsonPropertyName("collectionId")]
    public string CollectionId { get; set; }

    [JsonPropertyName("collectionName")]
    public string CollectionName { get; set; }

    [JsonPropertyName("influencerNames")]
    public string InfluencerNames { get; set; }

    [JsonPropertyName("rollReservations")]
    public List<RollReservation> RollReservations { get; set; } = new();
}

public class RollReservation
{
    [Required]
    [JsonPropertyName("rollId")]
    public Guid RollId { get; set; }

    [Required]
    [JsonPropertyName("date")]
    public DateTime Date { get; set; } = DateTime.Now;

    [Required]
    [JsonPropertyName("reservedCount")]
    public double ReservedCount { get; set; }

    [JsonPropertyName("rollName")]
    public string RollNumber { get; set; }

    [JsonPropertyName("currentCount")]
    public double CurrentCount { get; set; }
}



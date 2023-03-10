using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Reservations.Model;
public class CreateSubMaterialReservationModel
{

    [JsonPropertyName("tenantId")]
    public int TenantId { get; set; } = 1;

    [JsonPropertyName("isActive")]
    public bool IsActive { get; set; } = true;


    [Required]
    [JsonPropertyName("subMaterialId")]
    public Guid SubMaterialId { get; set; }

    [Required]
    [JsonPropertyName("collectionId")]
    public string CollectionId { get; set; }

    [JsonPropertyName("collectionName")]
    public string CollectionName { get; set; }

    [JsonPropertyName("influencerNames")]
    public string InfluencerNames { get; set; }

    [Required]
    [JsonPropertyName("date")]
    public DateTime Date { get; set; } = DateTime.Now;

    [JsonPropertyName("reservedCount")]
    public double? ReservedCount { get; set; }

    [JsonPropertyName("currentCount")]
    public double? CurrentCount { get; set; }

    [JsonPropertyName("addedBy")]
    public string AddedBy { get; set; }
}



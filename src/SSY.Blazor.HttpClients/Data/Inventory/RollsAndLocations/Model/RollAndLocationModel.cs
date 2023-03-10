using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SSY.Blazor.HttpClients.Data.Inventory.Adjustments.Model;
using SSY.Blazor.HttpClients.Data.Inventory.Reservations.Model;
using SSY.Blazor.HttpClients.Data.Inventory.RollAdjustments.Model;

namespace SSY.Blazor.HttpClients.Data.Inventory.RollsAndLocations.Model
{
    public class RollAndLocationModel
    {
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; } = 1;

        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = true;

        [JsonPropertyName("materialId")]
        public Guid MaterialId { get; set; }

        [JsonPropertyName("qR")]
        public string? QR { get; set; }

        [JsonPropertyName("rollNumber")]
        [Required(ErrorMessage = "This field is required.")]
        public string RollNumber { get; set; }

        [JsonPropertyName("dateAcquired")]
        [Required(ErrorMessage = "This field is required.")]
        public DateTime DateAcquired { get; set; } = DateTime.Now;

        [JsonPropertyName("shelfLife")]
        public double? ShelfLife { get; set; }

        [JsonPropertyName("totalCount")]
        public double? TotalCount { get; set; }

        [JsonPropertyName("reserveCount")]
        public double? ReserveCount { get; set; }

        [JsonPropertyName("availableCount")]
        public double? AvailableCount { get; set; }

        [JsonPropertyName("onHandCount")]
        public double? OnHandCount { get; set; }

        [JsonPropertyName("incomingCount")]
        public double? IncomingCount { get; set; }

        [JsonPropertyName("consumeBeforeDate")]
        public DateTime ConsumeBeforeDate { get; set; }

        [JsonPropertyName("buildingOrWarehouse")]
        [Required(ErrorMessage = "This field is required.")]
        public string BuildingOrWarehouse { get; set; }

        [JsonPropertyName("tRackNumber")]
        [Required(ErrorMessage = "This field is required.")]
        public string TRackNumber { get; set; }

        [JsonPropertyName("rack")]
        [Required(ErrorMessage = "This field is required.")]
        public string Rack { get; set; }

        [JsonPropertyName("shadingId")]
        public int? ShadingId { get; set; }

        [JsonPropertyName("shadingValue")]
        public string ShadingValue { get; set; }

        [JsonPropertyName("isDisposal")]
        public bool? IsDisposal { get; set; } = false;

        [JsonPropertyName("disposalDate")]
        public DateTime? DisposalDate { get; set; }

        [JsonPropertyName("shadingLabel")]
        public string ShadingLabel { get; set; }

        public int Action { get; set; }

        /// <summary>
        /// Purchase Detail Number
        /// </summary>
        [JsonPropertyName("poNumber")]
        public string? PONumber { get; set; }

        /// <summary>
        /// Amount of shipped roll
        /// </summary>
        [JsonPropertyName("shippedCount")]
        public double? ShippedCount { get; set; }

        /// <summary>
        /// Amount of received roll
        /// </summary>
        [JsonPropertyName("receivedCount")]
        public double? ReceivedCount { get; set; }

        [JsonPropertyName("rollAdjustments")]
        public List<RollAdjustmentModel> RollAdjustments { get; set; } = new();

        [JsonPropertyName("rollReservations")]
        public List<RollReservationModel> RollReservations { get; set; } = new();

        public string Influencers { get; set; }

        public string Ordinal { get; set; }

        [JsonPropertyName("colorOptionFabricRollId")]
        public Guid ColorOptionFabricRollId { get; set; }
    }
}



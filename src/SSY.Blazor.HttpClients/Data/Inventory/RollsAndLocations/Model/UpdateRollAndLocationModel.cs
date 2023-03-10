using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.RollsAndLocations.Model
{
    public class UpdateRollAndLocationModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        /// <summary>
        /// Material ForeignKey
        /// </summary>
        [Required]
        [JsonPropertyName("materialId")]
        public Guid MaterialId { get; set; }

        /// <summary>
        /// Quick Response Code
        /// </summary>
        [JsonPropertyName("qr")]
        public string? QR { get; set; }

        #region MassUploadForm

        /// <summary>
        /// Roll Number
        /// </summary>
        [Required]
        [JsonPropertyName("rollNumber")]
        public string RollNumber { get; set; }

        /// <summary>
        /// Date Aquired
        /// </summary>
        [Required]
        [JsonPropertyName("dateAcquired")]
        public DateTime DateAcquired { get; set; }

        /// <summary>
        /// ShelfLife
        /// </summary>
        [JsonPropertyName("shelfLife")]
        public double? ShelfLife { get; set; }

        [JsonPropertyName("totalCount")]
        public double? TotalCount { get; set; }

        /// <summary>
        /// Consume Before Date
        /// </summary>
        [Required]
        [JsonPropertyName("consumeBeforeDate")]
        public DateTime ConsumeBeforeDate { get; set; }

        /// <summary>
        /// Shading ForeignKey
        /// </summary>
        [JsonPropertyName("shadingId")]
        public int? ShadingId { get; set; }

        /// <summary>
        /// Building or Warehouse
        /// </summary>
        [Required]
        [JsonPropertyName("buildingOrWarehouse")]
        public string BuildingOrWarehouse { get; set; }

        /// <summary>
        /// T-Rack Number
        /// </summary>
        [JsonPropertyName("tRackNumber")]
        public string? TRackNumber { get; set; }

        /// <summary>
        /// Rack
        /// </summary>
        [Required]
        [JsonPropertyName("rack")]
        public string Rack { get; set; }

        [JsonPropertyName("isDisposal")]
        public bool? IsDisposal { get; set; } = false;

        [JsonPropertyName("availableCount")]
        public double? AvailableCount { get; set; }

        [JsonPropertyName("disposalDate")]
        public DateTime? DisposalDate { get; set; }

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

        [JsonPropertyName("incomingCount")]
        public double? IncomingCount { get; set; }

        [JsonPropertyName("onHandCount")]
        public double? OnHandCount { get; set; }

        #endregion
    }

}

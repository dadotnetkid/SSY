﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Reservations.Model
{
    public class ReservationModel
    {
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [Required]
        [JsonPropertyName("materialId")]
        public Guid MaterialId { get; set; }

        [Required]
        [JsonPropertyName("categoryId")]
        public int CategoryId { get; set; }

        [Required]
        [JsonPropertyName("typeId")]
        public int TypeId { get; set; }

        [Required]
        [JsonPropertyName("influencerIds")]
        public string InfluencerIds { get; set; }

        [JsonPropertyName("influencersName")]
        public string InfluencersName { get; set; }

        [Required]
        [JsonPropertyName("collectionId")]
        public string CollectionId { get; set; }

        [JsonPropertyName("collectionName")]
        public string CollectionName { get; set; }

        [Required]
        [JsonPropertyName("reservedCount")]
        public double ReservedCount { get; set; }

        [Required]
        [JsonPropertyName("reservedDate")]
        public DateTime ReservedDate { get; set; }

        [JsonPropertyName("selectedRolls")]
        public List<Guid> SelectedRolls { get; set; } = new();
    }
}


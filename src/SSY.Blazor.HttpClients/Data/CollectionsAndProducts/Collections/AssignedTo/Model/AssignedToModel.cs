using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.AssignedTo.Model
{
    public class AssignedToModel
    {
        [JsonPropertyName("tenantId")]
        public Guid? TenantId { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = true;

        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("collectionId")]
        public Guid CollectionId { get; set; }

        [JsonPropertyName("designerId")]
        public Guid? DesignerId { get; set; }

        [JsonPropertyName("threeDDesignerId")]
        public Guid? ThreeDDesignerId { get; set; }

        [JsonPropertyName("ssyMerchandiserId")]
        public Guid? SSYMerchandiserId { get; set; }

        [JsonPropertyName("oemMerchandiserId")]
        public Guid? OEMMerchandiserId { get; set; }

        [JsonPropertyName("oemPatternMakerId")]
        public Guid? OEMPatternMakerId { get; set; }

        public string DesignerName { get; set; }

        public string ThreeDDesignerName { get; set; }

        public string SSYMerchandiserName { get; set; }

        public string OEMMerchandiserName { get; set; }

        public string OEMPatternMakerName { get; set; }

    }

}

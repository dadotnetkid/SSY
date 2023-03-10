using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Services.IST.Models
{
    public class ExcessMarkApprovedModel
    {
        [JsonPropertyName("cmd")]
        public string CMD { get; set; }

        [JsonPropertyName("pAccessKey")]
        public string PAccessKey { get; set; }

        [JsonPropertyName("offerNo")]
        public string OfferNo { get; set; }

        [Required]
        [JsonPropertyName("MatNo")]
        public string MatNo { get; set; }

        [Required]
        [JsonPropertyName("isApproved")]
        public bool IsApproved { get; set; }

        [Required]
        [JsonPropertyName("approvedBy")]
        public string ApprovedBy { get; set; }
    }
}


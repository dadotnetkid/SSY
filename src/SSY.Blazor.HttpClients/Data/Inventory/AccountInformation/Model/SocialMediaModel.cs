using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.AccountInformation.Model
{
    public class SocialMediaModel
    {
        // [JsonPropertyName("tenantId")]
        // public int TenantId { get; set; } = 1;

        // [JsonPropertyName("id")]
        // public Guid Id { get; set; }

        // [JsonPropertyName("isActive")]
        // public bool IsActive { get; set; } = true;

        [JsonPropertyName("instagram")]
        [Required(ErrorMessage = "The Instagram is Required")]
        public string Instagram { get; set; }

        [JsonPropertyName("youTube")]
        [Required(ErrorMessage = "The YouTube is Required")]

        public string Youtube { get; set; }

        [JsonPropertyName("tikTok")]
        [Required(ErrorMessage = "The TikTok is Required")]

        public string Tiktok { get; set; }

        [JsonPropertyName("blog")]
        [Required(ErrorMessage = "The Blog is Required")]

        public string Blog { get; set; }

        [JsonPropertyName("twitter")]
        [Required(ErrorMessage = "The Twitter is Required")]

        public string Twitter { get; set; }

        [JsonPropertyName("faceBook")]
        [Required(ErrorMessage = "The Facebook is Required")]

        public string Facebook { get; set; }
    }


}



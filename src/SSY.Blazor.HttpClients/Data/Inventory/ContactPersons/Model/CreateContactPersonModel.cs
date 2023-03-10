using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.ContactPersons.Model
{
    public class CreateContactPersonModel
    {

        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; } = 1;

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = true;

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(200, ErrorMessage = "This field is too long.")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(200, ErrorMessage = "This field is too long.")]
        [JsonPropertyName("position")]
        public string Position { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(200, ErrorMessage = "This field is too long.")]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [StringLength(200, ErrorMessage = "This field is too long.")]
        [JsonPropertyName("telephone")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(200, ErrorMessage = "This field is too long.")]
        [JsonPropertyName("mobileNumber")]
        public string MobileNumber { get; set; }
    }
}


using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.ContactPersons.Model
{
    public class ContactPersonModel
    {
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("companyId")]
        public int CompanyId { get; set; }

        [JsonPropertyName("contactPersonId")]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(200, ErrorMessage = "This field is too long.")]
        [JsonPropertyName("contactPersonName")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(200, ErrorMessage = "This field is too long.")]
        [JsonPropertyName("contactPersonPosition")]
        public string Position { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(200, ErrorMessage = "This field is too long.")]
        [JsonPropertyName("contactPersonEmail")]
        public string Email { get; set; }

        [StringLength(200, ErrorMessage = "This field is too long.")]
        [JsonPropertyName("contactPersonTelephone")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(200, ErrorMessage = "This field is too long.")]
        [JsonPropertyName("contactPersonMobileNumber")]
        public string MobileNumber { get; set; }
    }
}


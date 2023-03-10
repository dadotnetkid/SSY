using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Companies.ContactPersons.Model
{
    public class ContactPersonsModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("companyId")]
        public int CompanyId { get; set; }

        [JsonPropertyName("contactPersonId")]
        public int ContactPersonId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [JsonPropertyName("contactPersonName")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [JsonPropertyName("contactPersonPosition")]
        public string Position { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Required(ErrorMessage = "This field is required")]
        [JsonPropertyName("contactPersonEmail")]
        public string Email { get; set; }

        [JsonPropertyName("contactPersonTelephone")]
        public string Telephone { get; set; }

        [JsonPropertyName("contactPersonMobileNumber")]
        public string MobileNumber { get; set; }

        public bool IsDeleted { get; set; }
    }
}


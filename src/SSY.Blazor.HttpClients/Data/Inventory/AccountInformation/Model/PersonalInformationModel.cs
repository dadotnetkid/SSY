using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.AccountInformation.Model
{
    public class PersonalInformationModel
    {
        // [JsonPropertyName("tenantId")]
        // public int TenantId { get; set; } = 1;

        // [JsonPropertyName("id")]
        // public Guid Id { get; set; }

        // [JsonPropertyName("isActive")]
        // public bool IsActive { get; set; } = true;

        [JsonPropertyName("firstName")]
        [Required(ErrorMessage = "This First Name is Required")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        [Required(ErrorMessage = "This Last Name is Required")]
        public string LastName { get; set; }

        [JsonPropertyName("completeAddress")]
        [Required(ErrorMessage = "This Address is Required")]
        public string CompleteAddress { get; set; }

        [JsonPropertyName("city")]
        [Required(ErrorMessage = "This City is Required")]
        public string City { get; set; }

        [JsonPropertyName("state")]
        [Required(ErrorMessage = "This State is Required")]
        public string State { get; set; }

        [JsonPropertyName("country")]
        [Required(ErrorMessage = "This Country is Required")]
        public string Country { get; set; }

        [JsonPropertyName("m5vm8")]
        [Required(ErrorMessage = "This M5VM8 is Required")]
        public string M5vm8 { get; set; }
    }


}



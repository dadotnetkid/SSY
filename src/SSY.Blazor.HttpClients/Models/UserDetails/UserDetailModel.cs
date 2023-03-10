using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Models.UserDetails
{
    public class UserDetailModel
    {
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("colorId")]
        public long? UserId { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("secondName")]
        public string SecondName { get; set; }

        [JsonPropertyName("emailAddress")]
        public string EmailAddress { get; set; }

        [JsonPropertyName("contactNumber")]
        public string ContactNumber { get; set; }

        [JsonPropertyName("position")]
        public string Position { get; set; }

        [JsonPropertyName("accessRights")]
        public string AccessRights { get; set; }

        [JsonPropertyName("companyId")]
        public int CompanyId { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("remarks")]
        public string Remarks { get; set; }
    }
}


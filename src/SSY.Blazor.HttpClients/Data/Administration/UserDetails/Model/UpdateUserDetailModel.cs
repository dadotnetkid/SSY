using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Administration.UserDetails.Model
{
    public class UpdateUserDetailModel
    {
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; } = 1;

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = true;

        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("userId")]
        public long? UserId { get; set; }
        [JsonPropertyName("userName")]
        public string UserName { get; set; }

        [JsonPropertyName("companyId")]
        public int? CompanyId { get; set; }
        [JsonPropertyName("companyLabel")]
        public string? CompanyLabel { get; set; }
        [JsonPropertyName("companyValue")]
        public string? CompanyValue { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("surname")]
        public string Surname { get; set; }

        [JsonPropertyName("fullName")]
        public string FullName { get; set; }

        [JsonPropertyName("emailAddress")]
        public string EmailAddress { get; set; }

        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("position")]
        public string Position { get; set; }

        [JsonPropertyName("roleNames")]
        public string RoleNames { get; set; }

        [JsonPropertyName("remarks")]
        public string Remarks { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("productQuantityForecast")]
        public double? ProductQuantityForecast { get; set; }

        [JsonPropertyName("collections")]
        public string Collections { get; set; }
    }
}


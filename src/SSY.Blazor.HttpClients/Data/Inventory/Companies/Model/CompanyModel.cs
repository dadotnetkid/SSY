using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SSY.Blazor.HttpClients.Data.Inventory.Companies.ContactPersons.Model;

namespace SSY.Blazor.HttpClients.Data.Inventory.Companies.Model
{
    public class CompanyModel
    {
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; } = 1;

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("shortCode")]
        public string ShortCode { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("website")]
        public string Website { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("address1")]
        public string Address1 { get; set; }

        [JsonPropertyName("address2")]
        public string Address2 { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("country")]
        public string Country { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("province")]
        public string Province { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("city")]
        public string City { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [JsonPropertyName("zipCode")]
        public string ZipCode { get; set; }

        [JsonPropertyName("bankName")]
        public string BankName { get; set; }

        [JsonPropertyName("accountNumber")]
        public string AccountNumber { get; set; }

        [JsonPropertyName("accountName")]
        public string AccountName { get; set; }

        [JsonPropertyName("swift")]
        public string Swift { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("companyTypeKeys")]
        public List<CompanyTypeKeysModel> CompanyTypeKeys { get; set; } = new();

        [JsonPropertyName("companyTypeIds")]
        public List<int> CompanyTypeIds { get; set; } = new();

        [JsonPropertyName("isExcessSupplier")]
        public bool IsExcessSupplier { get; set; }

        [JsonPropertyName("companyExcessReminderKeys")]
        public List<CompanyExcessReminderKeysModel> CompanyExcessReminderKeys { get; set; } = new();

        [JsonPropertyName("companyExcessReminderIds")]
        public List<int> CompanyExcessReminderIds { get; set; } = new();

        [JsonPropertyName("companyMaterialTypeKeys")]
        public List<CompanyMaterialTypeKeysModel> CompanyMaterialTypeKeys { get; set; } = new();

        [JsonPropertyName("materialTypeIds")]
        public List<int> MaterialTypeIds { get; set; } = new();

        [JsonPropertyName("contactPersons")]
        public List<ContactPersonsModel> ContactPersons { get; set; } = new();

        [JsonPropertyName("contactPersonNames")]
        public string ContactPersonNames { get; set; }

        [JsonPropertyName("contactPersonContactNumber")]
        public string ContactPersonContactNumber { get; set; }

    }
}


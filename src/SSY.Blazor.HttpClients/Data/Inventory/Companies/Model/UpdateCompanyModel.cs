using SSY.Blazor.HttpClients.Data.Inventory.Companies.ContactPersons.Model;
using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Companies.Model
{
    public class UpdateCompanyModel
    {
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; } = 1;

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = true;

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("shortCode")]
        public string ShortCode { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("website")]
        public string Website { get; set; }

        [JsonPropertyName("address1")]
        public string Address1 { get; set; }

        [JsonPropertyName("address2")]
        public string Address2 { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("province")]
        public string Province { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

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

        [JsonPropertyName("companyTypeIds")]
        public List<int> CompanyTypeIds { get; set; } = new();

        [JsonPropertyName("isExcessSupplier")]
        public bool IsExcessSupplier { get; set; }

        [JsonPropertyName("companyExcessReminderIds")]
        public List<int> CompanyExcessReminderIds { get; set; } = new();

        [JsonPropertyName("materialTypeIds")]
        public List<int> MaterialTypeIds { get; set; } = new();

        [JsonPropertyName("contactPersons")]
        public List<UpdateContactPersonsModel> ContactPersons { get; set; } = new();
    }
}


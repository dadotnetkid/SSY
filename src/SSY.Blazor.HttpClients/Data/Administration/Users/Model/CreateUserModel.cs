using System;
using System.Text.Json.Serialization;
namespace SSY.Blazor.HttpClients.Data.Administration.Users.Model
{
    public class CreateUserModel
    {

        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; } = 1;

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = true;

        [JsonPropertyName("dateOfInventory")]
        public DateTime DateOfInventory { get; set; }

        [JsonPropertyName("stockTaker")]
        public string StockTaker { get; set; }

        [JsonPropertyName("validator")]
        public string Validator { get; set; }

        [JsonPropertyName("swatchSent")]
        public DateTime? SwatchSent { get; set; } = null;

        [JsonPropertyName("swatchRecieved")]
        public DateTime? SwatchRecieved { get; set; } = null;

        [JsonPropertyName("confirmedSwatchRecieved")]
        public string ConfirmedSwatchRecieved { get; set; }
    }
}

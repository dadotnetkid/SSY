using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Inventory.Companies.Model
{
    public class GetCompanyOutputModel
    {
        [JsonPropertyName("result")]
        public CompanyModel Result { get; set; }
    }
}


using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.ApprovalStatuses.Model
{
    public class GetApprovalStatusOutputModel
    {
        [JsonPropertyName("result")]
        public ApprovalStatusModel Result { get; set; } = new();
    }
}


using System;
using System.Text.Json.Serialization;
namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Dto
{
	public class UpdateColorOptionFabricRollDto
	{
        [JsonPropertyName("tenantId")]
        public Guid? TenantId { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }


        [JsonPropertyName("colorOptionFabricId")]
        public Guid ColorOptionFabricId { get; set; }

        [JsonPropertyName("rollId")]
        public Guid RollId { get; set; }
    }
}


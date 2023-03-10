using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Models.Materials
{


    public class MiscellaneousData
    {
        [JsonPropertyName("result")]
        public MiscellaneousResults Result { get; set; }

    }
    public class MiscellaneousResults
    {
        [JsonPropertyName("totalCount")]
        public int TotalCount { get; set; }

        [JsonPropertyName("items")]
        public List<MiscellaneousModel> Items { get; set; }
    }
    public class MiscellaneousResult
    {
        [JsonPropertyName("result")]
        public MiscellaneousModel Result { get; set; }

    }

    public class MiscellaneousModel
    {
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; } = 1;

        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("careInstructionTypeId")]
        public int? CareInstructionTypeId { get; set; }
        public string? CareInstruction { get; set; }
    }


}



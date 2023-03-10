using System.Text.Json.Serialization;


namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Timelines
{
    public class TimelineModel
    {
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; } = 1;

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = true;

        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("collectionDevelopment")]
        public DateTime CollectionDevelopment { get; set; }

        [JsonPropertyName("designDraft")]
        public DateTime DesignDraft { get; set; }

        [JsonPropertyName("virtualFitting3d")]
        public string VirtualFitting3d { get; set; }

        [JsonPropertyName("fitSample")]
        public string FitSample { get; set; }

        [JsonPropertyName("photoSample")]
        public string PhotoSample { get; set; }

        [JsonPropertyName("launchReady")]
        public string LaunchReady { get; set; }


    }

}

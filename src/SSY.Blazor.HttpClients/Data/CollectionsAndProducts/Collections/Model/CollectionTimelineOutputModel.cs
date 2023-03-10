using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Model
{
    public class CollectionTimelineOutputModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }
        
        [JsonPropertyName("collectionTimelineListCount")]
        public int CollectionTimelineListCount { get; set; }

        [JsonPropertyName("collectionTimelineList")] 
        public List<CollectionTimelineListOutputModel> CollectionTimelineList { get; set; } = new();
      
    }
    public class CollectionTimelineListOutputModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("influencerName")]
        public string InfluencerName { get; set; }
        [JsonPropertyName("collectionName")]
        public string CollectionName { get; set; }
    }
}

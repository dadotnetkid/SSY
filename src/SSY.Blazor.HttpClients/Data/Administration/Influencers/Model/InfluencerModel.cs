using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Administration.Influencers.Model
{
    public class InfluencerModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }
        [JsonPropertyName("second_name")]
        public string SecondName { get; set; }
        [JsonPropertyName("full_name")]
        public string FullName { get; set; }
        [JsonPropertyName("gender")]
        public string Gender { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("collections")]
        public List<Collection> Collections { get; set; }

        [JsonPropertyName("size_info")]
        public SizeInfo SizeInfo { get; set; }

        [JsonPropertyName("is_admin")]
        public bool IsAdmin { get; set; }
        [JsonPropertyName("slug")]
        public string Slug { get; set; }
        [JsonPropertyName("authentication_token")]
        public string AuthenticationToken { get; set; }
        [JsonPropertyName("product_quantity_forecast")]
        public int ProductQuantityForecast { get; set; }
        [JsonPropertyName("revenue_release_date")]
        public DateTime? RevenueReleaseDate { get; set; }
    }

    public class Collection
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class SizeInfo
    {
        [JsonPropertyName("height")]
        public string Height { get; set; }
        [JsonPropertyName("pattern")]
        public string Pattern { get; set; }
    }
}


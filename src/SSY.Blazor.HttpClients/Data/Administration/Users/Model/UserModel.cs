using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Administration.Users.Model
{
    public class UserModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; } = 1;

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("full_name")]
        public string FullName { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("is_admin")]
        public bool IsAdmin { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("authentication_token")]
        public string AuthenticationToken { get; set; }

        [JsonPropertyName("size_info")]
        public SizeInfo SizeInfo { get; set; } = new();

        [JsonPropertyName("collections")]
        public List<Collections> Collections { get; set; } = new();


    }

    public class SizeInfo
    {

        [JsonPropertyName("height")]
        public string Height { get; set; }

        [JsonPropertyName("pattern")]
        public string Pattern { get; set; }

    }

    public class Collections
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }



}



using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.Administration.Users.Model
{
    public class LoginModel
    {
        public LoginModel()
        {
        }
        [Required(ErrorMessage = "The Email Address is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address format.")]
        [JsonPropertyName("email")]
        public string EmailAddress { get; set; }


        [Required]
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}

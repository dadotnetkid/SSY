using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.DesignBriefs
{
    public class DesignBriefModel
    {
        [JsonPropertyName("tenantId")]
        public int TenantId { get; set; } = 1;

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = true;

        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Required(ErrorMessage = "This field is required")]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("maximumProductsYouWouldLikeToSeeInYourCollection")]
        public string MaximumProductsYouWouldLikeToSeeInYourCollection { get; set; }

        [JsonPropertyName("threeSweatProductsYouWouldLikeToSeeInYourCollection")]
        public string ThreeSweatProductsYouWouldLikeToSeeInYourCollection { get; set; }
         [JsonPropertyName("describeYourActivewearStyle")]
        public string DescribeYourActivewearStyle { get; set; }

        [JsonPropertyName("favoriteProductsAvailable")]
        public string FavoriteProductsAvailable { get; set; }

        [JsonPropertyName("tellUsWhatYouLikeTheMostAboutTheProduct")]
        public string TellUsWhatYouLikeTheMostAboutTheProduct { get; set; }

        [JsonPropertyName("colorsWoulYouLikeToSeeInYourCollection")]
        public string ColorsWoulYouLikeToSeeInYourCollection { get; set; }
        
        [JsonPropertyName("rateTheFollowingColorStyles")]
        public string RateTheFollowingColorStyles { get; set; }

        [JsonPropertyName("twoMaxColorDirectionsYouWouldToSeeInYourCollection")]
        public string TwoMaxColorDirectionsYouWouldToSeeInYourCollection { get; set; }

        [JsonPropertyName("provideLinkOfYourFavoriteColorOrPrint")]
        public string ProvideLinkOfYourFavoriteColorOrPrint { get; set; }
        [JsonPropertyName("sportswearBrandsDoYouPrefer")]
        public string SportswearBrandsDoYouPrefer { get; set; }
        [JsonPropertyName("anythingYouWouldLikeUsToKnow")]
        public string AnythingYouWouldLikeUsToKnow { get; set; }
    }

}

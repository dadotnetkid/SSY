using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.ThreeDVirtualFitting.Model
{
    public class ThreeDVirtualFittingModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("isFrontImageApprove")]
        public bool IsFrontImageApprove { get; set; }

        [JsonPropertyName("frontImageUrl")]
        public string FrontImageUrl { get; set; }

        [JsonPropertyName("backImageUrl")]
        public string BackImageUrl { get; set; }

        [JsonPropertyName("isBackImageApprove")]
        public bool IsBackImageApprove { get; set; }

        [JsonPropertyName("leftSideImageUrl")]
        public string LeftSideImageUrl { get; set; }

        [JsonPropertyName("rightSideImageUrl")]
        public string RightSideImageUrl { get; set; }


    }
}
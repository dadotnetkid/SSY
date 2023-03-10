using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Calendar.Model
{
    public class CalendarModel
    {

        #region Collection

        [JsonPropertyName("collectionName")]
        public string CollectionName { get; set; }

        #endregion

        #region Statistic

        [JsonPropertyName("salesForeCastQuantity")]
        public double SalesForeCastQuantity { get; set; }

        [JsonPropertyName("actualSalesQuantity")]
        public double ActualSalesQuantity { get; set; }

        [JsonPropertyName("eligibleForReDropNewCollection")]
        public string EligibleForReDropNewCollection { get; set; }

        #endregion



        #region Target Vs Actual

        [JsonPropertyName("targetVsActual")]
        public string TargetVsActual { get; set; }

        #endregion

        #region Collection Development

        [JsonPropertyName("collectionDevelopment")]
        public DateTime CollectionDevelopment { get; set; }

        #endregion



        #region Design Draft

        [JsonPropertyName("productOnBoarded")]
        public DateTime ProductOnBoarded { get; set; }

        [JsonPropertyName("designDraftUploaded")]
        public DateTime DesignDraftUploaded { get; set; }

        [JsonPropertyName("designDraftRejectedByInfluencer")]
        public DateTime DesignDraftRejectedByInfluencer { get; set; }

        [JsonPropertyName("designDraftApprovedByInfluencer")]
        public DateTime DesignDraftApprovedByInfluencer { get; set; }

        [JsonPropertyName("designDraftRejectedByDesignHead")]
        public DateTime DesignDraftRejectedByDesignHead { get; set; }

        [JsonPropertyName("designDraftApprovedByDesignHead")]
        public DateTime DesignDraftApprovedByDesignHead { get; set; }

        [JsonPropertyName("collectionConfirmed")]
        public DateTime CollectionConfirmed { get; set; }

        [JsonPropertyName("createProductOptions")]
        public DateTime CreateProductOptions { get; set; }

        [JsonPropertyName("twoDTechnicalDesignBoardUploaded")]
        public DateTime TwoDTechnicalDesignBoardUploaded { get; set; }

        #endregion

        #region 3DVirtualFitting    

        [JsonPropertyName("threeDVirtualFittingOrderPlaced")]
        public DateTime ThreeDVirtualFittingOrderPlaced { get; set; }

        [JsonPropertyName("threeDVirtualFittingPreviewsUploaded")]
        public DateTime ThreeDVirtualFittingPreviewsUploaded { get; set; }

        [JsonPropertyName("threeDVirtualFittingPreviewsRejected")]
        public DateTime ThreeDVirtualFittingPreviewsRejected { get; set; }

        [JsonPropertyName("threeDVirtualFittingPreviewsApproved")]
        public DateTime ThreeDVirtualFittingPreviewsApproved { get; set; }

        [JsonPropertyName("allFinalThreeDVirtualFittingsUploaded")]
        public DateTime AllFinalThreeDVirtualFittingsUploaded { get; set; }

        [JsonPropertyName("finalThreeDVirtualFittingsRejectedByInfluencer")]
        public DateTime FinalThreeDVirtualFittingsRejectedByInfluencer { get; set; }

        [JsonPropertyName("finalThreeDVirtualFittingsApprovedByInfluencer")]
        public DateTime FinalThreeDVirtualFittingsApprovedByInfluencer { get; set; }

        [JsonPropertyName("threeDTechnicalDesignBoardUploaded")]
        public DateTime ThreeDTechnicalDesignBoardUploaded { get; set; }


        #endregion

        #region MockUp
        [JsonPropertyName("mockupOrdered")]
        public DateTime MockupOrdered { get; set; }

        [JsonPropertyName("mockupImagesUploaded")]
        public DateTime MockupImagesUploaded { get; set; }

        [JsonPropertyName("mockupImagesRejectedByDesignHead")]
        public DateTime MockupImagesRejectedByDesignHead { get; set; }

        [JsonPropertyName("mockupImagesApprovedByDesignHead")]
        public DateTime MockupImagesApprovedByDesignHead { get; set; }

        #endregion


        #region Fit Sample

        [JsonPropertyName("firstFitSampleOrdered")]
        public DateTime FirstFitSampleOrdered { get; set; }

        [JsonPropertyName("oDMFirstPatternReview")]
        public DateTime ODMFirstPatternReview { get; set; }

        [JsonPropertyName("oDMFirstFitSampleProduction")]
        public DateTime ODMFirstFitSampleProduction { get; set; }

        [JsonPropertyName("firstFitSampleImagesUploaded")]
        public DateTime FirstFitSampleImagesUploaded { get; set; }

        [JsonPropertyName("firstFitSampleRejectedByDesignHead")]
        public DateTime FirstFitSampleRejectedByDesignHead { get; set; }

        [JsonPropertyName("firstFitSampleApprovedByDesignHead")]
        public DateTime FirstFitSampleApprovedByDesignHead { get; set; }

        [JsonPropertyName("firstFitSampleShipped")]
        public DateTime FirstFitSampleShipped { get; set; }

        [JsonPropertyName("firstFitSampleDelivered")]
        public DateTime FirstFitSampleDelivered { get; set; }

        [JsonPropertyName("firstFitSampleApprovedByInfluencer")]
        public DateTime FirstFitSampleApprovedByInfluencer { get; set; }

        [JsonPropertyName("firstFitSampleRejectedByInfluencer")]
        public DateTime FirstFitSampleRejectedByInfluencer { get; set; }

        [JsonPropertyName("secondThreeDVirtualFittingPreviewUploaded")]
        public DateTime SecondThreeDVirtualFittingPreviewUploaded { get; set; }

        [JsonPropertyName("secondFinalThreeDVirtualFittingPreviewRejectedByInfluencer")]
        public DateTime SecondFinalThreeDVirtualFittingPreviewRejectedByInfluencer { get; set; }
        [JsonPropertyName("secondFinalThreeDVirtualFittingPreviewApprovedByInfluencer")]
        public DateTime SecondFinalThreeDVirtualFittingPreviewApprovedByInfluencer { get; set; }

        [JsonPropertyName("secondFinalThreeDTechnicalDesignBoardUploaded")]
        public DateTime SecondFinalThreeDTechnicalDesignBoardUploaded { get; set; }


        [JsonPropertyName("secondThreeDVirtualFittingBoardsRejectedByDesignHead")]
        public DateTime SecondThreeDVirtualFittingBoardsRejectedByDesignHead { get; set; }

        [JsonPropertyName("secondThreeDVirtualFittingBoardsApprovedByDesignHead")]
        public DateTime SecondThreeDVirtualFittingBoardsApprovedByDesignHead { get; set; }


        [JsonPropertyName("secondAllFinalThreeDVirtualFittingsUploaded")]
        public DateTime SecondAllFinalThreeDVirtualFittingsUploaded { get; set; }

        [JsonPropertyName("secondThreeDVirtualFittingBoardsRejectedByInfluencer")]
        public DateTime SecondThreeDVirtualFittingBoardsRejectedByInfluencer { get; set; }

        [JsonPropertyName("secondThreeDVirtualFittingBoardsApprovedByInfluencer")]
        public DateTime SecondThreeDVirtualFittingBoardsApprovedByInfluencer { get; set; }

        [JsonPropertyName("secondThreeDTechnicalDesignBoardUploaded")]
        public DateTime SecondThreeDTechnicalDesignBoardUploaded { get; set; }

        [JsonPropertyName("secondFitSampleOrdered")]
        public DateTime SecondFitSampleOrdered { get; set; }

        [JsonPropertyName("oDMSecondPatternReview")]
        public DateTime ODMSecondPatternReview { get; set; }

        [JsonPropertyName("oDMSecondFitSampleProduction")]
        public DateTime ODMSecondFitSampleProduction { get; set; }

        [JsonPropertyName("secondFitSampleImagesUploaded")]
        public DateTime SecondFitSampleImagesUploaded { get; set; }

        [JsonPropertyName("secondFitSampleRejectedByDesignHead")]
        public DateTime SecondFitSampleRejectedByDesignHead { get; set; }

        [JsonPropertyName("secondFitSampleApprovedByDesignHead")]
        public DateTime SecondFitSampleApprovedByDesignHead { get; set; }

        [JsonPropertyName("secondFitSampleShipped")]
        public DateTime SecondFitSampleShipped { get; set; }

        [JsonPropertyName("secondFitSampleDelivered")]
        public DateTime SecondFitSampleDelivered { get; set; }

        [JsonPropertyName("secondFitSampleApprovedByInfluencer")]
        public DateTime SecondFitSampleApprovedByInfluencer { get; set; }

        [JsonPropertyName("secondFitSampleRejectedByInfluencer")]
        public DateTime SecondFitSampleRejectedByInfluencer { get; set; }


        #endregion

        #region Photoshoot Sample

        [JsonPropertyName("photoshootSampleOrdered")]
        public DateTime PhotoshootSampleOrdered { get; set; }

        [JsonPropertyName("photoshootSampleProduction")]
        public DateTime PhotoshootSampleProduction { get; set; }

        [JsonPropertyName("photoshootSampleImagesUploaded")]
        public DateTime PhotoshootSampleImagesUploaded { get; set; }

        [JsonPropertyName("photoshootSampleRejectedByDesignHead")]
        public DateTime PhotoshootSampleRejectedByDesignHead { get; set; }

        [JsonPropertyName("photoshootSampleApprovedByDesignHead")]
        public DateTime PhotoshootSampleApprovedByDesignHead { get; set; }

        [JsonPropertyName("photoshootSampleShipped")]
        public DateTime PhotoshootSampleShipped { get; set; }

        [JsonPropertyName("photoshootSampleDelivered")]
        public DateTime PhotoshootSampleDelivered { get; set; }

        [JsonPropertyName("photoshootSampleApprovedByInfluencer")]
        public DateTime PhotoshootSampleApprovedByInfluencer { get; set; }

        [JsonPropertyName("photoshootSampleRejectedByInfluencer")]
        public DateTime PhotoshootSampleRejectedByInfluencer { get; set; }


        #endregion

        #region Launch Ready


        [JsonPropertyName("readyForLaunch")]
        public DateTime ReadyForLaunch { get; set; }

        [JsonPropertyName("tentativeReadyForLaunch")]
        public DateTime TentativeReadyForLaunch { get; set; }


        #endregion

        #region Launch Date

        [JsonPropertyName("marketingSampleOrdered")]
        public DateTime MarketingSampleOrdered { get; set; }

        [JsonPropertyName("marketingSampleShipped")]
        public DateTime MarketingSampleShipped { get; set; }

        [JsonPropertyName("launchDate")]
        public DateTime LaunchDate { get; set; }

        [JsonPropertyName("tentativeLaunchDate")]
        public DateTime TentativeLaunchDate { get; set; }

        #endregion

        #region Redrop Preperation

        [JsonPropertyName("launchFinished")]
        public DateTime LaunchFinished { get; set; }

        #endregion

        #region Redrop Preperation

        [JsonPropertyName("launchReady")]
        public DateTime LaunchReady { get; set; }

        #endregion

        #region Redrop Launch Ready

        [JsonPropertyName("readyForRedropLaunch")]
        public DateTime ReadyForRedropLaunch { get; set; }

        [JsonPropertyName("tentativeReadyForRedropLaunch")]
        public DateTime TentativeReadyForRedropLaunch { get; set; }

        #endregion

        #region Redrop Launch Date

        [JsonPropertyName("redropLaunchDate")]
        public DateTime RedropLaunchDate { get; set; }

        [JsonPropertyName("redropTentativeLaunchDate")]
        public DateTime RedropTentativeLaunchDate { get; set; }

        [JsonPropertyName("redropLaunchFinished")]
        public DateTime RedropLaunchFinished { get; set; }

        #endregion
    }
}
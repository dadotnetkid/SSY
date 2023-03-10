using System;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.RejectionNotes.Model
{
    public class CreateRejectionNoteOutputModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("rootId")]
        public Guid? RootId { get; set; }

        /// <summary>
        /// ProductId
        /// </summary>
        [JsonPropertyName("productId")]
        public Guid ProductId { get; set; }

        /// <summary>
        /// ChildProductId
        /// </summary>
        [JsonPropertyName("childProductId")]
        public Guid? ChildProductId { get; set; }

        /// <summary>
        /// Section - example: FirstDesignDraft, ThreeDVirtualFittingPreview
        /// </summary>
        [JsonPropertyName("section")]
        public string Section { get; set; }

        /// <summary>
        /// SectionId - example: FirstDesignDraftId, ThreeDVirtualFittingId
        /// </summary>
        [JsonPropertyName("sectionId")]
        public Guid? SectionId { get; set; }

        /// <summary>
        /// Side - example: Front, Back, LeftSide/RightSide
        /// </summary>
        [JsonPropertyName("side")]
        public string Side { get; set; }

        /// <summary>
        /// Notes - example: Reason for rejection
        /// </summary>
        [JsonPropertyName("notes")]
        public string Notes { get; set; }

        /// <summary>
        /// FilePath - example: ImageUrl
        /// </summary>
        [JsonPropertyName("filePath")]
        public string FilePath { get; set; }

        /// <summary>
        /// User - example: Ana D
        /// </summary>
        [JsonPropertyName("user")]
        public string User { get; set; }

        /// <summary>
        /// UserId
        /// </summary>
        [JsonPropertyName("userId")]
        public Guid? UserId { get; set; }

        [JsonPropertyName("creationTime")]
        public DateTime CreationTime { get; set; }
    }
}
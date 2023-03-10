using System;
using System.Text.Json.Serialization;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.SampleImageModel;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.ProductionFiles;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.ThreeDVirtualFitting.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.FirstDesignDrafts.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.RejectionNotes.Model;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.Model
{
    public class CreateProductInputModel
    {
        // [JsonPropertyName("tenantId")]
        // public int TenantId { get; set; } = 1;

        // [JsonPropertyName("isActive")]
        // public bool IsActive { get; set; } = true;


        [JsonPropertyName("influencerIds")]
        public string InfluencerIds { get; set; }

        [JsonPropertyName("collectionId")]
        public Guid CollectionId { get; set; }

        [JsonPropertyName("materialTypeId")]
        public int MaterialTypeId { get; set; }

        [JsonPropertyName("productApprovalStatusId")]
        public int ProductApprovalStatusId { get; set; }

        [JsonPropertyName("productTypeId")]
        public int ProductTypeId { get; set; }

        [JsonPropertyName("parentSku")]
        public string ParentSku { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("shippingTypeId")]
        public int ShippingTypeId { get; set; }

        [JsonPropertyName("productDesignStatusId")]
        public int ProductDesignStatusId { get; set; }

        [JsonPropertyName("objBlockPatterns")]
        public string ObjBlockPatterns { get; set; }

        [JsonPropertyName("baseSizeSpec")]
        public string BaseSizeSpec { get; set; }

        [JsonPropertyName("workmanshipGuide")]
        public string WorkmanshipGuide { get; set; }
        [JsonPropertyName("firstDesignDraftId")]
        public Guid? FirstDesignDraftId { get; set; }

        [JsonPropertyName("firstDesignDraft")]
        public FirstDesignDraftModel FirstDesignDraftModel { get; set; } = new();
        [JsonPropertyName("threeDVirtualFitting")]
        public ThreeDVirtualFittingModel ThreeDVirtualFittingModel { get; set; } = new();
        [JsonPropertyName("sampleImages")]
        public List<InfluencerSampleImagesModel> InfluencerSampleImagesModel { get; set; } = new();

        [JsonPropertyName("productionFiles")]
        public List<ProductionFileModel> ProductionFiles { get; set; } = new();

        [JsonPropertyName("rejectionNotes")]
        public List<RejectionNoteModel> RejectionNotes { get; set; } = new();


    }
}


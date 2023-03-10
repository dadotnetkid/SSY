using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.SampleImageModel;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.ProductionFiles;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.ThreeDVirtualFitting.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.FirstDesignDrafts.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.RejectionNotes.Model;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.Model
{
    public class UpdateProductInputModel
    {
        // [JsonPropertyName("tenantId")]
        // public int TenantId { get; set; } = 1;

        // [JsonPropertyName("isActive")]
        // public bool IsActive { get; set; } = true;



        [JsonPropertyName("firstDesignDraftId")]
        public Guid? FirstDesignDraftId { get; set; }

        [JsonPropertyName("threeDVirtualFittingId")]
        public Guid? ThreeDVirtualFittingId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("productDesignStatusId")]
        public int ProductDesignStatusId { get; set; }

        [JsonPropertyName("influencerIds")]
        public string InfluencerIds { get; set; }

        [JsonPropertyName("influencersName")]
        public string InfluencersName { get; set; }

        [JsonPropertyName("color")]
        public string Color { get; set; }

        [JsonPropertyName("collectionId")]

        public Guid CollectionId { get; set; }

        [JsonPropertyName("parentSku")]
        public string ParentSku { get; set; }

        [JsonPropertyName("materialTypeId")]
        public int MaterialTypeId { get; set; }

        [JsonPropertyName("productTypeId")]
        public int ProductTypeId { get; set; }

        [JsonPropertyName("shippingTypeId")]
        public int ShippingTypeId { get; set; }

        [JsonPropertyName("dateAdded")]
        public DateTime DateAdded { get; set; }

        [JsonPropertyName("creationTime")]
        public DateTime CreationTime { get; set; }

        [JsonPropertyName("productApprovalStatusId")]
        public int ProductApprovalStatusId { get; set; }

        ///////////////////////////////////////////
        // For Collection Details on product list//
        ///////////////////////////////////////////
        [JsonPropertyName("child")]
        public string Child { get; set; }

        [JsonPropertyName("firstFitSamplesStatus")]
        public string FirstFitSamplesStatus { get; set; }

        [JsonPropertyName("secondFitSamplesStatus")]
        public string SecondFitSamplesStatus { get; set; }

        [JsonPropertyName("photoShootSampleStatus")]
        public DateTime PhotoShootSampleStatus { get; set; }

        [JsonPropertyName("marketingSampleQty")]
        public int MarketingSampleQty { get; set; }

        [JsonPropertyName("productName")]
        public string ProductName { get; set; }

        [JsonPropertyName("collectionName")]
        public string CollectionName { get; set; }

        [JsonPropertyName("materialType")]
        [Required]
        public int MaterialType { get; set; }
        [JsonPropertyName("materialTypeName")]
        [Required]
        public string MaterialTypeName { get; set; }

        [JsonPropertyName("productType")]
        [Required]
        public int ProductType { get; set; }

        [JsonPropertyName("objBlockPatterns")]
        public string ObjBlockPatterns { get; set; }

        [JsonPropertyName("baseSizeSpec")]
        public string BaseSizeSpec { get; set; }

        [JsonPropertyName("workmanshipGuide")]
        public string WorkmanshipGuide { get; set; }

        [JsonPropertyName("firstDesignDraft")]
        public FirstDesignDraftModel FirstDesignDraftModel { get; set; } = new();

        [JsonPropertyName("threeDVirtualFitting")]
        public ThreeDVirtualFittingModel ThreeDVirtualFittingModel { get; set; } = new();

        [JsonPropertyName("sampleImages")]
        public List<InfluencerSampleImagesModel> SampleImagesModel { get; set; } = new();
        //////////////////////////////////////////////
        //End For Collection Details on product list//
        //////////////////////////////////////////////
        ///

        // [JsonPropertyName("productOptions")]
        // public ProductOptionsModel ProductOptions { get; set; }
        [JsonPropertyName("productionFiles")]
        public List<ProductionFileModel> ProductionFiles { get; set; } = new();
        [JsonPropertyName("rejectionNotes")]
        public List<RejectionNoteModel> RejectionNotes { get; set; } = new();
    }
}


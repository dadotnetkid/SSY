using System.Text.Json.Serialization;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.ProductOptions.Model;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Collections.Dto;
using SSY.Blazor.HttpClients.Models.Products.MediaFiles;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.BomSummaries.Dto;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.ProductionFiles;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Shopify.Models;
using SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.RejectionNotes.Model;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Products.Model;

public class ProductModel
{
    #region Common

    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("tenantId")]
    public Guid? TenantId { get; set; }

    [JsonPropertyName("isActive")]
    public bool IsActive { get; set; }

    [JsonPropertyName("sku")]
    public string Sku { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("typeId")]
    public int TypeId { get; set; }

    [JsonPropertyName("typeLabel")]
    public string TypeLabel { get; set; }

    [JsonPropertyName("typeMaterialTypeId")]
    public int? MaterialTypeId { get; set; }

    [JsonPropertyName("statusId")]
    public int StatusId { get; set; }

    [JsonPropertyName("statusValue")]
    public string StatusValue { get; set; }

    [JsonPropertyName("shippingTypeId")]
    public int ShippingTypeId { get; set; }

    [JsonPropertyName("productName")]
    public string ProductName { get; set; }

    [JsonPropertyName("creationTime")]
    public DateTime CreationTime { get; set; }

    [JsonPropertyName("lastModificationTime")]
    public DateTime? LastModificationTime { get; set; }

    [JsonPropertyName("collectionName")]
    public string CollectionName { get; set; }
    [JsonPropertyName("collectionAvailability")]
    public bool CollectionAvailability { get; set; }

    [JsonPropertyName("collectionInfluencers")]
    public List<CollectionInfluencerDto> CollectionInfluencers { get; set; } = new();

    [JsonPropertyName("collectionFactoryId")]
    public int CollectionFactoryId { get; set; }

    [JsonPropertyName("collectionFactoryValue")]
    public string CollectionFactoryValue { get; set; }

    [JsonPropertyName("influencerNames")]
    public string InfluencerNames { get; set; }

    // [JsonPropertyName("")]
    // public virtual ICollection<ProductOption> Options { get; set; }

    // [JsonPropertyName("")]
    // public virtual ICollection<ProductionFile> ProductionFiles { get; set; }

    // [JsonPropertyName("")]
    // public virtual ICollection<RejectionNote> RejectionNotes { get; set; }

    #endregion

    #region Product

    [JsonPropertyName("collectionId")]
    public Guid CollectionId { get; set; }

    [JsonPropertyName("approvalStatusId")]
    public int ApprovalStatusId { get; set; }

    [JsonPropertyName("statusDesignStatusId")]
    public int DesignStatusId { get; set; }

    [JsonPropertyName("objBlockPatternId")]
    public Guid? ObjBlockPatternId { get; set; }

    [JsonPropertyName("categoryId")]
    public int? CategoryId { get; set; }

    [JsonPropertyName("categoryLabel")]
    public string CategoryLabel { get; set; }

    [JsonPropertyName("baseSizeSpecId")]
    public Guid? BaseSizeSpecId { get; set; }

    [JsonPropertyName("workmanshipGuideId")]
    public Guid? WorkmanshipGuideId { get; set; }

    [JsonPropertyName("oemId")]
    public Guid? OEMId { get; set; }

    [JsonPropertyName("childProducts")]
    public List<ProductModel> ChildProducts { get; set; }

    [JsonPropertyName("options")]
    public List<ProductOptionModel> Options { get; set; }

    [JsonPropertyName("productMediaFiles")]
    public List<ProductMediaFiles> ProductMediaFiles { get; set; }

    // [JsonPropertyName("ProductMediaFileIds")]
    // public List<MediaFilesIds> ProductMediaFileIds { get; set; }

    #endregion

    #region Child Product

    [JsonPropertyName("parentId")]
    public Guid? ParentId { get; set; }

    [JsonPropertyName("colorOptionId")]
    public Guid? ColorOptionId { get; set; }

    [JsonPropertyName("dropId")]
    public int? DropId { get; set; }

    [JsonPropertyName("colorId")]
    public int? ColorId { get; set; }

    [JsonPropertyName("shopify")]
    public ShopifyModel Shopify { get; set; }

    [JsonPropertyName("billOfMaterial")]
    public ProductBomSummaryDto BillOfMaterial { get; set; } = new();

    #endregion

    #region For UI Usage

    [JsonPropertyName("influencersName")]
    public string InfluencersName { get; set; }

    [JsonPropertyName("influencerIds")]
    public string InfluencerIds { get; set; }

    [JsonPropertyName("productionFiles")]
    public List<ProductionFileModel> ProductionFiles { get; set; }

    [JsonPropertyName("rejectionNotes")]
    public List<RejectionNoteModel> RejectionNotes { get; set; }

    [JsonPropertyName("dateAdded")]
    public DateTime DateAdded { get; set; }

    [JsonPropertyName("colorCode")]
    public string ColorCode { get; set; }

    [JsonPropertyName("colorName")]
    public string ColorName { get; set; }

    [JsonPropertyName("hexCode")]
    public string HexCode { get; set; }

    [JsonPropertyName("parentCount")]
    public int ParentCount { get; set; }

    #endregion

    #region NotMapped
    [JsonIgnore]
    public bool IsSaving { get; set; }

    [JsonIgnore]
    public bool IsIncluded
    {
        get;
        set;
    }

    [JsonIgnore]
    public bool IsDropdownShow { get; set; }
    #endregion

    public ProductModel()
    {
        TenantId = null;
        ProductMediaFiles = new();
        // ProductMediaFileIds = new();
        Shopify = new();
        ProductionFiles = new();
        RejectionNotes = new();
    }
}


public class MediaFilesIds
{
    [JsonPropertyName("mediaFileId")]
    public Guid MediaFileId { get; set; }
}


public class ProductMediaFiles
{
    [JsonPropertyName("mediaFile")]
    public MediaFileModel MediaFile { get; set; }

    [JsonPropertyName("internalIsApproved")]
    public bool? InternalIsApproved { get; set; }

    [JsonPropertyName("internalIsApprovedDateTime")]
    public DateTime? InternalIsApprovedDateTime { get; set; }

    [JsonPropertyName("internalApprovedBy")]
    public string? InternalApprovedBy { get; set; }

    [JsonPropertyName("influencerIsApproved")]
    public bool? InfluencerIsApproved { get; set; }

    [JsonPropertyName("influencerIsApprovedDateTime")]
    public DateTime? InfluencerIsApprovedDateTime { get; set; }

    [JsonPropertyName("influencerApprovedBy")]
    public string? InfluencerApprovedBy { get; set; }

    [JsonPropertyName("mediaFileId")]
    public Guid MediaFileId { get; set; }

    public ProductMediaFiles()
    {
        MediaFile = new();
    }
}
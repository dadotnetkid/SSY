using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

using SSY.Products.Options.Dtos;
using SSY.Products.RejectionNotes.Dtos;
using SSY.Products.MediaFiles.Dtos;
using SSY.Products.Shopifies.Dtos;
using SSY.Products.Accountings.Dtos;
using SSY.Products.Pricings.Dtos;
using SSY.Products.BillOfMaterials.Dtos;
using SSY.Products.Collections.Dtos;

namespace SSY.Products.Dtos;

public class ProductDto : ExtensibleAuditedEntityDto<Guid>
{
    #region Common

    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }
    public bool? IsDeleted { get; set; }

    public string Sku { get; set; }
    public string Name { get; set; }
    public int TypeId { get; set; }
    public string TypeLabel { get; set; }
    public int? TypeMaterialTypeId { get; set; }
    public int StatusId { get; set; }
    public string StatusValue { get; set; }
    public int StatusDesignStatusId { get; set; }
    public List<ProductOptionDto> Options { get; set; }
    public List<ProductMediaFileDto> ProductMediaFiles { get; set; }
    public List<RejectionNoteDto> RejectionNotes { get; set; }

    #endregion

    #region Product

    public Guid? CollectionId { get; set; }
    public string CollectionName { get; set; }
    public int CollectionFactoryId { get; set; }
    public string CollectionFactoryValue { get; set; }
    public List<CollectionInfluencerDto> CollectionInfluencers { get; set; }
    public bool CollectionAvailability { get; set; }
    public string InfluencerNames
    {
        get
        {
            string names = string.Empty;
            CollectionInfluencers.ForEach(x => names = string.Join(",", x.InfluencerFullName));
            return names;
        }
    }
    public int? LaunchCategoryId { get; set; }
    public int ApprovalStatusId { get; set; }
    public Guid? ObjBlockPatternId { get; set; }
    public Guid? BaseSizeSpecId { get; set; }
    public Guid? WorkmanshipGuideId { get; set; }
    public Guid? OEMId { get; set; }
    public List<ProductDto> ChildProducts { get; set; }

    public AccountingDto Accounting { get; set; }
    public PricingDto Pricing { get; set; }



    #endregion

    #region Child Product

    public Guid? ParentId { get; set; }
    public Guid? ColorOptionId { get; set; }
    public int? ColorId { get; set; }
    public string ColorValue { get; set; }
    public string ColorShortCode { get; set; }
    public int? DropId { get; set; }
    public ShopifyDto Shopify { get; set; }
    public BillOfMaterialDto BillOfMaterial { get; set; }
    public string ProductOptionNotes { get; set; }

    #endregion
}
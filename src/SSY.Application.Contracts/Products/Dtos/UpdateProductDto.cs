using System;
using System.Collections.Generic;
using SSY.Products.Accountings.Dtos;
using SSY.Products.BillOfMaterials.Dtos;
using SSY.Products.Pricings.Dtos;
using SSY.Products.RejectionNotes.Dtos;
using SSY.Products.Shopifies.Dtos;
using Volo.Abp.Application.Dtos;

namespace SSY.Products.Dtos;

public class UpdateProductDto : EntityDto<Guid>
{
    #region Common

    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }
    public string Sku { get; set; }
    public string Name { get; set; }
    public int TypeId { get; set; }
    public int StatusId { get; set; }
    public List<UpdateProductOptionDto> Options { get; set; }
    public List<UpdateProductMediaFileDto> ProductMediaFiles { get; set; }
    public List<UpdateRejectionNoteDto> RejectionNotes { get; set; }

    #endregion

    #region Product

    public Guid? CollectionId { get; set; }
    public int? LaunchCategoryId { get; set; }
    public int ApprovalStatusId { get; set; }
    public Guid? ObjBlockPatternId { get; set; }
    public Guid? BaseSizeSpecId { get; set; }
    public Guid? WorkmanshipGuideId { get; set; }
    public Guid? OEMId { get; set; }
    public List<UpdateProductDto> ChildProducts { get; set; }

    public UpdateAccountingDto Accounting { get; set; }
    public UpdatePricingDto Pricing { get; set; }

    #endregion

    #region Child Product

    public Guid? ParentId { get; set; }
    public Guid? ColorOptionId { get; set; }
    public int? ColorId { get; set; }
    public string ColorValue { get; set; }
    public string ColorShortCode { get; set; }
    public int? DropId { get; set; }
    public UpdateShopifyDto Shopify { get; set; }
    public UpdateBillOfMaterialDto BillOfMaterial { get; set; }
    public string ProductOptionNotes { get; set; }

    #endregion
}
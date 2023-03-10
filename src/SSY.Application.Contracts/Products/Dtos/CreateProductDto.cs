using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using SSY.Products.Shopifies.Dtos;
using SSY.Products.Accountings.Dtos;
using SSY.Products.Pricings.Dtos;
using SSY.Products.BillOfMaterials.Dtos;

namespace SSY.Products.Dtos;

public class CreateProductDto : EntityDto<Guid>
{
    #region Common

    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }
    public string Sku { get; set; }
    public string Name { get; set; }
    public int TypeId { get; set; }
    public int StatusId { get; set; }

    #endregion

    #region Product

    public Guid? CollectionId { get; set; }
    public int? LaunchCategoryId { get; set; }
    public int ApprovalStatusId { get; set; }
    public List<CreateProductDto> ChildProducts { get; set; }

    public CreateAccountingDto Accounting { get; set; }
    public CreatePricingDto Pricing { get; set; }

    #endregion

    #region Child Product

    public Guid? ParentId { get; set; }
    public Guid? ColorOptionId { get; set; }
    public int? ColorId { get; set; }
    public string ColorValue { get; set; }
    public string ColorShortCode { get; set; }
    public int? DropId { get; set; }
    public CreateShopifyDto Shopify { get; set; }
    public CreateBillOfMaterialDto BillOfMaterial { get; set; }
    public string ProductOptionNotes { get; set; }

    #endregion
}
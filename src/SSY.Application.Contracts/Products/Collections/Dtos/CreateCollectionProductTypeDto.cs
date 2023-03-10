using System;
using System.Collections.Generic;
using System.Text;
using SSY.Products.Types.Dtos;

namespace SSY.Products.Collections.Dtos;

public class CreateCollectionProductTypeDto
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    public Guid CollectionId { get; set; }
    public int ProductTypeId { get; set; }

    public string MaterialTypeShortCode { get; set; }
    public string MaterialTypeValue { get; set; }
}
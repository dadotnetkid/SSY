using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace SSY.Products.Dtos;

public class GetAllProductDto : PagedAndSortedResultRequestDto
{
    public bool? IsActive { get; set; }

    public int? ColorId { get; set; }
}
public class ProductRequestDto
{
    public string Fields { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    public string IncludedProperties { get; set; }
}

public class GetAllProductListDto
{
    public int TotalCount { get; set; }
    public List<ProductListDto> Items { get; set; }
}

public class ProductListDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string DesignStatusValue { get; set; }
    public string InfluencerNames { get; set; }
    public string CollectioName { get; set; }
    public string Sku { get; set; }
    public DateTime CreationTime { get; set; }
}
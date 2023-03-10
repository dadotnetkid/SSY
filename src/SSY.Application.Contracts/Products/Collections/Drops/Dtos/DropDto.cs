using System;
using Volo.Abp.Application.Dtos;

namespace SSY.Products.Collections.Drops.Dtos;

public class DropDto : EntityDto<int>
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    /// <summary>
    /// Label
    /// </summary>
    public string Label { get; set; }

    /// <summary>
    /// Value
    /// </summary>
    public string Value { get; set; }

    /// <summary>
    /// Order Number is use for sorting
    /// </summary>
    public int OrderNumber { get; set; }

}

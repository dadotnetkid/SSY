using System;
using Volo.Abp.Application.Dtos;

namespace SSY.Products.Accountings.Dtos;

public class UpdateAccountingDto : EntityDto<Guid>
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    public Guid ProductId { get; set; }

    public int UnitSales { get; set; }
    public int TotalSales { get; set; }
}
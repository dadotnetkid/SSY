using System;

namespace SSY.Products.Accountings.Dtos;

public class CreateAccountingDto
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    public Guid ProductId { get; set; }

    public double UnitSales { get; set; }
    public double TotalSales { get; set; }
}
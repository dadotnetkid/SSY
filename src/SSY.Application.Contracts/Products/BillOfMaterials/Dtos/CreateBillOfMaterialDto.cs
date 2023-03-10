using System;
using Volo.Abp.Application.Dtos;

namespace SSY.Products.BillOfMaterials.Dtos;

public class CreateBillOfMaterialDto
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    public Guid ProductId { get; set; }

    public Guid MaterialId { get; set; }
    public int PartNumber { get; set; }
    public string PartName { get; set; }
    public string ColorCode { get; set; }
    public string ItemCode { get; set; }
    public double Consumption { get; set; }
    public string UnitOfMeasurement { get; set; }
    public string CuttableWidth { get; set; }
    public string ContentDescription { get; set; }
    public double Price { get; set; }
    public string Supplier { get; set; }

    public string Notes { get; set; }
}
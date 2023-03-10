using System;

namespace SSY.Products.Dtos;

public class CreateProductOptionDto
{
    public Guid ProductId { get; set; }
    public int OptionId { get; set; }
    public Guid? MaterialId { get; set; }
    public string RollIds { get; set; }
    public int? UnitOfMeasurementId { get; set; }
    public double? Consumption { get; set; }
    public string MaterialName { get; set; }
    public string RollNames { get; set; }
}
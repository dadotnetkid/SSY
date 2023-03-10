using System;
using Volo.Abp.Domain.Entities;

namespace SSY.Products;

public class ProductOptionDetail : Entity<Guid>
{

    public virtual ProductOption ProductOption { get; protected set; }
    public virtual Guid ProductOptionId { get; protected set; }

    public virtual Guid? MaterialId { get; protected set; }
    public virtual string RollIds { get; protected set; }
    public virtual int? UnitOfMeasurementId { get; protected set; }
    public virtual double? Consumption { get; protected set; }
    public string MaterialName { get; protected set; }
    public string RollNames { get; protected set; }

    protected ProductOptionDetail()
    {
    }
}
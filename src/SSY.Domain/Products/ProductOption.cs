using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using SSY.Products.Options;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace SSY.Products;

public class ProductOption : Entity<Guid>
{
    public virtual Product Product { get; protected set; }
    public virtual Guid ProductId { get; protected set; }

    public virtual Option Option { get; protected set; }
    public virtual int OptionId { get; protected set; }

    public virtual Guid? MaterialId { get; protected set; }
    public virtual string RollIds { get; protected set; }
    public virtual int? UnitOfMeasurementId { get; protected set; }
    public virtual double? Consumption { get; protected set; }
    public virtual string MaterialName { get; protected set; }
    public virtual string RollNames { get; protected set; }
    public virtual ICollection<ProductOptionDetail> ProductOptionDetails { get; protected set; }

    protected ProductOption()
    {
        ProductOptionDetails = new Collection<ProductOptionDetail>();
    }

    internal ProductOption(Guid productId, int optionId)
    {
        ProductId = productId;
        OptionId = optionId;
    }

    internal ProductOption(Guid productId, int optionId, string rollIds)
    {
        ProductId = productId;
        OptionId = optionId;
        RollIds = rollIds;
    }

    internal ProductOption(Guid productId, int optionId, Guid materialId)
    {
        ProductId = productId;
        OptionId = optionId;
        MaterialId = materialId;
    }

    internal ProductOption(Guid productId, int optionId, int unitOfMeasurementId)
    {
        ProductId = productId;
        OptionId = optionId;
        UnitOfMeasurementId = unitOfMeasurementId;
    }

    internal ProductOption(Guid productId, int optionId, double consumption)
    {
        ProductId = productId;
        OptionId = optionId;
        Consumption = consumption;
    }

    internal ProductOption(Guid productId, int optionId, string rollIds, string materialName, string rollNames, double consumption, int unitOfMeasurementId, Guid materialId)
    {
        ProductId = productId;
        OptionId = optionId;
        RollIds = rollIds;
        Consumption = consumption;
        UnitOfMeasurementId = unitOfMeasurementId;
        MaterialId = materialId;
        MaterialName = materialName;
        RollNames = rollNames;
    }

    public void SetRollId(string rollIds)
    {
        RollIds = rollIds;
    }

    public virtual void SetProductId(Guid productId)
    {
        ProductId = productId;
    }

    public virtual void SetConsumption(double consumption)
    {
        Consumption = consumption;
    }

    public virtual void SetMaterialId(Guid materialId)
    {
        MaterialId = materialId;
    }

    public virtual void SetUOMId(int unitOfMeasurementId)
    {
        UnitOfMeasurementId = unitOfMeasurementId;
    }
}
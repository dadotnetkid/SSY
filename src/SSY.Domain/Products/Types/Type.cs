using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SSY.Products.Types;
using SSY.Products.CustomFilters;
using SSY.Products.Options;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace SSY.Products.Types;

public class Type : FullAuditedAggregateRoot<int>, IMultiTenant, IIsActive
{
    public virtual Guid? TenantId { get; protected set; }
    public virtual bool IsActive { get; protected set; }

    public virtual int? MaterialTypeId { get; protected set; }

    [Required]
    public virtual string ShortCode { get; protected set; }
    [Required]
    public virtual string Label { get; protected set; }
    [Required]
    public virtual string Value { get; protected set; }
    public virtual int OrderNumber { get; protected set; }

    public virtual double AverageConsumption { get; protected set; }
    public virtual double SalesPercentage { get; protected set; }
    public virtual double SubSalesPercentage { get; protected set; }

    public virtual int? ProductCategoryId { get; protected set; }

    public virtual ICollection<BaseSizeSpec> BaseSizeSpecs { get; protected set; }
    public virtual ICollection<ObjBlockPattern> ObjBlockPatterns { get; protected set; }
    public virtual ICollection<TypeOption> Options { get; protected set; }

    #region Shipping Premium

    public virtual double? DefaultWeight { get; protected set; }
    public virtual double? FreeShippingFedExPrice { get; protected set; }
    public virtual double? FreeShippingDHLPrice { get; protected set; }
    public virtual double? TenUSDPrice { get; protected set; }
    public virtual double? FifteenUSDPrice { get; protected set; }
    public virtual double? TwentyUSDPrice { get; protected set; }

    #endregion

    protected Type()
    {
        BaseSizeSpecs = new Collection<BaseSizeSpec>();
        ObjBlockPatterns = new Collection<ObjBlockPattern>();
        Options = new Collection<TypeOption>();
    }

    internal Type(int materialTypeId, int id, bool isActive, string label, string value, string shortCode, int orderNumber, double averageConsumption, double salesPercentage, double subSalesPercentage, int? productCategoryId)
    {
        MaterialTypeId = materialTypeId;
        Id = id;
        IsActive = isActive;
        Label = label;
        Value = value;
        ShortCode = shortCode;
        OrderNumber = orderNumber;
        AverageConsumption = averageConsumption;
        SalesPercentage = salesPercentage;
        SubSalesPercentage = subSalesPercentage;
        ProductCategoryId = productCategoryId;
    }

    internal Type(int materialTypeId, int id, bool isActive, string label, string value, string shortCode, int orderNumber, double averageConsumption, double salesPercentage, double subSalesPercentage, int? productCategoryId, double freeShippingFedExPrice, double freeShippingDHLPrice, double tenUSDPrice, double fifteenUSDPrice, double twentyUSDPrice)
    {
        MaterialTypeId = materialTypeId;
        Id = id;
        IsActive = isActive;
        Label = label;
        Value = value;
        ShortCode = shortCode;
        OrderNumber = orderNumber;
        AverageConsumption = averageConsumption;
        SalesPercentage = salesPercentage;
        SubSalesPercentage = subSalesPercentage;
        ProductCategoryId = productCategoryId;
        FreeShippingFedExPrice = freeShippingFedExPrice;
        FreeShippingDHLPrice = freeShippingDHLPrice;
        TenUSDPrice = tenUSDPrice;
        FifteenUSDPrice = fifteenUSDPrice;
        TwentyUSDPrice = twentyUSDPrice;
    }

    public void UpdateShippingPremium(double defaultWeight, double freeShippingFedExPrice, double freeShippingDHLPrice, double tenUSDPrice, double fifteenUSDPrice, double twentyUSDPrice)
    {
        DefaultWeight = defaultWeight;
        FreeShippingFedExPrice = freeShippingFedExPrice;
        FreeShippingDHLPrice = freeShippingDHLPrice;
        TenUSDPrice = tenUSDPrice;
        FifteenUSDPrice = fifteenUSDPrice;
        TwentyUSDPrice = twentyUSDPrice;
    }

    public virtual void AddOptions(List<TypeOption> options)
    {
        ClearOptions();
        options.ForEach(Options.Add);
    }

    public virtual void AddBaseSizeSpecs(List<BaseSizeSpec> baseSizeSpecs)
    {
        ClearBaseSizeSpecs();
        baseSizeSpecs.ForEach(BaseSizeSpecs.Add);
    }

    public virtual void AddObjBlockPatterns(List<ObjBlockPattern> objBlockPatterns)
    {
        ClearObjBlockPatterns();
        objBlockPatterns.ForEach(ObjBlockPatterns.Add);
    }

    public virtual void ClearOptions()
    {
        Options.Clear();
    }

    public virtual void ClearBaseSizeSpecs()
    {
        BaseSizeSpecs.Clear();
    }

    public virtual void ClearObjBlockPatterns()
    {
        ObjBlockPatterns.Clear();
    }

}
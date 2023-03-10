using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using SSY.Products.Collections.AssignedTos;
using SSY.Products.Collections.ColorOptions;
using SSY.Products.Collections.DesignStatuses;
using SSY.Products.Collections.Factories;
using SSY.Products.Collections.MarketingTypes;
using SSY.Products.Collections.PricePoints;
using SSY.Products.Collections.Seasons;
using SSY.Products.Collections.ShippingTypes;
using SSY.Products.Collections.Statuses;
using SSY.Products.CustomFilters;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace SSY.Products.Collections;

public class Collection : FullAuditedAggregateRoot<Guid>, IMultiTenant, IIsActive
{
    public virtual Guid? TenantId { get; protected set; }
    public virtual bool IsActive { get; protected set; }

    public virtual string Name { get; protected set; }
    public virtual bool Availability { get; protected set; }
    public virtual bool IsPublished { get; protected set; }
    public virtual int Year { get; protected set; }
    public virtual DateTime CollectionDevelopmentStartDate { get; protected set; }
    public virtual DateTime ProvisionalLaunchDate { get; protected set; }

    public virtual AssignedTo AssignedTo { get; protected set; }

    public virtual int DesignStatusId { get; protected set; }
    public virtual DesignStatus DesignStatus { get; protected set; }

    public virtual int FactoryId { get; protected set; }
    public virtual Factory Factory { get; protected set; }

    public virtual int MarketingTypeId { get; protected set; }
    public virtual MarketingType MarketingType { get; protected set; }

    public virtual int PricePointId { get; protected set; }
    public virtual PricePoint PricePoint { get; protected set; }

    public virtual int SeasonId { get; protected set; }
    public virtual Season Season { get; protected set; }

    public virtual int ShippingTypeId { get; protected set; }
    public virtual ShippingType ShippingType { get; protected set; }

    public virtual int StatusId { get; protected set; }
    public virtual Statuses.Status Status { get; protected set; }

    public virtual ICollection<Product> Products { get; protected set; }
    public virtual ICollection<CollectionProductType> ProductTypes { get; protected set; }
    public virtual ICollection<CollectionInfluencer> Influencers { get; protected set; }
    public virtual ICollection<ColorOption> ColorOptions { get; protected set; }
    public virtual ICollection<CollectionSize> Sizes { get; protected set; }
    protected Collection()
    {
        Products = new Collection<Product>();
        ProductTypes = new Collection<CollectionProductType>();
        Influencers = new Collection<CollectionInfluencer>();
        ColorOptions = new Collection<ColorOption>();
        Sizes = new Collection<CollectionSize>();
    }

    public void ApproveColorOption(Guid colorOptionId, string approvedBy)
    {
        var colorOption = ColorOptions.FirstOrDefault(x => x.Id == colorOptionId);
        colorOption.Approve(approvedBy);
    }

    public void RejectColorOption(Guid colorOptionId, string approvedBy)
    {
        var colorOption = ColorOptions.FirstOrDefault(x => x.Id == colorOptionId);
        colorOption.Reject(approvedBy);

        foreach (var item in Products)
        {
            if (item.ColorOptionId == colorOption.Id)
                item.SetIsDeleted(true);

            if (item.ChildProducts.Any())
                foreach (var child in item.ChildProducts)
                    if (child.ColorOptionId == colorOption.Id)
                        child.SetIsDeleted(true);
        }
    }

    public void ResetApproval()
    {
        foreach (var colorOption in ColorOptions)
            colorOption.ResetApproval();
        IsPublished = false;
    }

    public void SetStatus(int statusId)
    {
        StatusId = statusId;
    }

    public void SetPublish()
    {
        IsPublished = true;
    }

    public void SetProductsIsActive(bool isActive)
    {
        foreach (var parent in Products)
        {
            parent.SetIsActive(isActive);

            if (parent.ChildProducts.Any())
                foreach (var child in parent.ChildProducts)
                    if (child.IsDeleted == false)
                        child.SetIsActive(isActive);
        }
    }

    public void RemoveDeletedColorOptionProducts()
    {
        foreach (var parent in Products)
        {
            if (parent.ChildProducts.Any())

                foreach (var child in parent.ChildProducts)
                {
                    var colorOptionId = child.ColorOptionId;
                    var colorId = child.ColorId;
                    var productTypeId = child.TypeId;

                    var colorOption = ColorOptions.FirstOrDefault(x => x.ColorId == colorId);

                    if (colorOption == null)
                    {
                        if (child.ColorId != null)
                            child.SetIsDeleted(true);
                    }
                }
        }
    }

    public virtual void AddProductTypes(List<CollectionProductType> productTypes)
    {
        ProductTypes.Clear();
        productTypes.ForEach(ProductTypes.Add);
    }

    public virtual void AddInfluencers(List<CollectionInfluencer> influencers)
    {
        Influencers.Clear();
        influencers.ForEach(Influencers.Add);
    }

    public virtual void AddColorOptions(List<ColorOption> colorOptions)
    {
        ColorOptions.Clear();
        colorOptions.ForEach(ColorOptions.Add);
    }

    public virtual void AddSizes(List<CollectionSize> sizes)
    {
        Sizes.Clear();
        sizes.ForEach(Sizes.Add);
    }

    public void SetAssignedTo(AssignedTo assignedTo)
    {
        AssignedTo = assignedTo;
    }

    public void SetAvailability(bool availability)
    {
        Availability = availability;
    }

    public void SetShopifyId(long? shopifyId)
    {

    }

    public void RemoveColorOption(ColorOption colorOption)
    {
        var coloroption = ColorOptions.FirstOrDefault(x => x.Id == colorOption.Id);
        ColorOptions.Remove(colorOption);
    }

}
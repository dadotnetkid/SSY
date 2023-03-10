using System;
//using Newtonsoft.Json.Linq;
using SSY.Products.CustomFilters;
using SSY.Products.Options;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace SSY.Products.Types;

public class TypeOption : Entity, IMultiTenant, IIsActive
{
    public virtual Guid? TenantId { get; protected set; }
    public virtual bool IsActive { get; protected set; }

    public virtual int TypeId { get; protected set; }

    // One to One relationship to able flatmapping
    public virtual int OptionId { get; protected set; }
    public virtual Option Option { get; protected set; }

    public virtual string MaterialIds { get; protected set; }

    protected TypeOption()
    {
    }

    internal TypeOption(int typeId, int optionId)
    {
        TypeId = typeId;
        OptionId = optionId;
        IsActive = true;
    }

    internal TypeOption(int typeId, int optionId, bool isActive)
    {
        TypeId = typeId;
        OptionId = optionId;
        IsActive = isActive;
    }

    internal TypeOption(int typeId, int optionId, string materialIds)
    {
        TypeId = typeId;
        OptionId = optionId;
        MaterialIds = materialIds;
        IsActive = true;
    }
    internal TypeOption(int typeId, int optionId, string materialIds, bool isActive)
    {
        TypeId = typeId;
        OptionId = optionId;
        MaterialIds = materialIds;
        IsActive = isActive;
    }

    public override object[] GetKeys()
    {
        return new object[] { TypeId, OptionId };
    }
}
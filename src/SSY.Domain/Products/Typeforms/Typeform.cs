using System;
using SSY.Products.CustomFilters;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace SSY.Products.Typeforms;

public class Typeform : FullAuditedAggregateRoot<Guid>, IMultiTenant, IIsActive
{
    public virtual Guid? TenantId { get; protected set; }
    public virtual bool IsActive { get; protected set; }

    public virtual string Type { get; protected set; }
    public virtual string Response { get; protected set; }

    public virtual string Email { get; protected set; }
    protected Typeform()
    {
    }

    internal Typeform(string type, string response)
    {
        Type = type;
        Response = response;
        IsActive = true;
    }

    internal Typeform(string type, string response, string email, bool isActive)
    {
        Type = type;
        Response = response;
        Email = email;
        IsActive = isActive;
    }

    public void SetActive(bool active)
    {
        IsActive = active;
    }
}
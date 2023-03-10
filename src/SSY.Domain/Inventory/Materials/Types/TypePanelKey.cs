using System;
using SSY.Products.CustomFilters;
using Volo.Abp.MultiTenancy;

namespace SSY.Inventory.Materials.Types;

[Table("AppMaterialTypePanelKeys")]
public class TypePanelKey : Entity<Guid>, IMultiTenant, IIsActive
{
    public virtual Guid? TenantId { get; protected set; }
    public virtual bool IsActive { get; protected set; }

    public virtual int TypeId { get; set; }
    [ForeignKey(nameof(TypeId))]
    public Type Type { get; set; }

    public virtual int PanelId { get; set; }
    [ForeignKey(nameof(PanelId))]
    public Panel Panel { get; set; }

    protected TypePanelKey()
    {
    }

    public TypePanelKey(int typeId, int panelId)
    {
        IsActive = true;
        TypeId = typeId;
        PanelId = panelId;
    }
}


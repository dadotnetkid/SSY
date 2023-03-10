
using System;
using Volo.Abp.Application.Dtos;

namespace SSY.Products.Types.Dtos;

public class OBJBlockPatternDto : EntityDto<Guid>
{
    public virtual Guid? TenantId { get; protected set; }
    public virtual bool IsActive { get; protected set; }

    public virtual int TypeId { get; set; }
    public virtual Guid MediaFileId { get; set; }

}


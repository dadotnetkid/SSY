using System;
namespace SSY.Products.Types.Dtos
{
    public class UpdateBaseSizeSpecDto
    {
        public virtual Guid? TenantId { get; protected set; }
        public virtual bool IsActive { get; protected set; }

        public virtual int TypeId { get; set; }
        public virtual Guid MediaFileId { get; set; }

    }
}


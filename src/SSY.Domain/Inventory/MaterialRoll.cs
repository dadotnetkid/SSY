using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SSY.Inventory
{
    [Table("AppMaterialRolls")]
    public class MaterialRoll : FullAuditedAggregateRoot<Guid>
    {
        // Default constructor use by Entity Framework Core don't remove.
        protected MaterialRoll()
        {
        }

        public int TenantId { get; set; }
        public bool IsActive { get; set; }

        /// <summary>
        /// Material / SubMaterial
        /// </summary>
        [Required]
        public Guid MaterialId { get; set; }

        /// <summary>
        /// RollAndLocation
        /// </summary>
        [Required]
        public Guid RollId { get; set; }

        public MaterialRoll(int tenantId, bool isActive, Guid materialId, Guid rollId)
        {
            TenantId = tenantId;
            IsActive = isActive;
            MaterialId = materialId;
            RollId = rollId;
        }
    }
}
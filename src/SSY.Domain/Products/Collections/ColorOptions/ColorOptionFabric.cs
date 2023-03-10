using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SSY.Products.CustomFilters;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace SSY.Products.Collections.ColorOptions
{
    public class ColorOptionFabric : Entity<Guid>, IMultiTenant, IIsActive
    {
        public virtual Guid? TenantId { get; protected set; }
        public virtual bool IsActive { get; protected set; }

        public virtual ColorOption ColorOption { get; protected set; }
        public virtual Guid ColorOptionId { get; protected set; }

        public virtual Guid MaterialId { get; protected set; }
        public virtual double? Consumption { get; protected set; }

        public virtual ICollection<ColorOptionFabricRoll> Rolls { get; protected set; }

        public virtual string FabricComposition { get; protected set; }
        public virtual string CareInstruction { get; protected set; }
        public virtual string ColorCode { get; protected set; }
        public virtual string ItemCode { get; protected set; }
        public virtual string UnitOfMeasurement { get; protected set; }
        public virtual string CuttableWidth { get; protected set; }
        public virtual string ContentDescription { get; protected set; }
        public virtual double Price { get; protected set; }
        public virtual string Supplier { get; protected set; }


        protected ColorOptionFabric()
        {
            Rolls = new Collection<ColorOptionFabricRoll>();
        }

        public virtual void AddRoll(ColorOptionFabricRoll roll)
        {
            Rolls.Add(roll);
        }

        public virtual void AddRolls(List<ColorOptionFabricRoll> rolls)
        {
            ClearRolls();
            rolls.ForEach(Rolls.Add);
        }

        public virtual void ClearRolls()
        {
            Rolls.Clear();
        }

        public virtual void SetMaterialId(Guid materialId)
        {
            MaterialId = materialId;
        }
    }
}


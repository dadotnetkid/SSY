﻿using SSY.Products.CustomFilters;
using System;
using Volo.Abp.MultiTenancy;

namespace SSY.Inventory.FabricStretches
{
    /// <summary>
    /// Fabric Strech
    /// </summary>
    [Table("AppFabricStretches")]
    public class FabricStretch : FullAuditedAggregateRoot<int>, IMultiTenant, IIsActive
    {
        public virtual Guid? TenantId { get; protected set; }
        public virtual bool IsActive { get; protected set; }

        /// <summary>
        /// Id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override int Id { get; protected set; }

        /// <summary>
        /// Label
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Order Number is use for sorting
        /// </summary>
        public int OrderNumber { get; set; }

        // Default constructor use by Entity Framework Core don't remove.
        public FabricStretch()
        {
        }

        public FabricStretch(int id, string label, string value, int orderNumber)
        {
            Id = id;
            Label = label;
            Value = value;
            OrderNumber = orderNumber;
            IsActive = true;
        }
    }
}

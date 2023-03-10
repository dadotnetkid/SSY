using SSY.Products.CustomFilters;
using System;
using Volo.Abp.MultiTenancy;

namespace SSY.Inventory.Colors
{
    /// <summary>
    /// Color Group
    /// Example: Blue, Red, Yellow, Green
    /// </summary>
    [Table("AppColors")]
    public class Color : FullAuditedAggregateRoot<int>, IMultiTenant, IIsActive
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
        /// HexValue
        /// </summary>
        public string HexCode { get; set; }

        /// <summary>
        /// Order Number is use for sorting
        /// </summary>
        public int OrderNumber { get; set; }

        /// <summary>
        /// Short Code
        /// </summary>
        public string ShortCode { get; set; }

        /// <summary>
        /// Sales Percentage
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public double? SalesPercentage { get; set; }

        // Default constructor use by Entity Framework Core don't remove.
        public Color()
        {
        }

        public Color(int id, string label, string value, string hexCode, int orderNumber, string shortCode, double? salesPercentage)
        {
            Id = id;
            Label = label;
            Value = value;
            HexCode = hexCode;
            OrderNumber = orderNumber;
            ShortCode = shortCode;
            SalesPercentage = salesPercentage;
            IsActive = true;
        }
    }
}

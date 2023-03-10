using System;

namespace SSY.Inventory.Adjustments
{
    /// <summary>
    /// Adjustment
    /// </summary>
    [Table("AppAdjustments")]
    public class Adjustment : FullAuditedAggregateRoot<Guid>
    {
        public int TenantId { get; set; }
        public bool IsActive { get; set; }

        /// <summary>
        /// Action ForeignKey
        /// </summary>
        public int ActionId { get; set; }
        [ForeignKey(nameof(ActionId))]
        public Type Type { get; set; }

        /// <summary>
        /// Date
        /// </summary>
        [Required]
        public DateTime Date { get; set; }

        /// <summary>
        /// Remarks
        /// </summary>
        public string? Remarks { get; set; }

        /// <summary>
        /// From
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public double From { get; set; }

        /// <summary>
        /// To
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public double To { get; set; }

        /// <summary>
        /// User
        /// </summary>
        [Required]
        public string User { get; set; }


        // Default Constructor use by Entity Framework Core don't remove.
        public Adjustment()
        { }

        public Adjustment(int tenantId, bool isActive, int actionId, DateTime date, string? remarks, double from, double to, string user)
        {
            TenantId = tenantId;
            IsActive = isActive;
            ActionId = actionId;
            Date = date;
            Remarks = remarks;
            From = from;
            To = to;
            User = user;
        }

    }
}

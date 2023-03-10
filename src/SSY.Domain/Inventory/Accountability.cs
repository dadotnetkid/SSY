using System;

namespace SSY.Inventory
{
    /// <summary>
    /// Internal tracking of Accountability
    /// </summary>
    [Table("AppAccountabilities")]
    public class Accountability : FullAuditedAggregateRoot<Guid>
    {
        public int TenantId { get; set; }
        public bool IsActive { get; set; }

        /// <summary>
        /// Date of Inventory
        /// </summary>
        public DateTime? DateOfInventory { get; set; }

        /// <summary>
        /// Stock Taker
        /// </summary>
        public string? StockTaker { get; set; }

        /// <summary>
        /// Validator
        /// </summary>
        public string? Validator { get; set; }

        /// <summary>
        /// Swatch Sent
        /// </summary>
        public DateTime? SwatchSent { get; set; }

        /// <summary>
        /// SwatchReceived
        /// </summary>
        public DateTime? SwatchReceived { get; set; }

        /// <summary>
        /// Confirmed Swatch Received
        /// </summary>
        public bool? ConfirmedSwatchReceived { get; set; }

        // Default constructor use by Entity Framework Core don't remove.
        public Accountability()
        {
        }

        public Accountability(DateTime? dateOfInventory, string? stockTaker, string? validator, bool? confirmedSwatchReceived,
                              DateTime? swatchSent = null, DateTime? swatchReceived = null)
        {
            DateOfInventory = dateOfInventory;
            StockTaker = stockTaker;
            Validator = validator;
            SwatchSent = swatchSent;
            SwatchReceived = swatchReceived;
            ConfirmedSwatchReceived = confirmedSwatchReceived;

        }
    }
}

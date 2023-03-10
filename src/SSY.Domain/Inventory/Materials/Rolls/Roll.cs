using System;
using System.Collections.Generic;

namespace SSY.Inventory.Materials.Rolls
{
    /// <summary>
    /// Roll
    /// </summary>
    [Index(propertyNames: new[] { nameof(MaterialId), nameof(RollNumber) }, IsUnique = true)]
    [Table("AppRolls")]
    public class Roll : FullAuditedAggregateRoot<Guid>
    {
        public int TenantId { get; set; }
        public bool IsActive { get; set; }

        /// <summary>
        /// Material ForeignKey
        /// </summary>
        [Required]
        public Guid MaterialId { get; set; }
        [ForeignKey(nameof(MaterialId))]
        public Material Material { get; set; }

        /// <summary>
        /// Quick Response Code
        /// </summary>
        public string? QR { get; set; }

        #region MassUploadForm

        /// <summary>
        /// Roll Number
        /// </summary>
        [Required]
        public string RollNumber { get; set; }

        /// <summary>
        /// Date Acquired
        /// </summary>
        [Required]
        public DateTime DateAcquired { get; set; }

        /// <summary>
        /// ShelfLife
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public double? ShelfLife { get; set; }

        /// <summary>
        /// RollCount / actual count / total count
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public double? TotalCount { get; set; }

        /// <summary>
        /// Roll Reserved Count
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public double? ReserveCount { get; set; }

        /// <summary>
        /// Roll Available Count
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public double? AvailableCount { get; set; }

        /// <summary>
        /// On Hand Count
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public double? OnHandCount { get; set; }

        /// <summary>
        /// Consume Before Date
        /// </summary>
        [Required]
        public DateTime ConsumeBeforeDate { get; set; }

        /// <summary>
        /// Shading ForeignKey
        /// </summary>
        public int? ShadingId { get; set; }
        [ForeignKey(nameof(ShadingId))]
        public Shading Shading { get; set; }

        /// <summary>
        /// Building or Warehouse
        /// </summary>
        [Required]
        public string BuildingOrWarehouse { get; set; }

        /// <summary>
        /// T-Rack Number
        /// </summary>
        public string TRackNumber { get; set; }

        /// <summary>
        /// Rack
        /// </summary>
        [Required]
        public string Rack { get; set; }

        /// <summary>
        /// For disposal rolls
        /// </summary>
        public bool? IsDisposal { get; set; }

        /// <summary>
        /// Date of Disposal
        /// </summary>
        public DateTime? DisposalDate { get; set; }

        /// <summary>
        /// Purchase Detail Number
        /// </summary>
        public string? PONumber { get; set; }

        /// <summary>
        /// Amount of shipped roll
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public double? ShippedCount { get; set; }

        /// <summary>
        /// Amount of received roll
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public double? ReceivedCount { get; set; }

        /// <summary>
        /// Incoming Count
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public double? IncomingCount { get; set; }

        #endregion

        public virtual List<AdjustRollKey> RollAdjustments { get; set; }

        public virtual List<ReserveCollectionRollKey> RollReservations { get; set; }

        public virtual List<Adjustment> Adjustments { get; set; }

        // Default constructor use by Entity Framework Core don't remove.
        public Roll()
        {
        }

        public Roll(string rollNumber, string pONumber, double? shippedCount, double? receivedCount,double? incomingCount,
            int? shadingId,double? shelfLife, bool? isDisposal, DateTime? disposalDate, double? totalCount,
            DateTime dateAcquired, string buildingOrWarehouse, string tRackNumber, string rack,
            string qr = null )
        {
            QR = qr;
            RollNumber = rollNumber.Trim();
            DateAcquired = dateAcquired;
            ShelfLife = shelfLife;
            TotalCount = totalCount;
            ConsumeBeforeDate = dateAcquired.AddYears(ShelfLife.HasValue ? (int)ShelfLife : 2);
            BuildingOrWarehouse = buildingOrWarehouse;
            TRackNumber = tRackNumber;
            Rack = rack;
            IsDisposal = isDisposal;
            DisposalDate = disposalDate;
            PONumber = pONumber;
            ShippedCount = shippedCount;
            ReceivedCount = receivedCount;
            IncomingCount = incomingCount;
            ShadingId = shadingId;

        }

        public void CalculateOnHandCount(Roll roll)
        {
            roll.OnHandCount = (double)(roll.TotalCount - roll.IncomingCount);
        }


    }

}

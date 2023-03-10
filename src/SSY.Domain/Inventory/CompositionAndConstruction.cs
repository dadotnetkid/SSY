using System;
using SSY.Inventory.Compressions;
using SSY.Inventory.Creases;
using SSY.Inventory.FabricStretches;
using SSY.Inventory.PreparedForPrints;
using SSY.Inventory.PrintRepeats;

namespace SSY.Inventory
{
    /// <summary>
    /// Composition and Construction
    /// </summary>
    [Table("AppCompositionsAndConstructions")]
    public class CompositionAndConstruction : FullAuditedAggregateRoot<Guid>
    {

        public int TenantId { get; set; }
        public bool IsActive { get; set; }

        #region MassUploadForm

        /// <summary>
        /// Content
        /// </summary>
        [Required]
        public string Content { get; set; }

        /// <summary>
        /// Construction
        /// </summary>
        public string Construction { get; set; }

        /// <summary>
        /// Gauge
        /// </summary>
        public string Gauge { get; set; }

        /// <summary>
        /// Recycled ForeignKey
        /// </summary>
        [Required]
        public int RecycledId { get; set; }
        [ForeignKey(nameof(RecycledId))]
        public Recycled Recycled { get; set; }

        /// <summary>
        /// Excess ForeignKey
        /// </summary>
        [Required]
        public int ExcessId { get; set; }
        [ForeignKey(nameof(ExcessId))]
        public Excess Excess { get; set; }

        /// <summary>
        /// PreparedForPrint ForeignKey
        /// </summary>
        [Required]
        public int PreparedForPrintId { get; set; }
        [ForeignKey(nameof(PreparedForPrintId))]
        public PreparedForPrint PreparedForPrint { get; set; }

        /// <summary>
        /// Compression ForeignKey
        /// </summary>
        public int? CompressionId { get; set; }
        [ForeignKey(nameof(CompressionId))]
        public Compression Compression { get; set; }

        /// <summary>
        /// Fabric Stretch ForeignKey
        /// </summary>
        public int? FabricStretchId { get; set; }
        [ForeignKey(nameof(FabricStretchId))]
        public FabricStretch FabricStretch { get; set; }

        /// <summary>
        /// Crease ForeignKey
        /// </summary>
        public int? CreaseId { get; set; }
        [ForeignKey(nameof(CreaseId))]
        public Crease Crease { get; set; }


        /// <summary>
        /// PrintRepeat ForeignKey
        /// </summary>
        public int? PrintRepeatId { get; set; }
        [ForeignKey(nameof(PrintRepeatId))]
        public PrintRepeat PrintRepeat { get; set; }

        /// <summary>
        /// HandFeel ForeignKey
        /// </summary>
        public string HandFeelIds { get; set; }
        //[ForeignKey(nameof(HandFeelId))]
        //public HandFeel HandFeel { get; set; }

        #endregion

        // Default constructor use by Entity Framework Core don't remove.
        public CompositionAndConstruction()
        {
        }

    }
}

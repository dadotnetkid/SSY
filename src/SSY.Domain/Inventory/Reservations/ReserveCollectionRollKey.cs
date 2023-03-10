using System;

namespace SSY.Inventory.Reservations
{
    [Table("AppReserveCollectionRollKeys")]
    public class ReserveCollectionRollKey : Entity<Guid>
    {
        // Default constructor use by Entity Framework Core don't remove.
        public ReserveCollectionRollKey()
        {
        }

        public int TenantId { get; set; }
        public bool IsActive { get; set; }

        /// <summary>
        /// Reservation Foreign Key
        /// </summary>
        [Required]
        public Guid ReservationId { get; set; }
        [ForeignKey(nameof(ReservationId))]
        public Reservation Reservation { get; set; }

        /// <summary>
        /// Collection Foreign Key
        /// </summary>
        [Required]
        public Guid CollectionId { get; set; }
        public string CollectionName { get; set; }
        public string InfluencerName { get; set; }

        /// <summary>
        /// Roll Foreign Key
        /// </summary>
        [Required]
        public Guid RollId { get; set; }
        [ForeignKey(nameof(RollId))]
        public Roll Roll { get; set; }

        public ReserveCollectionRollKey(int tenantId, bool isActive, Guid reservationId, Guid collectionId,string collectionName,
            string influencerName, Guid rollId)
        {
            TenantId = tenantId;
            IsActive = isActive;
            ReservationId = reservationId;
            CollectionId = collectionId;
            CollectionName = collectionName;
            InfluencerName = influencerName;
            RollId = rollId;
        }
    }
}
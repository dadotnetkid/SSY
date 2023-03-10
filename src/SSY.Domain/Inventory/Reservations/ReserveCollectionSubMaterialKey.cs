using System;

namespace SSY.Inventory.Reservations;

[Table("AppReserveCollectionSubMaterialKeys")]
public class ReserveCollectionSubMaterialKey : Entity<Guid>
{
    // Default constructor use by Entity Framework Core don't remove.
    public ReserveCollectionSubMaterialKey()
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
    /// SubMaterial Foreign Key
    /// </summary>
    [Required]
    public Guid SubMaterialId { get; set; }
    [ForeignKey(nameof(SubMaterialId))]
    public SubMaterial SubMaterial { get; set; }

    [Required]
    public Guid CollectionId { get; set; }
    public string CollectionName { get; set; }
    public string InfluencerName { get; set; }


    public ReserveCollectionSubMaterialKey(int tenantId, bool isActive, Guid reservationId, Guid subMaterialId, Guid collectionId,
        string collectionName, string influencerName)
    {
        TenantId = tenantId;
        IsActive = isActive;
        ReservationId = reservationId;
        SubMaterialId = subMaterialId;
        CollectionId = collectionId;
        CollectionName = collectionName;
        InfluencerName = influencerName;
    }
}
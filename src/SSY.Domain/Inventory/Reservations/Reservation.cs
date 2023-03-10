using System;

namespace SSY.Inventory.Reservations;

[Table("AppReservations")]
public class Reservation : FullAuditedAggregateRoot<Guid>
{
    public int TenantId { get; set; }
    public bool IsActive { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public double Count { get; set; }

    [Required]
    public DateTime Date { get; set; }


    // Default constructor use by Entity Framework Core don't remove.
    public Reservation()
    {
    }

    public Reservation(int tenantId, bool isActive, int count, DateTime date)
    {
        TenantId = tenantId;
        IsActive = isActive;
        Count = count;
        Date = date;
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Models
{


    public class MassUploadInventory
    {
        public int TenantId { get; set; }
        public bool IsActive { get; set; }

        [Required]
        public double ActualCount { get; set; }


        public double? MinimumStockLevel { get; set; }

        public double ExpectedCount { get; set; }
        public double ReservedCount { get; set; }
        public double AvailableCount { get; set; }
        public double UsedCount { get; set; }

        [Required]
        public int UnitOfMeasurementId { get; set; }

        [Required]
        public Guid MediaFileId { get; set; }


    }
}
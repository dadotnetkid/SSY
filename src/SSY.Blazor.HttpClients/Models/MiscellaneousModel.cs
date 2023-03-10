using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SSY.Blazor.HttpClients.Models
{


    public class MiscellaneousModel
    {
        public int TenantId { get; set; }
        public bool IsActive { get; set; }

        [Required]
        public int? CareInstructionTypeId { get; set; }

        public int? CareInstructionId { get; set; }

    }
}
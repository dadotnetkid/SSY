using System;
using System.Text.Json.Serialization;


namespace SSY.Companies
{
    /// <summary>
    /// Final Selection List
    /// </summary>
    [Table("AppFinalSelectionLists")]
    public class FinalSelectionList : FullAuditedAggregateRoot<Guid>
    {

        public virtual int TenantId { get; set; }
        public virtual bool IsActive { get; set; }

        [Required]
        public virtual int CompanyId { get; set; }
        [ForeignKey(nameof(CompanyId))]
        public virtual Company Company { get; set; }

        [Required]
        public virtual Guid MediaFileId { get; set; }
        [ForeignKey(nameof(MediaFileId))]
        public virtual MediaFile MediaFile { get; set; }

        [Required]
        [JsonPropertyName("addedBy")]
        public string AddedBy { get; set; }

        // Default constructor use by Entity Framework Core don't remove.
        protected FinalSelectionList()
        {
        }

        public FinalSelectionList(int tenantId, bool isActive, int companyId, string addedBy)
        {
            TenantId = tenantId;
            IsActive = isActive;
            CompanyId = companyId;
            AddedBy = addedBy;
        }


    }
}


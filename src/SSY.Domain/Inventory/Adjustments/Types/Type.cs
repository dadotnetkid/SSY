namespace SSY.Inventory.Adjustments.Types
{
    /// <summary>
    /// Action
    /// </summary>
    [Table("AppAdjustTypes")]
    public class Type : FullAuditedAggregateRoot<int>
    {

        /// <summary>
        /// Id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override int Id { get; protected set; }

        public int TenantId { get; set; }
        public bool IsActive { get; set; }

        /// <summary>
        /// Label
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Order Number is use for sorting
        /// </summary>
        public int OrderNumber { get; set; }

        // Default Constructor use by Entity Framework Core don't remove.
        public Type()
        { }

        public Type(int id, int tenantId, bool isActive, string label, string value, int orderNumber)
        {
            Id = id;
            TenantId = tenantId;
            IsActive = isActive;
            Label = label;
            Value = value;
            OrderNumber = orderNumber;
        }
    }
}

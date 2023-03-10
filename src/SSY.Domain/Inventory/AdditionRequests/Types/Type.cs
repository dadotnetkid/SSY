using System;



namespace SSY.Inventory.AdditionRequests.Types
{
    [Table("AppAdditionRequestTypes")]
    public class Type : FullAuditedEntity<int>
    {
        public virtual int TenantId { get; set; }
        public virtual bool IsActive { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override int Id { get; protected set; }

        /// <summary>
        /// Label
        /// </summary>
        public virtual string Label { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        public virtual string Value { get; set; }

        /// <summary>
        /// Order Number is use for sorting
        /// </summary>
        public virtual int OrderNumber { get; set; }

        public Type()
        {
        }

        public Type(int tenantId, bool isActive, int id, string label, string value, int orderNumber)
        {
            TenantId = tenantId;
            IsActive = isActive;
            Id = id;
            Label = label;
            Value = value;
            OrderNumber = orderNumber;
        }
    }
}


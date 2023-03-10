using System;
using System.ComponentModel.DataAnnotations.Schema;



namespace SSY.Companies.Types
{
    [Table("AppCompanyTypes")]
    public class Type : FullAuditedAggregateRoot<int>
    {
        public int TenantId { get; set; }
        public bool IsActive { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override int Id { get; protected set; }

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

        public Type()
        {
        }

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


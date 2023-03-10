using System;
using System.Collections.Generic;
using SSY.Inventory.Categories;
using SSY.Products.CustomFilters;
using Volo.Abp.MultiTenancy;

namespace SSY.Inventory.Materials.Types
{
    /// <summary>
    /// Material type
    /// Example: Activewear, Sweats, Jersey, Knitwear, Mesh, Windbreaker
    /// </summary>
    [Table("AppMaterialTypes")]
    public class Type : FullAuditedAggregateRoot<int>, IMultiTenant, IIsActive
    {
        public virtual Guid? TenantId { get; protected set; }
        public virtual bool IsActive { get; protected set; }

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

        /// <summary>
        /// Short Code
        /// </summary>
        [Required]
        public virtual string ShortCode { get; set; }

        /// <summary>
        /// Category ForeignKey
        /// </summary>
        public virtual int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }

        /// <summary>
        /// Category ForeignKey
        /// </summary>
        public virtual int? UnitOfMeasurementId { get; set; }
        //[ForeignKey(nameof(UnitOfMeasurementId))]
        //public virtual UnitOfMeasurement UnitOfMeasurement { get; set; }

        /// <summary>
        /// Sales Percentage
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public virtual double? SalesPercentage { get; set; }

        public virtual List<TypePanelKey> Panels { get; set; }

        public virtual void AddMaterialTypePanel(TypePanelKey materialTypePanel)
        {
            Panels.Add(materialTypePanel);
        }

        // Default constructor use by Entity Framework Core don't remove.
        public Type()
        {
        }

        public Type(int id, string label, string value, int orderNumber, string shortCode, int categoryId, double? salesPercentage, int? unitOfMeasurementId)
        {
            IsActive = true;
            Id = id;
            Label = label;
            Value = value;
            OrderNumber = orderNumber;
            ShortCode = shortCode;
            CategoryId = categoryId;
            SalesPercentage = salesPercentage;
            UnitOfMeasurementId = unitOfMeasurementId;
        }
    }
}

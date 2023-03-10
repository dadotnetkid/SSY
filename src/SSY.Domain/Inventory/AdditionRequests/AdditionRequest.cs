using System;
using SSY.Inventory.Categories;
using SSY.Inventory.Colors;
using Type = SSY.Inventory.AdditionRequests.Types.Type;

namespace SSY.Inventory.AdditionRequests
{
    /// <summary>
    /// AdditionalRequest
    /// </summary>
    [Table("AppAdditionRequests")]
    public class AdditionRequest : FullAuditedEntity<Guid>
    {
        public int TenantId { get; set; }
        public bool IsActive { get; set; }

        /// <summary>
        /// Type: Sublimation, Purchase
        /// </summary>
        public int TypeId { get; set; }
        [ForeignKey(nameof(TypeId))]
        public Type Type { get; set; }

        /// <summary>
        /// Category: Greige, Fabric
        /// </summary>
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        /// <summary>
        /// Material Type
        /// </summary>
        public int MaterialTypeId { get; set; }
        [ForeignKey(nameof(MaterialTypeId))]
        public Type MaterialType { get; set; }

        /// <summary>
        /// Item Code
        /// </summary>
        public string ItemCode { get; set; }

        /// <summary>
        /// Color Code
        /// </summary>
        public string ColorCode { get; set; }

        /// <summary>
        /// Color Group
        /// </summary>
        public int ColorId { get; set; }
        [ForeignKey(nameof(ColorId))]
        public Color Color { get; set; }

        /// <summary>
        /// TCX Code: Pantone
        /// </summary>
        public string TCXCode { get; set; }

        /// <summary>
        /// Required Yardage
        /// </summary>
        public double RequiredYardage { get; set; }

        public string AddedBy { get; set; }

        public Guid CollectionId { get; set; }

        public string CollectionName { get; set; }

        public string Influencers { get; set; }

        public AdditionRequestStatus Status { get; set; }

        public AdditionRequest()
        {
        }

        public AdditionRequest(int tenantId, bool isActive, int typeId, int categoryId, int materialTypeId, string itemCode,
            string colorCode, int colorId, string tcxCode, double requiredYardage)
        {
            TenantId = tenantId;
            IsActive = isActive;
            TypeId = typeId;
            CategoryId = categoryId;
            MaterialTypeId = materialTypeId;
            ItemCode = itemCode;
            ColorCode = colorCode;
            ColorId = colorId;
            TCXCode = tcxCode;
            RequiredYardage = requiredYardage;
        }

    }
}


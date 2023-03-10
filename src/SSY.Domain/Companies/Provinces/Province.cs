using System;
using SSY.Products.CustomFilters;
using Volo.Abp.MultiTenancy;

namespace SSY.Companies.Provinces
{
    /// <summary>
    /// Province
    /// </summary>
    [Table("AppProvinces")]
    public class Province : FullAuditedAggregateRoot<int>, IMultiTenant, IIsActive
    {
        public virtual Guid? TenantId { get; protected set; }
        public virtual bool IsActive { get; set; }


        /// <summary>
        /// Code
        /// </summary>
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// CountryCode
        /// </summary>
        [Required]
        public string CountryCode { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Order Number is use for sorting
        /// </summary>
        [Required]
        public int OrderNumber { get; set; }

        // Default constructor use by Entity Framework Core don't remove.
        public Province()
        {
        }

        internal Province(bool isActive, string code, string countryCode, string name, int orderNumber)
        {
            IsActive = isActive;
            Code = code;
            CountryCode = countryCode;
            Name = name;
            OrderNumber = orderNumber;
        }
    }
}

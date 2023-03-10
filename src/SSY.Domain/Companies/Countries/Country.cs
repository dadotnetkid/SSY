using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace SSY.Companies.Countries
{
    /// <summary>
    /// Country
    /// </summary>
    [Table("AppCountries")]
    public class Country : FullAuditedAggregateRoot<int>
    {
        public int TenantId { get; set; }
        public bool IsActive { get; set; }

        /// <summary>
        /// Code
        /// </summary>
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Mobile Prefix
        /// </summary>
        [Required]
        public string MobilePrefix { get; set; }

        /// <summary>
        /// Order Number is use for sorting
        /// </summary>
        [Required]
        public int OrderNumber { get; set; }

        // Default constructor use by Entity Framework Core don't remove.
        public Country()
        {
        }

        public Country(int tenantId, bool isActive, string code, string name, string mobilePrefix, int orderNumber)
        {
            TenantId = tenantId;
            IsActive = isActive;
            Code = code;
            Name = name;
            MobilePrefix = mobilePrefix;
            OrderNumber = orderNumber;
        }
    }
}

namespace SSY.Companies.Cities
{
    /// <summary>
    /// City
    /// </summary>
    [Table("AppCities")]
    public class City : FullAuditedAggregateRoot<int>
    {
        public int TenantId { get; set; }
        public bool IsActive { get; set; }

        /// <summary>
        /// Label
        /// </summary>
        [Required]
        public string ProvinceCode { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Order Number is use for sorting
        /// </summary>
        [Required]
        public int OrderNumber { get; set; }

        // Default constructor use by Entity Framework Core don't remove.
        public City()
        {
        }

        public City(int tenantId, bool isActive, string provinceCode, string name, int orderNumber)
        {
            TenantId = tenantId;
            IsActive = isActive;
            ProvinceCode = provinceCode;
            Name = name;
            OrderNumber = orderNumber;
        }
    }
}

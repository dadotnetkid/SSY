using System.Collections.Generic;

namespace SSY.Companies
{
    [Table("AppCompanies")]
    public class Company : FullAuditedAggregateRoot<int>
    {
        /// <summary>
        /// Id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
                public override int Id { get; protected set; }

        public int TenantId { get; set; }
        public bool IsActive { get; set; }

        /// <summary>
        /// First 3 char of company name(Short Code) + country code + first 3 char of city + iterating number (SupplierTotalCount + 1)
        /// Example: TIE-CN-DON-01
        /// </summary>
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// Short Code
        /// </summary>
        [Required]
        public string ShortCode { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Website
        /// </summary>
        [StringLength(200, ErrorMessage = "This field is too long.")]
        public string? Website { get; set; }

        /// <summary>
        /// Address 1
        /// </summary>
        [Required]
        public string Address1 { get; set; }

        /// <summary>
        /// Address 2
        /// </summary>
        public string? Address2 { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        [Required]
        public string Country { get; set; }
        //public int CountryId { get; set; }
        //[ForeignKey(nameof(CountryId))]
        //public Country Country { get; set; }

        /// <summary>
        /// Province
        /// </summary>
        [Required]
        public string Province { get; set; }
        //public int ProvinceId { get; set; }
        //[ForeignKey(nameof(ProvinceId))]
        //public Province Province { get; set; }

        /// <summary>
        /// City
        /// </summary>
        [Required]
        public string City { get; set; }
        //public int CityId { get; set; }
        //[ForeignKey(nameof(CityId))]
        //public City City { get; set; }

        /// <summary>
        /// ZipCode
        /// </summary>
        [Required]
        public string ZipCode { get; set; }

        #region Financial Information

        /// <summary>
        /// Bank Name
        /// </summary>
        public string? BankName { get; set; }

        /// <summary>
        /// Account Number
        /// </summary>
        public string? AccountNumber { get; set; }

        /// <summary>
        /// Account Name
        /// </summary>
        public string? AccountName { get; set; }

        /// <summary>
        /// Swift
        /// </summary>
        public string? Swift { get; set; }

        /// <summary>
        /// Account Address
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Company Type
        /// </summary>
        public List<CompanyTypeKey> CompanyTypeKeys { get; set; }

        /// <summary>
        /// Excess Supplier
        /// </summary>
        public bool IsExcessSupplier { get; set; }

        /// <summary>
        /// Excess Reminder
        /// </summary>
        public List<CompanyExcessReminderKey> CompanyExcessReminderKeys { get; set; }

        /// <summary>
        /// Material Type
        /// </summary>
        public List<CompanyMaterialTypeKey> CompanyMaterialTypeKeys { get; set; }

        #endregion

        /// <summary>
        /// Contact Persons
        /// </summary>
        public List<CompanyContactPersonKey> ContactPersons { get; set; }

        public void AddContactPerson(CompanyContactPersonKey contactPerson)
        {
            ContactPersons.Add(contactPerson);
        }

        public void AddCompanyTypeKey(CompanyTypeKey companyTypeKey)
        {
            CompanyTypeKeys.Add(companyTypeKey);
        }

        public void AddCompanyExcessReminderKey(CompanyExcessReminderKey companyExcessReminderKey)
        {
            CompanyExcessReminderKeys.Add(companyExcessReminderKey);
        }

        public void AddCompanyMaterialTypeKeyn(CompanyMaterialTypeKey companyMaterialTypeKey)
        {
            CompanyMaterialTypeKeys.Add(companyMaterialTypeKey);
        }

        // Default constructor use by Entity Framework Core don't remove.
        public Company()
        {
        }

        public Company(int id, int tenantId, bool isActive, string code, string shortCode, string name, string website, string address1, string? address2, string country, string city, string province, string zipCode, string? bankName,
                        string? accountNumber, string? accountName, string? swift, string? address, bool isExcessSupplier)
        {
            Id = id;
            TenantId = tenantId;
            IsActive = isActive;
            Code = code;
            ShortCode = shortCode;
            Name = name;
            Website = website;
            Address1 = address1;
            Address2 = address2;
            Country = country;
            City = city;
            Province = province;
            ZipCode = zipCode;
            BankName = bankName;
            AccountNumber = accountNumber;
            AccountName = accountName;
            Swift = swift;
            Address = address;
            IsExcessSupplier = isExcessSupplier;
        }

        public void GenerateCode(int companyTotalCount)
        {
            if (Id > 0)
            {
                //var lastPart = Code.Split('-').Last();
                Code = $"{ShortCode}-{Country}-{City.Substring(0, 3)}-{companyTotalCount}";
            }
            else
                Code = $"{ShortCode}-{Country}-{City.Substring(0, 3)}-{companyTotalCount + 1}";
        }
    }
}
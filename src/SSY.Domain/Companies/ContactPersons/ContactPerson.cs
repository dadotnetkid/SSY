

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace SSY.Companies.ContactPersons
{
    /// <summary>
    /// Contact Person
    /// </summary>
    [Table("AppContactPersons")]
    public class ContactPerson : FullAuditedAggregateRoot<int>
    {
        /// <summary>
        /// Id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override int Id { get; protected set; }

        public int TenantId { get; set; }
        public bool IsActive { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Position
        /// </summary>
        public string? Position { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Mobile Number
        /// </summary>
        public string? Telephone { get; set; }

        /// <summary>
        /// Telephone
        /// </summary>
        public string? MobileNumber { get; set; }

        // Default constructor use by Entity Framework Core don't remove.
        public ContactPerson()
        {
        }

        public ContactPerson(int id, int tenantId, bool isActive, string name, string? position, string email, string? telephone, string? mobileNumber)
        {
            Id = id;
            TenantId = tenantId;
            IsActive = isActive;
            Name = name;
            Position = position;
            Email = email;
            Telephone = telephone;
            MobileNumber = mobileNumber;
        }
    }
}
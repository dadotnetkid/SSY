using System;

namespace SSY.UserDetails.Addresses
{
    public class Address : FullAuditedAggregateRoot<Guid>
    {
        public Address(string address2)
        {
            Address2 = address2;
        }
        public Address(string address1, string address2, string city, string state, string country, string zipCode, string provinceCode, AddressType addressType)
        {
            Address1 = address1;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
            ProvinceCode = provinceCode;
            AddressType = addressType;
            Address2 = address2;
        }

        //foreignKey to UserDetail
        public virtual Guid UserId { get; set; }
        public virtual string Address1 { get; protected set; }
        public virtual string Address2 { get; protected set; }
        public virtual string City { get; protected set; }
        public virtual string State { get; protected set; }
        public virtual string Country { get; protected set; }
        public virtual string ZipCode { get; protected set; }
        public virtual string ProvinceCode { get; protected set; }
        public virtual AddressType AddressType { get; protected set; }
        public UserDetail UserDetail { get; set; }
    }


}

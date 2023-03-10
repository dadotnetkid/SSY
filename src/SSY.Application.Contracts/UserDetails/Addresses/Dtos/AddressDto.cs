using System;
using SSY.Enums;
using SSY.UserDetails.Dtos;
using Volo.Abp.Application.Dtos;

namespace SSY.UserDetails.Addresses.Dtos
{
    public class AddressDto:EntityDto<Guid>
    {
        public virtual Guid UserId { get; set; }
        public string Address1 { get;  set; }
        public string Address2 { get; set; }
        public string City { get;  set; }
        public string State { get;  set; }
        public string Country { get;  set; }
        public string ZipCode { get;  set; }
        public string ProvinceCode { get;  set; }
        public AddressType AddressType { get;  set; }
        public UserDetailDto UserDetail { get; set; }
    }
    public class CreateAddressDto:EntityDto<Guid>
    {
        public virtual Guid UserId { get; set; }
        public string Address1 { get;  set; }
        public string Address2 { get; set; }
        public string City { get;  set; }
        public string State { get;  set; }
        public string Country { get;  set; }
        public string ZipCode { get;  set; }
        public string ProvinceCode { get;  set; }
        public AddressType AddressType { get;  set; }
        public UserDetailDto UserDetail { get; set; }
        
    }
    public class UpdateAddressDto:EntityDto<Guid>
    {
        public virtual Guid UserId { get; set; }
        public string Address1 { get;  set; }
        public string Address2 { get; set; }
        public string City { get;  set; }
        public string State { get;  set; }
        public string Country { get;  set; }
        public string ZipCode { get;  set; }
        public string ProvinceCode { get;  set; }
        public AddressType AddressType { get;  set; }
        public UserDetailDto UserDetail { get; set; }
    }
}

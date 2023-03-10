using System;
using System.Collections.Generic;
using System.Linq;
using SSY.Enums;
using SSY.UserDetails.Addresses.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace SSY.UserDetails.Dtos;

public class CreateUserDetailDto : EntityDto<Guid>
{
    public virtual Guid? UserId { get; set; }
    public  string Gender { get;  set; }
    public string Instagram { get; set; }
    public string Facebook { get; set; }
    public string Youtube { get; set; }
    public string Twitter { get; set; }
    public string Tiktok { get; set; }
    public string Pinterest { get; set; }
    public virtual ICollection<CreateAddressDto> Addresses { get; set; } = new List<CreateAddressDto>()
    {
        new CreateAddressDto()
        {
            AddressType=AddressType.Resindential,
            Id=Guid.NewGuid(),
        },
        new CreateAddressDto(){
            AddressType=AddressType.Sampling,
            Id=Guid.NewGuid(),
        },
    };
    public string WhatsApp { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Surname { get; set; }
    public string FirstName { get; set; }
    public bool? Activewear { get; set; }
    public bool? Knitwear { get; set; }
}
using System;
using System.Collections.Generic;
using SSY.UserDetails.Addresses.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace SSY.UserDetails.Dtos;

public class UpdateUserDetailDto : EntityDto<Guid>
{
    public virtual Guid? UserId { get; set; }
    public string Gender { get; set; }
    public string Instagram { get; set; }
    public string Facebook { get; set; }
    public string Youtube { get; set; }
    public string Twitter { get; set; }
    public string Tiktok { get; set; }
    public string Pinterest { get; set; }
    public bool? Activewear { get; set; }
    public bool? Knitwear { get; set; }
    public IdentityUserDto AppUser { get; set; }
    public virtual ICollection<AddressDto> Addresses { get; set; }
}
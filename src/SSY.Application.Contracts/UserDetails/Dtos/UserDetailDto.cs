using System;
using System.Collections.Generic;
using SSY.UserDetails.Addresses.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace SSY.UserDetails.Dtos
{
    public class UserDetailDto : EntityDto<Guid>
    {
        public virtual Guid? UserId { get; set; }
        public string Gender { get; set; }  
        public string InfluencerStatus { get; set; }
        public string CollectionStatus { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string Youtube { get; set; }
        public string Twitter { get; set; }
        public string Tiktok { get; set; }
        public string Pinterest { get; set; }
        public IdentityUserDto AppUser { get; set; } = new();
        public virtual ICollection<AddressDto> Addresses { get; set; } = new List<AddressDto>();
        public string PhoneNumber { get; set; }
        public string WhatsApp { get; set; }
        public bool? Activewear { get; set; }
        public bool? Knitwear { get; set; }
    }
}

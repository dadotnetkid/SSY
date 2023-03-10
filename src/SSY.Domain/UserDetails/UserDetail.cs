using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SSY.Influencers.Agencies;
using SSY.Influencers.Banks;
using SSY.Influencers.Messagings.Folders;
using SSY.Influencers.RevenueShares;
using SSY.Influencers.Sizings;
using SSY.UserDetails.Addresses;
using Volo.Abp.Identity;
using static Volo.Abp.Identity.Settings.IdentitySettingNames;

namespace SSY.UserDetails
{

    public class UserDetail : FullAuditedAggregateRoot<Guid>
    {
        public UserDetail(Guid? userId, string firstName, string lastName, string gender, string instagram, string facebook, string youtube, string twitter, string tiktok, string pinterest, string phoneNumber, string whatsApp, bool? activewear, bool? knitwear, int activeWearQuantityForecast, int knitWearQuantityForecast)
        {
            UserId = userId;
            Gender = gender;
            Instagram = instagram;
            Facebook = facebook;
            Youtube = youtube;
            Twitter = twitter;
            Tiktok = tiktok;
            Pinterest = pinterest;
            PhoneNumber = phoneNumber;
            WhatsApp = whatsApp;
            Activewear = activewear;
            Knitwear = knitwear;
            ActiveWearQuantityForecast = activeWearQuantityForecast;
            KnitWearQuantityForecast = knitWearQuantityForecast;
            FirstName = firstName;
            LastName = lastName;
        }
        public virtual Guid? UserId { get; protected set; }
        public virtual string FirstName { get; protected set; }
        public virtual string LastName { get; protected set; }
        public virtual string Gender { get; protected set; }
        public virtual string Instagram { get; protected set; }
        public virtual string Facebook { get; protected set; }
        public virtual string Youtube { get; protected set; }
        public virtual string Twitter { get; protected set; }
        public virtual string Tiktok { get; protected set; }
        public virtual string Pinterest { get; protected set; }

        public virtual string PhoneNumber { get; protected set; }
        public virtual string WhatsApp { get; protected set; }
        public bool? Activewear { get; protected set; }
        public bool? Knitwear { get; protected set; }
        public int ActiveWearQuantityForecast { get; protected set; }
        public int KnitWearQuantityForecast { get; protected set; }

        public virtual IdentityUser AppUser { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual Sizing Sizing { get; set; }
        public virtual ICollection<Agent> Agents { get; set; }
        public virtual ICollection<Bank> Banks { get; set; }
        public virtual ICollection<RevenueShare> RevenueShares { get; set; }
        public virtual ICollection<InfluencersInFolder> InfluencersInFolders { get; set; }

       

    }
}
/* [Table("AppUserDetails")]
 public class UserDetail : FullAuditedAggregateRoot<Guid>
 {
     public virtual int TenantId { get; set; }
     public virtual bool IsActive { get; set; }

     public virtual long? UserId { get; set; }
     [ForeignKey(nameof(UserId))]
     //public User User { get; set; }

     public string RoleNames { get; set; }

     /// <summary>
     /// Company ForeignKey
     /// </summary>
     public virtual int? CompanyId { get; set; }
     [ForeignKey(nameof(CompanyId))]
     public Company Company { get; set; }

     [Required]
     public virtual string Name { get; set; }

     [Required]
     public virtual string Surname { get; set; }
     public virtual string FullName { get { return $"{Name} {Surname}"; } }

     [Required]
     [EmailAddress]
     public string EmailAddress { get; set; }
     public string PhoneNumber { get; set; }
     public string Position { get; set; }
     public string Remarks { get; set; }

     [Column(TypeName = "decimal(18,2)")]
     public double? ProductQuantityForecast { get; set; }
     public string Collections { get; set; }

     public string Instagram { get; set; }
     public string Tiktok { get; set; }
     public string Facebook { get; set; }
     public string Youtube { get; set; }
     public string Twitter { get; set; }
     public Status Status { get; set; }
     public string ActivewearDesignResponse { get; set; }
     public string KnitwearDesignResponse { get; set; }

     protected UserDetail()
     {
     }

     public UserDetail(int tenantId, bool isActive, long? userId, int? companyId, string name, string surname,
         string emailAddress, string phoneNumber, string position, string remarks, double? productQuantityForecast, string collections,
         string instagram, string tiktok, string facebook, string youtube, string twitter, Status status)
     {
         TenantId = tenantId;
         IsActive = isActive;
         UserId = userId;
         CompanyId = companyId;
         Name = name;
         Surname = surname;
         EmailAddress = emailAddress;
         PhoneNumber = phoneNumber;
         Position = position;
         Remarks = remarks;
         ProductQuantityForecast = productQuantityForecast;
         Collections = collections;
         Instagram = instagram;
         Tiktok = tiktok;
         Facebook = facebook;
         Youtube = youtube;
         Twitter = twitter;
         Status = status;
     }
 }*/
using SSY.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SSY.Influencer.Financials.RevenueShares.Dto
{
    public class RevenueShareDto : FullAuditedEntityDto<Guid>
    {
        public Guid? UserId { get; set; }
        public RevenueShareType RevenueShareType { get; set; }
        public decimal From { get; set; }
        public decimal To { get; set; }
        public decimal Percentage { get; set; }
        public string Note { get; set; }
        public bool IsEdit { get; set; }
    }
    public class CreateRevenueShareDto : FullAuditedEntityDto<Guid>
    {
        public Guid? UserId { get; set; }
        public RevenueShareType RevenueShareType { get; set; }
        public decimal From { get; set; }
        public decimal To { get; set; }
        public decimal Percentage { get; set; }
        public string Note { get; set; }
    }
    public class UpdateRevenueShareDto : FullAuditedEntityDto<Guid>
    {
        public Guid? UserId { get; set; }
        public RevenueShareType RevenueShareType { get; set; }
        public decimal From { get; set; }
        public decimal To { get; set; }
        public decimal Percentage { get; set; }
        public string Note { get; set; }
    }
}

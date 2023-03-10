using SSY.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SSY.Influencer.Financials.Banks.Dto
{
    public class BankDto : FullAuditedEntityDto<Guid>
    {
        public Guid? UserId { get; set; }
        public BankType BankType { get; set; }
        public string EmailAddress { get; set; }
        public bool EditDetail { get; set; }
    }
    public class CreateBankDto
    {
        public Guid? UserId { get; set; }
        public BankType BankType { get; set; }
        public string EmailAddress { get; set; }
    }
    public class UpdateBankDto
    {
        public Guid? UserId { get; set; }
        public BankType BankType { get; set; }
        public string EmailAddress { get; set; }
    }
}

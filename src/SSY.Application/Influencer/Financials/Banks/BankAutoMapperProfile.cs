using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SSY.Influencer.Financials.Banks.Dto;
using SSY.Influencers.Banks;

namespace SSY.Influencer.Financials.Banks
{
    public class BankAutoMapperProfile:Profile
    {
        public BankAutoMapperProfile()
        {
            CreateMap<Bank, BankDto>().ReverseMap();
            CreateMap<Bank, UpdateBankDto>().ReverseMap();
            CreateMap<Bank, CreateBankDto>().ReverseMap();
            CreateMap<BankDto, CreateBankDto>().ReverseMap();
            CreateMap<BankDto, UpdateBankDto>().ReverseMap();
        }
    }
}

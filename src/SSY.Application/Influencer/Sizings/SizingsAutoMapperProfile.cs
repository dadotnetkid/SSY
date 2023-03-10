using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SSY.Influencer.Sizings.Dto;
using SSY.Influencers.Sizings;

namespace SSY.Influencer.Sizings
{
    public class SizingsAutoMapperProfile:Profile
    {
        public SizingsAutoMapperProfile()
        {
            CreateMap<Sizing, SizingsDto>();
            CreateMap<Sizing, CreateSizingsDto>();
            CreateMap<CreateSizingsDto,Sizing>();
            CreateMap<SizingsDto, CreateSizingsDto>();
            CreateMap<SizingsDto, UpdateSizingsDto>();
            CreateMap<Sizing, UpdateSizingsDto>().ReverseMap();
        }
    }
}

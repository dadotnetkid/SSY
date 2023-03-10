using AutoMapper;
using SSY.Influencer.Messagings.Messages.Dto;
using SSY.Influencers.Messagings.Messages;

namespace SSY.Influencer.Messagings.Messages;

public class MessageAutoMapperProfile:Profile
{
    public MessageAutoMapperProfile()
    {
        CreateMap<Message, MessageDto>().ReverseMap();
        CreateMap<Message, CreateMessageDto>().ReverseMap();
        CreateMap<Message, UpdateMessageDto>().ReverseMap();
    }
}
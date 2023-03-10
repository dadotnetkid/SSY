using AutoMapper;

namespace SSY.Influencer.Blazor;

public class BookBlazorAutoMapperProfile : Profile
{
    public BookBlazorAutoMapperProfile()
    {
        CreateMap<BookDto, CreateUpdateBookDto>();
        CreateMap<AuthorDto, UpdateAuthorDto>();

    }
}


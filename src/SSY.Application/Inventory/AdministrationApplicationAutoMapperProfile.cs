using AutoMapper;
using SSY.Authors;
using SSY.Books;

namespace SSY.Inventory;

public class AdministrationApplicationAutoMapperProfile : Profile
{
    public AdministrationApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        #region Tutorial AutoMapperProfile

        CreateMap<Book, InfluencerDto>();
        CreateMap<CreateUpdateBookDto, Book>();

        CreateMap<Author, AuthorDto>();
        CreateMap<Author, AuthorLookupDto>();
        


        #endregion

    }
}

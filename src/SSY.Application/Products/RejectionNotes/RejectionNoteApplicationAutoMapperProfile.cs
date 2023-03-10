using AutoMapper;
using SSY.Products.RejectionNotes.Dtos;

namespace SSY.Products.RejectionNotes;

public class RejectionNoteApplicationAutoMapperProfile : Profile
{
    public RejectionNoteApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */


        CreateMap<RejectionNote, RejectionNoteDto>();
        CreateMap<CreateRejectionNoteDto, RejectionNote>();

        CreateMap<RejectionNoteMediaFile, RejectionNoteMediaFileDto>();
        CreateMap<CreateRejectionNoteMediaFileDto, RejectionNoteMediaFile>()
            .ForMember(x => x.MediaFile, opt => opt.Ignore());
    }
}
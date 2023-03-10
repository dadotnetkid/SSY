using AutoMapper;
using SSY.Products.MediaFiles.Dtos;

namespace SSY.Products.MediaFiles;

public class MediaFileApplicationMapProfile : Profile
{
    public MediaFileApplicationMapProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<MediaFile, MediaFileDto>();
        CreateMap<CreateMediaFileDto, MediaFile>();
        CreateMap<UpdateMediaFileDto, MediaFile>();
    }
}
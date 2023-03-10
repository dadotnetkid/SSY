using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SSY.Influencer.Messagings.Folders.Dto;
using SSY.Influencers.Messagings.Folders;

namespace SSY.Influencer.Messagings.Folders
{
    public class FolderAutoMapperProfile:Profile
    {
        public FolderAutoMapperProfile()
        {
            CreateMap< Folder, CreateFolderDto>();
            CreateMap<CreateFolderDto, Folder>();
            CreateMap<Folder,FolderDto>();
            CreateMap<FolderDto, Folder>();
            CreateMap< Folder,UpdateFolderDto>();
            CreateMap<UpdateFolderDto,Folder>();

        }
    }
}

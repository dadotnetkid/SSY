using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SSY.Influencer.Messagings.Folders.Dto
{
    public class FolderDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }
    }
    public class CreateFolderDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }
    }
    public class UpdateFolderDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }
    }

}

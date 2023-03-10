using System;
using SSY.Products.MediaFiles.Dtos;

namespace SSY.Products.RejectionNotes.Dtos;

public class RejectionNoteMediaFileDto
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    public MediaFileDto MediaFile { get; set; }
}
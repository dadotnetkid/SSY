using System;

namespace SSY.Products.RejectionNotes.Dtos;

public class CreateRejectionNoteMediaFileDto
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    public Guid RejectionNoteId { get; set; }
    public Guid MediaFileId { get; set; }
}
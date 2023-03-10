﻿using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace SSY.Products.RejectionNotes.Dtos;

public class UpdateRejectionNoteDto : EntityDto<Guid>
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    public Guid ProductId { get; set; }
    public int MediaFileCategoryId { get; set; }
    public bool IsInternal { get; set; }

    public string Notes { get; set; }
    public string UserName { get; set; }

    public List<UpdateRejectionNoteMediaFileDto> MediaFiles { get; set; }
}
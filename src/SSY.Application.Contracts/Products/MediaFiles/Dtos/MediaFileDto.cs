using System;
using SSY.Enums;
using Volo.Abp.Application.Dtos;

namespace SSY.Products.MediaFiles.Dtos;

public class MediaFileDto : EntityDto<Guid>
{
    public Guid? TenantId { get; set; }
    public bool IsActive { get; set; }

    public int CategoryId { get; set; }

    /// <summary>
    /// Media File Type
    /// Example: Unidentified, Image, Video, Audio, File
    /// </summary>
    public MediaFileType MediaFileType { get; set; }

    /// <summary>
    /// File name after hashing.
    /// </summary>
    public string StorageFileName { get; set; }

    /// <summary>
    /// File location 
    /// </summary>
    public string FilePath { get; set; }

    /// <summary>
    /// Gets the raw Content-Disposition header of the uploaded file. 
    /// </summary>
    public string ContentDisposition { get; set; }

    /// <summary>
    /// Gets the raw Content-Type header of the uploaded file. 
    /// </summary>
    public string ContentType { get; set; }

    /// <summary>
    /// Gets the file name from the Content-Disposition header.
    /// </summary>
    public string FileName { get; set; }

    /// <summary>
    /// Gets the form field name from the Content-Disposition header.
    /// </summary>
    public string Name { get; set; }
}
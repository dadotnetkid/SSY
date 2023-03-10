using System;

namespace SSY.MediaFiles
{
    /// <summary>
    /// Media File
    /// </summary>
    [Table("AppMediaFiles")]
    public class MediaFile : FullAuditedEntity<Guid>
    {
        public int TenantId { get; set; }
        public bool IsActive { get; set; }

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


        // Default constructor use by Entity Framework Core don't remove.
        public MediaFile()
        {
        }

        public MediaFile(MediaFileType mediaFileType, string contentDisposition,
            string storageFileName, string filePath, string contentType, string fileName, string name)
        {
            MediaFileType = mediaFileType;
            StorageFileName = storageFileName;
            FilePath = filePath;
            ContentDisposition = contentDisposition;
            FileName = fileName;
            Name = name;
            ContentType = contentType;
        }
    }
}

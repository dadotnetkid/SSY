using System;
using SSY.Products.CustomFilters;
using SSY.Enums;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace SSY.Products.MediaFiles
{
    public class MediaFile : FullAuditedAggregateRoot<Guid>, IMultiTenant, IIsActive
    {
        public virtual Guid? TenantId { get; protected set; }
        public virtual bool IsActive { get; protected set; }

        public virtual int CategoryId { get; protected set; }

        /// <summary>
        /// Media File Type
        /// Example: Unidentified, Image, Video, Audio, File
        /// </summary>
        public virtual MediaFileType MediaFileType { get; protected set; }

        /// <summary>
        /// File name after hashing.
        /// </summary>
        public virtual string StorageFileName { get; protected set; }

        /// <summary>
        /// File location 
        /// </summary>
        public virtual string FilePath { get; protected set; }

        /// <summary>
        /// Gets the raw Content-Disposition header of the uploaded file. 
        /// </summary>
        public virtual string ContentDisposition { get; protected set; }

        /// <summary>
        /// Gets the raw Content-Type header of the uploaded file. 
        /// </summary>
        public virtual string ContentType { get; protected set; }

        /// <summary>
        /// Gets the file name from the Content-Disposition header.
        /// </summary>
        public virtual string FileName { get; protected set; }

        /// <summary>
        /// Gets the form field name from the Content-Disposition header.
        /// </summary>
        public virtual string Name { get; protected set; }

        // Default constructor use by Entity Framework Core don't remove.
        protected MediaFile()
        {
        }

        internal MediaFile(int categoryId, MediaFileType mediaFileType, string contentDisposition,
            string storageFileName, string filePath, string contentType, string fileName, string name)
        {
            CategoryId = categoryId;
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


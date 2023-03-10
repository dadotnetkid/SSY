using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SSY.Products.MediaFiles.Dtos;
using SSY.Products.Shopifies;
using SSY.Products.Shopifies.Dtos;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace SSY.Products.MediaFiles
{
    public class MediaFileAppService : CrudAppService<MediaFile, MediaFileDto, Guid, PagedAndSortedResultRequestDto, CreateMediaFileDto, UpdateMediaFileDto>, IMediaFileAppService
    {
        public MediaFileAppService(IRepository<MediaFile, Guid> repository) : base(repository)
        {
        }

        protected override async Task<IQueryable<MediaFile>> CreateFilteredQueryAsync(PagedAndSortedResultRequestDto input)
        {
            try
            {
                return await base.CreateFilteredQueryAsync(input);
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                throw new UserFriendlyException($"{ex.Message}{innerException}");
            }
        }

        public override Task<MediaFileDto> CreateAsync(CreateMediaFileDto input)
        {
            try
            {
                return base.CreateAsync(input);
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                throw new UserFriendlyException($"{ex.Message}{innerException}");
            }
        }

        public override Task<MediaFileDto> UpdateAsync(Guid id, UpdateMediaFileDto input)
        {
            try
            {
                return base.UpdateAsync(id, input);
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                throw new UserFriendlyException($"{ex.Message}{innerException}");
            }
        }

        public async Task<List<MediaFileDto>> ListUploadAsync(List<CreateMediaFileDto> input)
        {
            try
            {
                List<MediaFileDto> mediaFiles = new();
                input.ForEach(x =>
                {
                    var newMediaFile = ObjectMapper.Map<CreateMediaFileDto, MediaFile>(x);

                    var entity = Repository.InsertAsync(newMediaFile, autoSave: true).Result;

                    var mediaFileDto = ObjectMapper.Map<MediaFile, MediaFileDto>(entity);
                    mediaFiles.Add(mediaFileDto);
                });

                await CurrentUnitOfWork.SaveChangesAsync();

                return mediaFiles;
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                throw new UserFriendlyException($"{ex.Message}{innerException}");
            }
        }

        #region File Download

        public async Task<string> FileDownload(Guid MediaFileId)
        {
            try
            {
                var mediafile = await Repository.GetAsync(MediaFileId);
                byte[] bytes;
                var memory = new MemoryStream();
                using (var stream = new FileStream($"../{mediafile.FilePath}", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    await stream.CopyToAsync(memory);
                    bytes = memory.ToArray();
                }
                memory.Position = 0;
                string base64 = Convert.ToBase64String(bytes);

                return base64;
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                throw new UserFriendlyException($"{ex.Message}{innerException}");
            }
        }

        #endregion
    }
}
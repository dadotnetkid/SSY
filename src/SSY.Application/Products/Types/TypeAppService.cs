using SSY.Products.Options.Dtos;
using SSY.Products;
using SSY.Products.Options;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using SSY.Products.Types.Dtos;
using Microsoft.EntityFrameworkCore;
using SSY.Products.Shopifies.Dtos;
using Volo.Abp;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using SSY.Products.Dtos;
using Volo.Abp.ObjectMapping;
using SSY.Products.Types;

namespace SSY.Products.Types
{
    public class TypeAppService : CrudAppService<Type, TypeDto, int, PagedAndSortedResultRequestDto, CreateTypeDto, UpdateTypeDto>, ITypeAppService
    {
        public TypeAppService(IRepository<Type, int> repository) : base(repository)
        {
        }


        protected override async Task<IQueryable<Type>> CreateFilteredQueryAsync(PagedAndSortedResultRequestDto input)
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

        protected override async Task<List<TypeDto>> MapToGetListOutputDtosAsync(List<Type> entities)
        {
            try
            {
                var query = await ReadOnlyRepository.GetQueryableAsync();

                var ids = entities.Select(x => x.Id);

                var types = query
                    .Where(x => ids.Any(e => e == x.Id))
                    .ToList();

                List<TypeDto> result = new();

                types.ForEach(x =>
                {
                    result.Add(ObjectMapper.Map<Type, TypeDto>(x));
                });

                return result;
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                throw new UserFriendlyException($"{ex.Message}{innerException}");
            }
        }

        protected override async Task<TypeDto> MapToGetOutputDtoAsync(Type entity)
        {
            try
            {
                var query = await ReadOnlyRepository.GetQueryableAsync();

                var type = query
                    .Where(x => x.Id == entity.Id)
                    .Include(x => x.Options)
                        .ThenInclude(x => x.Option)
                            .ThenInclude(x => x.Options)
                                .ThenInclude(x => x.Options)
                                    .ThenInclude(x => x.Options)
                    .FirstOrDefault();

                var typeDto = ObjectMapper.Map<Type, TypeDto>(type);
                typeDto.Options = typeDto.Options.Where(x => x.OptionParentId == null || (x.OptionParentId != null && !string.IsNullOrWhiteSpace(x.MaterialIds))).ToList();

                return typeDto;
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                throw new UserFriendlyException($"{ex.Message}{innerException}");
            }
        }

        public override Task<TypeDto> CreateAsync(CreateTypeDto input)
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

        public override Task<TypeDto> UpdateAsync(int id, UpdateTypeDto input)
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

        #region Option

        public async Task UpdateOptionAsync(List<UpdateTypeOptionDto> input)
        {
            try
            {
                var query = await ReadOnlyRepository.WithDetailsAsync();

                var type = query.IgnoreQueryFilters()
                    .Where(x => x.Id == input.FirstOrDefault().TypeId)
                    .Include(x => x.Options)
                        .ThenInclude(x => x.Option)
                    .FirstOrDefault();

                type.AddOptions(ObjectMapper.Map<List<UpdateTypeOptionDto>, List<TypeOption>>(input));
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

        #region Base Size Spec

        public async Task UpdateBaseSizeSpecAsync(List<UpdateBaseSizeSpecDto> input)
        {
            try
            {
                var query = await ReadOnlyRepository.WithDetailsAsync();

                var type = query.IgnoreQueryFilters()
                    .Where(x => x.Id == input.FirstOrDefault().TypeId)
                    .Include(x => x.BaseSizeSpecs)
                        .ThenInclude(x => x.MediaFile)
                    .FirstOrDefault();

                type.AddBaseSizeSpecs(ObjectMapper.Map<List<UpdateBaseSizeSpecDto>, List<BaseSizeSpec>>(input));
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

        #region OBJ Block Pattern

        public async Task UpdateObjBlockPatternAsync(List<UpdateOBJBlockPatternDto> input)
        {
            try
            {
                var query = await ReadOnlyRepository.WithDetailsAsync();

                var type = query.IgnoreQueryFilters()
                    .Where(x => x.Id == input.FirstOrDefault().TypeId)
                    .Include(x => x.ObjBlockPatterns)
                        .ThenInclude(x => x.MediaFile)
                    .FirstOrDefault();

                type.AddObjBlockPatterns(ObjectMapper.Map<List<UpdateOBJBlockPatternDto>, List<ObjBlockPattern>>(input));
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
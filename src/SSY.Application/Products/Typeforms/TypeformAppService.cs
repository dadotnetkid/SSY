using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SSY.Products.Typeforms.Dtos;
using SSY.Products.Typeforms.Dtos.Response;
using SSY.Products.Typeforms.Request;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace SSY.Products.Typeforms;

public class TypeformAppService :
    CrudAppService<Typeform, TypeformDto, Guid, PagedAndSortedResultRequestDto, CreateTypeformDto, UpdateTypeformDto>, ITypeformAppService
{
    public TypeformAppService(IRepository<Typeform, Guid> repository) : base(repository)
    {
    }

    public async Task CreateActivewearDesignQuestionnaireAsync(string response)
    {
        await CreateAsync(new() { Type = "ActivewearDesignQuestionnaire", Response = response });
    }

    public async Task CreateKnitwearDesignQuestionnaireAsync(string response)
    {
        await CreateAsync(new() { Type = "KnitwearDesignQuestionnaire", Response = response });
    }

    public async Task PostWebHook(PayloadDto response)
    {
        var dto = response.FormResponse.Definition.Fields.Select(c => new ResponseDto()
        {
            Type = c.Type,
            Title = c.Title,
            Answer = response.FormResponse.Answers.Where(a => a.Field.Id == c.Id),
        }).ToList();
        var influencerEmail = dto.FirstOrDefault(c => c.Type == "email").Answer.FirstOrDefault().Email;
        await UpdateExistingTypeForm(influencerEmail, response);


        await CreateAsync(new()
        {
            IsActive = true,
            Type = response.FormResponse.Definition.Title,
            Email = influencerEmail,
            Response = JsonConvert.SerializeObject(dto)
        });
    }

    private async Task UpdateExistingTypeForm(string influencerEmail, PayloadDto payloadDto)
    {

        if (!(await Repository.AnyAsync(c => c.Email == influencerEmail && c.IsActive && c.Type == payloadDto.FormResponse.Definition.Title))) return;
        var typeForm = await Repository.FirstOrDefaultAsync(c => c.Email == influencerEmail && c.IsActive && c.Type == payloadDto.FormResponse.Definition.Title);
        if (typeForm == null) return;
        typeForm.SetActive(false);
        await Repository.UpdateAsync(typeForm, true);
    }

    public async Task<TypeFormResponseDto> PostResponseByInfluencerAndType(TypeFormRequestDto item)
    {
        var query = await Repository.GetQueryableAsync();
        var typeForm = query.Where(c => item.Email.Contains(c.Email) && c.IsActive == true);
        var grpTypeForm = typeForm.GroupBy(c => c.Type).Select(c => c.Key).ToList();

        if (!string.IsNullOrEmpty(item.Type))
        {
            typeForm = typeForm.Where(c => c.Type == item.Type);
        }



        return new TypeFormResponseDto()
        {
            Types = grpTypeForm,
            TypeForms = typeForm.ToList().Select(c => new InfluencerDto()
            {
                Type = c.Type,
                Response = JsonConvert.DeserializeObject<List<ResponseDto>>(c.Response),
                DateCreated = c.CreationTime
            }).ToList()
        };
    }


}
using System.Threading.Tasks;
using SSY.Enums;
using SSY.Influencer.Financials.Banks;
using SSY.Influencer.Financials.Banks.Dto;
using SSY.Influencer.Financials.RevenueShares;
using SSY.Influencer.Financials.RevenueShares.Dto;
using Volo.Abp.ObjectMapping;

namespace SSY.Blazor.Pages.Influencers.Components.Financials;

public partial class Index
{
    [Parameter] public Guid Id { get; set; }
    public string Module = "Financial";
    public string ModuleMessage = "";
    public string ModuleChange = "";
    public string SelectedComponent { get; set; } = "bankdetails";
    [Inject] public IBankAppService BankAppService { get; set; }
    [Inject] public IRevenueShareAppService RevenueShareAppService { get; set; }
    [Inject] public IObjectMapper ObjectMapper { get; set; }
    public BankDto BankDetail { get; set; } = new();
    public List<RevenueShareDto> RevenueShares { get; set; } = new();
    Task SetSelectedComponent(string selectedComponent)
    {
        SelectedComponent = selectedComponent;
        StateHasChanged();
        return Task.CompletedTask;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            BankDetail = (await BankAppService.GetByUserId(Id)) ?? new();
            RevenueShares = (await RevenueShareAppService.GetListByUserId(Id));
            StateHasChanged();
        }
    }




    public async Task AddEditBank()
    {
        BankDetail.UserId = Id;
        BankDetail.BankType = BankType.Paypal;
        if (BankDetail.Id == Guid.Empty)
        {
            await BankAppService.CreateAsync(ObjectMapper.Map<BankDto, CreateBankDto>(BankDetail));
        }
        else
        {
            await BankAppService.UpdateAsync(BankDetail.Id, ObjectMapper.Map<BankDto, UpdateBankDto>(BankDetail));
        }
    }

    public async Task AddEditRevenueShare(RevenueShareDto revenueShareDto)
    {
        revenueShareDto.UserId = Id;
        if (revenueShareDto.Id == Guid.Empty)
        {
            await RevenueShareAppService.CreateAsync(
                ObjectMapper.Map<RevenueShareDto, CreateRevenueShareDto>(revenueShareDto));
        }
        else
        {
            await RevenueShareAppService.UpdateAsync(revenueShareDto.Id,
                ObjectMapper.Map<RevenueShareDto, UpdateRevenueShareDto>(revenueShareDto));
        }
    }
}


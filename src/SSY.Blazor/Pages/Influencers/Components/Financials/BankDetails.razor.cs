using SSY.Influencer.Financials.RevenueShares.Dto;

namespace SSY.Blazor.Pages.Influencers.Components.Financials
{
    public partial class BankDetails
    {
        [CascadingParameter(Name = "MainPage")] public Index MainPage { get; set; }

        private async Task EnableEdit()
        {
            if (!MainPage.BankDetail.EditDetail)
                MainPage.BankDetail.EditDetail = true;
            else
            {

                await MainPage.AddEditBank();
                MainPage.BankDetail.EditDetail = false;
            }
            StateHasChanged();
        }

        private async Task EnableEditRevenueShare(RevenueShareDto revenueShareDto)
        {
            if (!revenueShareDto.IsEdit)
            {
                revenueShareDto.IsEdit = true;
            }
            else
            {
                await MainPage.AddEditRevenueShare(revenueShareDto);
                revenueShareDto.IsEdit = false;
            }
            StateHasChanged();
        }
    }
}

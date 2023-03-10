namespace SSY.Blazor.Pages.Influencers.Shared.NavInfluencerDetail
{
    public partial class NavInfluencerDetail
    {
        [Parameter] public Guid Id { get; set; }

        public void SetId(Guid id)
        {
            Id = id;
            StateHasChanged();
        }
    }
}

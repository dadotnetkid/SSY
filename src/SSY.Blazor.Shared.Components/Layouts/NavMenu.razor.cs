namespace SSY.Blazor.Shared.Components.Layouts
{
    public partial class NavMenu
    {
        public NavMenu()
        {
        }

       
        public string Role { get; set; }


        // protected override async Task OnAfterRenderAsync(bool firstRender)
        // {
        //     var session = await SessionStorage.GetAsync<UserSession>("userSession");

        //     if (firstRender)
        //     {
        //         Role = session.Value.RoleName;
        //         StateHasChanged();
        //     }
        // }
    }
}

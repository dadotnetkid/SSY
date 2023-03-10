using SSY.Influencer.Messagings.Folders;

namespace SSY.Blazor.Pages.Influencers.Components.Messaging
{
    public partial class AddEditFolder
    {
        private Modal modalRef;

        [Parameter]
        public EventCallback OnClose { get; set; }
        [Parameter] public Folders Folders { get; set; }
        [Inject] IFolderAppService FolderAppService { get; set; }
        public string FolderName { get; set; }


        public async Task Show()
        {
            await modalRef.Show();
        }

        private async Task OnClosing(ModalClosingEventArgs arg)
        {
            if (!arg.Cancel)
            {
                await OnClose.InvokeAsync();
            }
        }

        private async Task HideModal()
        {
            await modalRef.Hide();
        }

        private async Task SaveChanges()
        {
            await FolderAppService.CreateAsync(new()
            {
                Name = FolderName,
                UserId = Folders.MainPage.Id
            });
            FolderName = string.Empty;
            
            await modalRef.Hide();
            StateHasChanged();
        }
    }
}

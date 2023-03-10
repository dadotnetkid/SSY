using SSY.Influencer.Messagings.Folders;
using SSY.Influencer.Messagings.Folders.Dto;
using SSY.Influencer.Messagings.Messages;
using SSY.Influencer.Messagings.Messages.Dto;

namespace SSY.Blazor.Pages.Influencers.Components.Messaging;

public partial class Messaging
{
    [Parameter] public Guid Id { get; set; }
    public string Module = "Messaging";
    public string ModuleMessage = "";
    public string ModuleChange = "";
    public string SelectedComponent { get; set; } = "internal";
    [Inject] public IFolderAppService FolderAppService { get; set; }
    [Inject] public IMessageAppService MessageService { get; set; }
    public List<FolderDto> FolderList { get; set; } = new();
    public IList<MessageDto> MessageList { get; set; } = new List<MessageDto>();
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
            await RefreshFolder();

        }
    }


    public async Task RefreshFolder()
    {
        this.FolderList = await FolderAppService.GetAllFoldersByUserId(Id);
        if (FolderList.Any())
        {
            await RefreshMessages(FolderList.FirstOrDefault().Id);
        }
        StateHasChanged();
    }

    public async Task RefreshMessages(Guid folderId)
    {
        this.MessageList = await MessageService.GetMessagesByFolderId(folderId);
        StateHasChanged();
    }


}


using Blazorise.RichTextEdit;
using SSY.Influencer.Messagings.Folders.Dto;
using SSY.Influencer.Messagings.Messages.Dto;

namespace SSY.Blazor.Pages.Influencers.Components.Messaging;

public partial class Folders
{
    string EmailTags = "";
    private AddEditFolder addEditFolder;
    private RichTextEdit richTextEditRef;
    public FolderDto SelectedFolder { get; set; }
    public MessageDto SelectedMessage { get; set; } = new();
    public string Title { get; set; }
    [CascadingParameter(Name = "MainPage")] public Messaging MainPage { get; set; }


    private async Task ShowAddEditModal()
    {
        await addEditFolder.Show();
    }

    private async Task OnModalClose()
    {
        await MainPage.RefreshFolder();
    }

    private async Task OnSelectFolder(FolderDto folderDto)
    {
        SelectedFolder = folderDto;
        await MainPage.RefreshMessages(folderDto.Id);
    }



    private async Task OnSave()
    {
        if (SelectedMessage .Id ==Guid.Empty)
        {
            await MainPage.MessageService.CreateAsync(new()
            {
                FolderId = SelectedFolder.Id,
                MessageBody = await richTextEditRef.GetHtmlAsync(),
                Title = Title
            });
        }
        else
        {
            await MainPage.MessageService.UpdateAsync(SelectedMessage.Id, new()
            {
                FolderId = SelectedFolder.Id,
                MessageBody = await richTextEditRef.GetHtmlAsync(),
                Title = Title
            });
        }
        await MainPage.RefreshMessages(SelectedFolder.Id);
    }

    private void SetSelectedMessage(MessageDto messageDto)
    {
        SelectedMessage = messageDto;
        richTextEditRef.SetHtmlAsync(messageDto.MessageBody);
        Title = messageDto.Title;
        StateHasChanged();
    }


    private async Task OnNewMessage()
    {
        SelectedMessage = new();
        Title = string.Empty;
        await richTextEditRef.ClearAsync();
        StateHasChanged();
    }

    private void OnContentChanged(object obj)
    {
        
    }
}


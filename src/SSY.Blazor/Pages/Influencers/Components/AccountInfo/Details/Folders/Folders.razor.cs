using System.Threading.Tasks;

namespace SSY.Administration.Blazor.Shared.Influencer.Components.Details.Folders;

public partial class Folders
{
    string EmailTags = "";
    string SelectedMessage = "";
    
         private string EmailTag(string component)
        {
           EmailTags = component;
            return "";
        }
         private string Inbox(string component)
        {
           SelectedMessage = component;
            return "";
        }
}

    
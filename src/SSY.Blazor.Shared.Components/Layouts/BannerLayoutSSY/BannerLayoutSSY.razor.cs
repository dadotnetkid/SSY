// using Microsoft.AspNetCore.Components;
// using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
// using System.Text.Json;
// using System.Text.Json.Serialization;
// using System.Threading.Tasks;
// using System.Net.Http;
// using System.Collections.Generic;
// using SSY.Web.Blazor.Core.Models;
// using Microsoft.JSInterop;


// namespace SSY.Web.Blazor.Shared.Layouts.BannerLayout
// {
//     public partial class BannerLayout
//     {
//         public BannerLayout()
//         {
//         }


//         [Inject]
//         public ProtectedSessionStorage SessionStorage { get; set; }
//         public string Role { get; set; }
//         public string UserName { get; set; }

//         protected override async Task OnAfterRenderAsync(bool firstRender)
//         {
//             var session = await SessionStorage.GetAsync<UserSession>("userSession");

//             if (firstRender)
//             {
//                 Role = session.Value.RoleName;
//                 UserName = $"{session.Value.FirstName} {session.Value.SecondName}";
//                 StateHasChanged();
//             }
//         }


//     }


// }


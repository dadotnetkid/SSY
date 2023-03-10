using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Text.Json;


namespace SSY.Blazor.Shared.Components.Layouts
{
    public partial class InfluencerMainLayout
    {
        public string UserName { get; set; }
        public bool IsAdmin { get; set; }

        private Task Logout()
        {
            return Task.CompletedTask;
        }
    }
}

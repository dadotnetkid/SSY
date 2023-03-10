using System.Threading.Tasks;
using SSY.MultiTenancy;
using Volo.Abp.Identity.Blazor;
using Volo.Abp.SettingManagement.Blazor.Menus;
using Volo.Abp.TenantManagement.Blazor.Navigation;
using Volo.Abp.UI.Navigation;

namespace SSY.Influencer.Blazor.Menus;

public class AdministrationMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<SSYResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                AdministrationMenus.Home,
                l["Influencer"],
                "/dashboard",
                icon: "fas fa-user",
                order: 0
            )
        );

        // context.Menu.AddItem(
        //     new ApplicationMenuItem(
        //         "BooksStore",
        //         l["Menu:BookStore"],
        //         icon: "fa fa-book"
        //         ).AddItem(
        //         new ApplicationMenuItem(
        //             "BooksStore.Books",
        //             l["Menu:Books"],
        //             url: "/books"
        //             )
        //         ));

        // if (await context.IsGrantedAsync(AdministrationPermissions.Authors.Default))
        // {
        //     context.Menu.Items
        //         .Find(x => x.Name == "BooksStore")
        //         .AddItem(new ApplicationMenuItem(
        //         "BooksStore.Authors",
        //         l["Menu:Authors"],
        //         url: "/authors"
        //     ));
        // }

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenus.GroupName, 3);

        //return Task.CompletedTask;
    }
}

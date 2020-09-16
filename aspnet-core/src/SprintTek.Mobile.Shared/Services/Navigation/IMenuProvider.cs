using System.Collections.Generic;
using MvvmHelpers;
using SprintTek.Models.NavigationMenu;

namespace SprintTek.Services.Navigation
{
    public interface IMenuProvider
    {
        ObservableRangeCollection<NavigationMenuItem> GetAuthorizedMenuItems(Dictionary<string, string> grantedPermissions);
    }
}
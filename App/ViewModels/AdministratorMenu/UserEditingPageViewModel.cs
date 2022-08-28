using App.Models;
using App.Models.FromDatabase;
using ReactiveUI;
using Splat;

namespace App.ViewModels.AdministratorMenu;

public class UserEditingPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "userEditing";
    public IScreen HostScreen { get; }
    private ApplicationContext Db { get; set; }

    public UserEditingPageViewModel(User currentUser, IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();
        
        
    }
}
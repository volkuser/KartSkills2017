using App.Models;
using ReactiveUI;
using Splat;

namespace App.ViewModels.AdministratorMenu;

public class UserAddingPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "userAdding";
    public IScreen HostScreen { get; }
    private ApplicationContext Db { get; set; }

    public UserAddingPageViewModel(IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();
        
        
    }
}
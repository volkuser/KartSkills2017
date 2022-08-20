using App.Models;
using ReactiveUI;
using Splat;

namespace App.ViewModels;

public class InventoryPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "inventory";
    public IScreen HostScreen { get; }
    private ApplicationContext Db;

    public InventoryPageViewModel(IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();
    }
}
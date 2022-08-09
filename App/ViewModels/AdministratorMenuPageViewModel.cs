using ReactiveUI;
using Splat;

namespace App.ViewModels;

public class AdministratorMenuPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "administratorMenu";
    public IScreen HostScreen { get; }
        
    public bool VisibleBtnBack { get; } = false;

    public AdministratorMenuPageViewModel(IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
    }
}
using ReactiveUI;
using Splat;

namespace App.ViewModels;

public class CoordinatorMenuPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "coordinatorMenu";
    public IScreen HostScreen { get; }
        
    public bool VisibleBtnBack { get; } = false;

    public CoordinatorMenuPageViewModel(IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
    }
}
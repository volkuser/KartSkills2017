using ReactiveUI;
using Splat;

namespace App.ViewModels;

public class RacerMenuPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "racerMenu";
    public IScreen HostScreen { get; }
        
    public bool VisibleBtnBack { get; } = false;

    public RacerMenuPageViewModel(IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
    }
}
using ReactiveUI;
using Splat;

namespace App.ViewModels;

public class RacerMenuPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "racerMenu";
    public IScreen HostScreen { get; }

    public RacerMenuPageViewModel(IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
    }
}
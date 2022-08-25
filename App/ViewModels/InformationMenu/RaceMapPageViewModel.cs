using ReactiveUI;
using Splat;

namespace App.ViewModels.InformationMenu;

public class RaceMapPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "raceMap";
    public IScreen HostScreen { get; }

    public RaceMapPageViewModel(IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
    }
}
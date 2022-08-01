using ReactiveUI;
using Splat;

namespace App.ViewModels;

public class SponsorOfRacersPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "/sponsorOfRacers";
    public IScreen HostScreen { get; }
    public bool VisibleBtnBack { get; } = true;

    public SponsorOfRacersPageViewModel(IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
    }
}    

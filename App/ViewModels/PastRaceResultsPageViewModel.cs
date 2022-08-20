using App.Models;
using ReactiveUI;
using Splat;

namespace App.ViewModels;

public class PastRaceResultsPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "pastRaceResults";
    public IScreen HostScreen { get; }
    private ApplicationContext Db;

    public PastRaceResultsPageViewModel(IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
    }
}
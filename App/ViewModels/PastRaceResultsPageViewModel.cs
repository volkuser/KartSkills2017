using App.Models;
using ReactiveUI;

namespace App.ViewModels;

public class PastRaceResultsPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "racerRegistration";
    public IScreen HostScreen { get; }
    private ApplicationContext Db;

    public PastRaceResultsPageViewModel(IScreen? screen = null)
    {
        
    }
}
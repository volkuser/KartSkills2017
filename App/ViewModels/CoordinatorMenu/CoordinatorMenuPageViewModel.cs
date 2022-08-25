using System.Windows.Input;
using ReactiveUI;
using Splat;

namespace App.ViewModels.CoordinatorMenu;

public class CoordinatorMenuPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "coordinatorMenu";
    public IScreen HostScreen { get; }
    
    private ICommand OnClickBtnRacers { get; set; }
    private ICommand OnClickBtnSponsors { get; set; }

    public CoordinatorMenuPageViewModel(IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();

        OnClickBtnRacers = ReactiveCommand.Create(container.OpnRacerControlPage);
        OnClickBtnSponsors = ReactiveCommand.Create(container.OpnSponsorViewPage);
    }
}
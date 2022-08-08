using System.Windows.Input;
using ReactiveUI;
using Splat;

namespace App.ViewModels;

public class MainMenuPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "/mainMenu";
    public IScreen HostScreen { get; }
    
    public bool VisibleBtnBack { get; } = false;

    private ICommand OnClickOpnSponsorOfRacersPage { get; set; }

    public MainMenuPageViewModel(IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        
        OnClickOpnSponsorOfRacersPage = ReactiveCommand.Create(() => container.OpnSponsorOfRacersPage());
    }
}

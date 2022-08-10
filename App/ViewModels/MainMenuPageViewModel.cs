using System.Windows.Input;
using ReactiveUI;
using Splat;

namespace App.ViewModels;

public class MainMenuPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "/mainMenu";
    public IScreen HostScreen { get; }

    private ICommand OnClickBtnSponsorOfRacersPage { get; set; }
    private ICommand OnClickBtnDetailedInformationPage { get; set; }
    private ICommand OnClickBtnOpnAuthorizationMenuPage { get; set; }

    public MainMenuPageViewModel(IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        
        OnClickBtnSponsorOfRacersPage = ReactiveCommand.Create(() => container.OpnSponsorOfRacersPage());
        OnClickBtnDetailedInformationPage = ReactiveCommand.Create(() => container.OpnDetailedInformationPage());
        OnClickBtnOpnAuthorizationMenuPage = ReactiveCommand.Create(() => container.OpnAuthorizationMenuPage());
    }
}

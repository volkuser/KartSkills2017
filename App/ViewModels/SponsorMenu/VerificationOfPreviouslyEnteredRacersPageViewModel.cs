using System.Windows.Input;
using ReactiveUI;
using Splat;

namespace App.ViewModels.SponsorMenu;

public class VerificationOfPreviouslyEnteredRacersPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "verificationOfPreviouslyEnteredRacers";
    public IScreen HostScreen { get; }
    
    private ICommand OnClickBtnYes { get; set; }
    private ICommand OnClickBtnNo { get; set; }
    
    public VerificationOfPreviouslyEnteredRacersPageViewModel(IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();

        OnClickBtnYes = ReactiveCommand.Create(container.OpnAuthorizationMenuPage);
        OnClickBtnNo = ReactiveCommand.Create(container.OpnRacerRegistrationPage);
    }
}
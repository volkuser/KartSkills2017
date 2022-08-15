using System.Windows.Input;
using ReactiveUI;
using Splat;

namespace App.ViewModels;

public class ConfirmationOfRacerRegistrationPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "confirmationOfRacerRegistrationPage";
    public IScreen HostScreen { get; }

    private ICommand OnClickBtnOK { get; set; }

    public ConfirmationOfRacerRegistrationPageViewModel(IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();

        OnClickBtnOK = ReactiveCommand.Create(() => container.Back());
    }
}
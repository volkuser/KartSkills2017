using System.Windows.Input;
using App.Models;
using App.Views.Pages;
using ReactiveUI;
using Splat;

namespace App.ViewModels;

public class RacerMenuPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "racerMenu";
    public IScreen HostScreen { get; }
    
    private ICommand OnClickBtnContacts { get; set; }
    private ICommand OnClickBtnRaceRegistrationPage { get; set; }

    private User CurrentUser { get; set; }

    public RacerMenuPageViewModel(User user, IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();

        CurrentUser = user;
        OnClickBtnContacts = ReactiveCommand.CreateFromTask(async
            => container.OpnInformationAboutContactsWindow(CurrentUser.Email));
        OnClickBtnRaceRegistrationPage = ReactiveCommand.Create(() => container.OpnRaceRegistrationPage(user));
    }
}
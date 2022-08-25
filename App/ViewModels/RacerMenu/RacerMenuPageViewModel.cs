using System;
using System.Threading.Tasks;
using System.Windows.Input;
using App.Models.FromDatabase;
using ReactiveUI;
using Splat;

namespace App.ViewModels.RacerMenu;

public class RacerMenuPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "racerMenu";
    public IScreen HostScreen { get; }
    
    private ICommand OnClickBtnContacts { get; set; }
    private ICommand OnClickBtnRaceRegistrationPage { get; set; }
    private ICommand OnClickBtnProfileEditingPage { get; set; }
    private ICommand OnClickBtnMyResultsPage { get; set; }
    private ICommand OnClickBtnMySponsors { get; set; }

    private User? CurrentUser { get; set; }

    public RacerMenuPageViewModel(User? user, IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();

        CurrentUser = user;
        OnClickBtnContacts = ReactiveCommand.CreateFromTask(_
            => (CurrentUser.Email != null 
                   ? Task.FromResult(container.OpnInformationAboutContactsWindow(CurrentUser.Email)) : null) 
               ?? throw new InvalidOperationException());
        OnClickBtnRaceRegistrationPage = ReactiveCommand.Create(() => container.OpnRaceRegistrationPage(user));
        OnClickBtnProfileEditingPage = ReactiveCommand.Create(() => container.OpnProfileEditingPage(user));
        OnClickBtnMyResultsPage = ReactiveCommand.Create(() => container.OpnMyResultsPage(user));
        OnClickBtnMySponsors = ReactiveCommand.Create(() => container.OpnMySponsorsPage(user));
    }
}
using System.Windows.Input;
using App.Models;
using App.Models.FromDatabase;
using ReactiveUI;
using Splat;

namespace App.ViewModels;

public class ConfirmationOfSponsorshipPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "confirmationOfSponsorship";
    public IScreen HostScreen { get; }
    
    private ICommand OnClickBtnBack { get; set; }

    private string AmountInDollars { get; set; }
    private string ViewOfRacer { get; set; }
    private string NameOfFund { get; set; }

    public ConfirmationOfSponsorshipPageViewModel(IPageNavigation container, string amountInDollars, Racer racer, 
        string nameOfFund, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();

        AmountInDollars = amountInDollars;
        ViewOfRacer = racer.First_Name + " " + racer.Last_Name + " " + racer.ID_Country;
        NameOfFund = nameOfFund;
        OnClickBtnBack = ReactiveCommand.Create(container.Back);
    }
}
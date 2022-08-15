using System.Collections.ObjectModel;
using System.Windows.Input;
using App.Models;
using ReactiveUI;
using Splat;

namespace App.ViewModels;

public class RaceRegistrationPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "raceRegistration";
    public IScreen HostScreen { get; }
    private ApplicationContext Db;

    private ICommand OnClickBtnCancel { get; set; }
    private ICommand OnClickBtnRegistration { get; set; }

    // choice of race type
    private bool Race2AndHalfKm { get; set; }
    private bool Race4Km { get; set; }
    private bool Race6AndHalfKm { get; set; }

    // sponsorship's details
    private ObservableCollection<Charity> Charities { get; set; }
    private Charity Charity { get; set; }
    private string Password { get; set; }
    
    // choice of kit variants
    private bool VariantA { get; set; }
    private bool VariantB { get; set; }
    private bool VariantC { get; set; }
    
    // registration contribution
    private string RegistrationConfirmation { get; set; }

    public RaceRegistrationPageViewModel(User currentUser, IPageNavigation? container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();

        Charities = new(Db.Charities);
        
        OnClickBtnCancel = ReactiveCommand.Create(() => container.Back());
        OnClickBtnRegistration = ReactiveCommand.Create(() => Registration());
    }

    private void Registration()
    {
        
    }
}
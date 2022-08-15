using System;
using System.Collections.ObjectModel;
using System.Linq;
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
    private ICommand OnClickBtnInformation { get; set; }

    // choice of race type
    private bool _race2AndHalfKm;
    private bool Race2AndHalfKm
    {
        get => _race2AndHalfKm;
        set
        {
            _race2AndHalfKm = value;
            ChangeConfirmation(value, 25);
        }
    }

    private bool _race4Km;
    private bool Race4Km
    {
        get => _race4Km;
        set
        {
            _race4Km = value;
            ChangeConfirmation(value, 40);
        }
    }

    private bool _race6AndHalfKm;
    private bool Race6AndHalfKm
    {
        get => _race6AndHalfKm;
        set
        {
            _race6AndHalfKm = value;
            ChangeConfirmation(value, 65);
        }
    }

    // sponsorship's details
    private ObservableCollection<Charity> Charities { get; set; }
    private Charity Charity { get; set; }
    private string SponsorshipTarget { get; set; }
    private int SponsorshipTargetInInt
    {
        get 
        {
            try { return Int32.Parse(SponsorshipTarget); }
            catch (Exception) { return 0; }
        }
    } 
    
    // choice of kit variants
    private bool _variantA;
    private bool VariantA
    {
        get => _variantA;
        set
        {
            _variantA = value;
            ChangeConfirmation(value, 0);
        }
    }

    private bool _variantB;
    private bool VariantB
    {
        get => _variantB;
        set
        {
            _variantB = value;
            ChangeConfirmation(value, 30);
        }
    }

    private bool _variantC;
    private bool VariantC
    {
        get => _variantC;
        set
        {
            _variantC = value;
            ChangeConfirmation(value, 50);
        }
    }
    
    // registration contribution
    private int Confirmation { get; set; }
    private string RegistrationConfirmation { get; set; } = "$ 0";
    
    private ObservableCollection<Registration> Registrations { get; set; }

    public RaceRegistrationPageViewModel(User currentUser, IPageNavigation? container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();

        Charities = new(Db.Charities);

        Registrations = new(Db.Registrations);
        
        OnClickBtnCancel = ReactiveCommand.Create(() => container.Back());
        OnClickBtnRegistration = ReactiveCommand.Create(() => Registration(Db, Registrations, currentUser, 
            Confirmation, Charity, SponsorshipTargetInInt, container));
        OnClickBtnInformation = ReactiveCommand.CreateFromTask(async
            => container.OpnInformationAboutCharityWindow(Charity));
    }

    private void Registration(ApplicationContext db, ObservableCollection<Registration> registrations, User user, 
        int cost, Charity? charity, int sponsorshipTarget, IPageNavigation container)
    {
        if ((VariantA || VariantB || VariantC) && (Race2AndHalfKm || Race4Km || Race6AndHalfKm)
            && charity != null && sponsorshipTarget != null && (sponsorshipTarget > 0))
        {
            Racer racer = db.Racers.FirstOrDefault(x => x.First_Name.Equals(user.First_Name)
                                                        && x.Last_Name.Equals(user.Last_Name));
            Registration registration = new Registration()
            {
                Racer = racer,
                Registration_Date = DateTime.Today,
                ID_Registration_Status = 1, // registered
                Cost = cost,
                Charity = charity,
                SponsorshipTarget = sponsorshipTarget
            };
            registrations.Add(registration);
            db.Registrations.Add(registration);
            db.SaveChanges();
            container.OpnConfirmationOfRacerRegistrationPage();
        }
    }

    private void ChangeConfirmation(bool condition, int addition)
    {
        Confirmation += condition ? addition : -addition;
        RegistrationConfirmation = $"$ {Confirmation}";
    }
}
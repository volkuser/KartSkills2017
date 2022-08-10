using System;
using System.Windows.Input;
using System.Collections.ObjectModel;
using App.Models;
using ReactiveUI;
using Splat;

namespace App.ViewModels;

public class SponsorOfRacersPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "/sponsorOfRacers";
    public IScreen HostScreen { get; }
    private ApplicationContext Db;
    
    // commands
    private ICommand OnClickAmountPlus { get; set; }
    private ICommand OnClickAmountMinus { get; set; }
    private ICommand OnClickPay { get; set; }
    private ICommand OnClickCancel { get; set; }

    // only display properties
    private string? _nameOfFund;
    private string? _amountInDollars;
    
    // only code properties
    private int _amountInInt;
    
    // sponsorship
    private string YourName { get; set; }
    private string Amount { get; set; } = 50.ToString();
    private Racer Racer { get; set; }
    private ObservableCollection<Racer> Racers { get; set; }
    // card
    private string Card { get; set; }
    private string CardNumber { get; set; }
    private string ExpireDateMonth { get; set; } = DateTime.Today.Month.ToString();
    private string ExpireDateYear { get; set; } = DateTime.Today.Year.ToString();
    private string CVC { get; set; }

    private string? NameOfFund
    {
        get
        {
            NameOfFundGetting();
            return _nameOfFund;
        }
        set => _nameOfFund = value;
    }
    
    private int AmountInInt
    {
        get
        {
            try
            {
                int amountInInt = Int32.Parse(Amount);
                return amountInInt;
            }
            catch (Exception e) { return 0; }
        }
        set
        {
            _amountInInt = value;
            Amount = _amountInInt.ToString();
        }
    }
    
    private string? AmountInDollars
    {
        get => (AmountInInt <= 99) ? "$ " + AmountInInt : "$ 99 <";
        set => _amountInDollars = value;
    }

    public SponsorOfRacersPageViewModel(IPageNavigation? container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();

        Racers = new(Db.Racers);

        OnClickAmountPlus = ReactiveCommand.Create(() => { AmountInInt += 10; });
        OnClickAmountMinus = ReactiveCommand.Create(() => { if (AmountInInt > 10) AmountInInt -= 10; });
        OnClickPay = ReactiveCommand.Create(() => Pay(Card, CardNumber, ExpireDateMonth, 
            ExpireDateYear, CVC, Db, YourName, AmountInInt, container, AmountInDollars, Racer, NameOfFund));
        OnClickCancel = ReactiveCommand.Create(() => Cancel(container));
    }

    private void NameOfFundGetting()
    {
        if (_nameOfFund == null) NameOfFund = "Фонд собак";
        // logic of getting name of fund
    }

    private void Cancel(IPageNavigation container)
    {
        container.Back();
    }

    private void Pay(string cardOwner, string cardNumber, string expireDateMonth, string expireDateYear, string cvc, 
        ApplicationContext db, string sponsorName, int amount, IPageNavigation container, string amointInDollars,
        Racer racer, string nameOfFund)
    {
        bool add = false;
        try
        {
            int cvcInInt = Int32.Parse(cvc);
            int expireDateMonthInInt = Int32.Parse(expireDateMonth);
            int expireDateYearInInt = Int32.Parse(expireDateYear);
            Card card = new Card(cardOwner, cardNumber, expireDateMonthInInt, expireDateYearInInt, cvcInInt);
            if (card.IsValid())
                add = true;
        } catch (Exception e) { /*ignored*/ }

        if (add)
        {
            Sponsorship sponsorship = new Sponsorship
            {
                SponsorName = sponsorName,
                Amount = amount
            };
            db.Sponsorships?.Add(sponsorship);
            db.SaveChanges();
            container.OpnConfirmationOfSponsorshipPage(amointInDollars, racer, nameOfFund);
        }
    }
}    

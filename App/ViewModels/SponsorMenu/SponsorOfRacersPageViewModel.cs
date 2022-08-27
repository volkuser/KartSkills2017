using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using App.Models;
using App.Models.FromDatabase;
using ReactiveUI;
using Splat;

namespace App.ViewModels.SponsorMenu;

public class SponsorOfRacersPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "sponsorOfRacers";
    public IScreen HostScreen { get; }
    private ApplicationContext Db { get; set; }
    
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
    private string? YourName { get; set; }
    private string Amount { get; set; } = 50.ToString();
    private Racer? Racer { get; set; }
    private ObservableCollection<Racer>? Racers { get; set; }
    // card
    private string? Card { get; set; }
    private string? CardNumber { get; set; }
    private string ExpireDateMonth { get; set; } = DateTime.Today.Month.ToString();
    private string ExpireDateYear { get; set; } = DateTime.Today.Year.ToString();
    private string? CVC { get; set; }

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
                var amountInInt = int.Parse(Amount);
                return amountInInt;
            }
            catch (Exception) { return 0; }
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

    public SponsorOfRacersPageViewModel(IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();

        if (Db.Racers != null) Racers = new ObservableCollection<Racer>(Db.Racers!);

        OnClickAmountPlus = ReactiveCommand.Create(() => { AmountInInt += 10; });
        OnClickAmountMinus = ReactiveCommand.Create(() => { if (AmountInInt > 10) AmountInInt -= 10; });
        OnClickPay = ReactiveCommand.Create(() =>
        {
            if (AmountInDollars == null) return;
            if (NameOfFund != null)
                Pay(Card, CardNumber, ExpireDateMonth, ExpireDateYear, CVC, Db, YourName, 
                    AmountInInt, container, AmountInDollars, Racer, NameOfFund);
        });
        OnClickCancel = ReactiveCommand.Create(container.Back);
    }

    private void NameOfFundGetting()
    {
        if (_nameOfFund == null) NameOfFund = "Фонд собак";
        // logic of getting name of fund
    }

    private void Pay(string? cardOwner, string? cardNumber, string expireDateMonth, string expireDateYear, string? cvc, 
        ApplicationContext db, string? sponsorName, int amount, IPageNavigation container, string amountInDollars,
        Racer? racer, string nameOfFund)
    {
        bool add = false;
        try
        {
            if (cvc != null)
            {
                var cvcInInt = int.Parse(cvc);
                var expireDateMonthInInt = int.Parse(expireDateMonth);
                var expireDateYearInInt = int.Parse(expireDateYear);
                Card card = new ()
                {
                    CardOwner = cardOwner,
                    CardNumber = cardNumber,
                    ExpireDateMonth = expireDateMonthInInt, 
                    ExpireDateYear = expireDateYearInInt, 
                    CVC = cvcInInt
                };
                if (card.IsValid())
                    add = true;
            }
        } catch (Exception) { /*ignored*/ }

        if (!add) return;
        if (racer != null)
        {
            var sponsorship = new Sponsorship
            {
                SponsorName = sponsorName,
                Amount = amount,
                ID_Racer = racer.ID_Racer,
                Racer = racer
            };
            db.Sponsorships?.Add(sponsorship);
        }

        db.SaveChanges();
        container.OpnConfirmationOfSponsorshipPage(amountInDollars, racer, nameOfFund);
    }
}    

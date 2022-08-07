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
    
    public bool VisibleBtnBack { get; } = true;
    
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
    public string Card { get; set; }
    public string CardNumber { get; set; }
    public string ExpireDateMonth { get; set; } = DateTime.Today.Month.ToString();
    public string ExpireDateYear { get; set; } = DateTime.Today.Year.ToString();
    public string CVC { get; set; }

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

    public SponsorOfRacersPageViewModel(IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.getInstance();

        Racers = new(Db.Racers);

        OnClickAmountPlus = ReactiveCommand.Create(() => { AmountInInt += 10; });
        OnClickAmountMinus = ReactiveCommand.Create(() => { if (AmountInInt > 10) AmountInInt -= 10; });
        OnClickPay = ReactiveCommand.Create(() => Pay(Card, CardNumber, ExpireDateMonth, 
            ExpireDateYear, CVC, Db, YourName, AmountInInt));
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
        ApplicationContext db, string sponsorName, int amount)
    {
        string message = "Данные карты не валидны!";
        try
        {
            int cvcInInt = Int32.Parse(cvc);
            int expireDateMonthInInt = Int32.Parse(expireDateMonth);
            int expireDateYearInInt = Int32.Parse(expireDateYear);
            Card card = new Card(cardOwner, cardNumber, expireDateMonthInInt, expireDateYearInInt, cvcInInt);
            if (card.IsValid()) message = "Спасибо за спонсорство!";
        } catch (Exception e) { }

        Sponsorship sponsorship = new Sponsorship();
        sponsorship.SponsorName = sponsorName;
        sponsorship.Amount = amount;
        db.Sponsorships.Add(sponsorship);
        db.SaveChanges();
        
        var messageBox = MessageBox.Avalonia.MessageBoxManager
            .GetMessageBoxStandardWindow("Спонсорство", message);
        messageBox.Show();
    }
}    

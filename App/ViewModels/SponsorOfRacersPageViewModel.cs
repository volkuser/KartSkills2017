using System.Windows.Input;
using ReactiveUI;
using Splat;

namespace App.ViewModels;

public class SponsorOfRacersPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "/sponsorOfRacers";
    public IScreen HostScreen { get; }
    
    public bool VisibleBtnBack { get; } = true;
    
    // commands
    private ICommand OnClickAmountPlus { get; set; }
    private ICommand OnClickAmountMinus { get; set; }

    private string? _nameOfFund;
    private string? _amountInDollars;
    private int _amount = 50;
    
    private string? NameOfFund
    {
        get
        {
            NameOfFundGetting();
            return _nameOfFund;
        }
        set => _nameOfFund = value;
    }
    
    private string? AmountInDollars
    {
        get => (Amount < 99) ? "$ " + Amount : "$ 99 >";
        set => _amountInDollars = value;
    }

    private int Amount
    {
        get => _amount;
        set => _amount = value;
    }

    public SponsorOfRacersPageViewModel(IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();

        OnClickAmountPlus = ReactiveCommand.Create(() => { Amount += 10; });
        OnClickAmountMinus = ReactiveCommand.Create(() => { Amount -= 10; });
    }

    private void NameOfFundGetting()
    {
        if (_nameOfFund == null) NameOfFund = "Фонд собак";
        // logic of getting name of fund
    }
}    

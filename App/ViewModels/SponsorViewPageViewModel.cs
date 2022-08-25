using System.Collections.Generic;
using System.Collections.ObjectModel;
using App.Models;
using ReactiveUI;
using Splat;

namespace App.ViewModels;

public class SponsorViewPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "sponsorView";
    public IScreen HostScreen { get; }
    private ApplicationContext Db { get; set; }
    
    private int CharityCount { get; set; }
    private string GlobalAmount { get; set; }

    private ObservableCollection<Charity> Charities { get; set; } = new();

    public SponsorViewPageViewModel(IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();

        Charities = NewCharityLogoAddresses(Db);

        CharityCount = Charities.Count;
        GlobalAmount = "$" + GetGlobalAmount(Db);
    }

    private decimal GetGlobalAmount(ApplicationContext db)
    {
        decimal amount = 0;

        List<Sponsorship> sponsorships = new (db.Sponsorships);
        foreach (var sponsorship in sponsorships)
            amount += sponsorship.Amount;

        return amount;
    }

    private ObservableCollection<Charity> NewCharityLogoAddresses(ApplicationContext db)
    {
        ObservableCollection<Charity> charities = new(Db.Charities);
        
        foreach (var charity in charities)
        {
            string fileName;
            if (charity.Charity_Logo.Equals("Red-Cross.png"))
                fileName = "/Assets/Images/CharityLogos/the-red-cross-logo.png";
            else fileName = "/Assets/Images/CharityLogos/" + charity.Charity_Logo;
            charity.FullCharity_Logo = fileName;
        }

        return charities;
    }
}
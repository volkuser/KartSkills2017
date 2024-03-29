using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using App.Models;
using App.Models.FromDatabase;
using ReactiveUI;
using Splat;

namespace App.ViewModels.CoordinatorMenu;

public class SponsorViewPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "sponsorView";
    public IScreen HostScreen { get; }
    private ApplicationContext Db { get; set; }
    
    private int CharityCount { get; set; }
    private string GlobalAmount { get; set; }

    private ObservableCollection<Charity> Charities { get; set; }

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
        if (db.Sponsorships == null) return 0;
        List<Sponsorship> sponsorships = new (db.Sponsorships);

        return sponsorships.Sum(sponsorship => sponsorship.Amount);
    }

    private ObservableCollection<Charity> NewCharityLogoAddresses(ApplicationContext db)
    {
        if (db.Charities == null) return new ObservableCollection<Charity>(); // empty collection
        ObservableCollection<Charity> charities = new(db.Charities!);
        
        foreach (var charity in charities)
        {
            string fileName;
            if (charity.Charity_Logo is "Red-Cross.png")
                fileName = "/Assets/Images/CharityLogos/the-red-cross-logo.png";
            else fileName = "/Assets/Images/CharityLogos/" + charity.Charity_Logo;
            charity.FullCharity_Logo = fileName;
        }

        return charities;
    }
}
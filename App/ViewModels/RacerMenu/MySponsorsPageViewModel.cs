using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using App.Models;
using App.Models.FromDatabase;
using ReactiveUI;
using Splat;

namespace App.ViewModels.RacerMenu;

public class MySponsorsPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "mySponsors";
    public IScreen HostScreen { get; }
    private ApplicationContext Db { get; set; }

    private ObservableCollection<Sponsorship>? Sponsorships { get; set; }
    private string? FinalAmount { get; set; }
    
    public MySponsorsPageViewModel(User? currentUser, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();

        if (Db.Racers != null)
        {
            var currentRacer = Db.Racers.FirstOrDefault(x => x != null && x.Last_Name != null 
                                                                       && x.First_Name != null 
                                                                       && x.First_Name.Equals(currentUser.First_Name) 
                                                                       && x.Last_Name.Equals(currentUser.Last_Name));
            if (Db.Sponsorships != null)
                Sponsorships = new ObservableCollection<Sponsorship>(Db.Sponsorships.Where(x
                    => currentRacer != null && x.ID_Racer.Equals(currentRacer.ID_Racer)));
        }

        if (Sponsorships != null) FinalAmount = GetFinalMountForView(Sponsorships);
    }

    private string GetFinalMountForView(IReadOnlyCollection<Sponsorship>? sponsorships)
    {
        decimal finalAmount = 0;
        if (sponsorships == null) return "Всего $" + finalAmount;
        finalAmount = sponsorships.Sum(sponsorship => sponsorship.Amount);
        return "Всего $" + finalAmount;
    }
}
using System.Collections.ObjectModel;
using System.Linq;
using App.Models;
using ReactiveUI;
using Splat;

namespace App.ViewModels;

public class MySponsorsPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "mySponsors";
    public IScreen HostScreen { get; }
    private ApplicationContext Db { get; set; }

    private ObservableCollection<Sponsorship> Sponsorships { get; set; }
    private string FinalAmount { get; set; }
    
    public MySponsorsPageViewModel(User currentUser, IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();
        
        Racer currentRacer = Db.Racers.FirstOrDefault(x => x.First_Name.Equals(currentUser.First_Name)
                                                           && x.Last_Name.Equals(currentUser.Last_Name));
        Sponsorships = new(Db.Sponsorships.Where(x
            => x.ID_Racer.Equals(currentRacer.ID_Racer)));

        FinalAmount = GetFinalMountForView(Sponsorships);
    }

    private string GetFinalMountForView(ObservableCollection<Sponsorship> sponsorships)
    {
        decimal finalAmount = 0;
        foreach (var sponsorship in sponsorships) 
            finalAmount += sponsorship.Amount;
        return "Всего $" + finalAmount;
    }
}
using System.Collections.ObjectModel;
using App.Models;
using App.Models.FromDatabase;
using ReactiveUI;
using Splat;

namespace App.ViewModels.InformationMenu;

public class CharityListPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "charityList";
    public IScreen HostScreen { get; }
    private ApplicationContext Db { get; set; }
    
    private ObservableCollection<Charity>? Charities { get; set; }

    public CharityListPageViewModel(IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();

        if (Db.Charities != null) Charities = new(Db.Charities!);

        if (Charities != null) NewCharityLogoAddresses(Charities);
    }

    private void NewCharityLogoAddresses(ObservableCollection<Charity>? charities)
    {
        if (charities != null)
            foreach (var charity in charities)
            {
                string fileName;
                if (charity.Charity_Logo is "Red-Cross.png")
                    fileName = "/Assets/Images/CharityLogos/the-red-cross-logo.png";
                else
                    fileName = "/Assets/Images/CharityLogos/" + charity.Charity_Logo;
                charity.FullCharity_Logo = fileName;
            }
    }
}
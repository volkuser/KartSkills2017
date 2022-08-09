using System.Collections.ObjectModel;
using System.IO;
using App.Models;
using ReactiveUI;
using Splat;

namespace App.ViewModels;

public class CharityListPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "/charityList";
    public IScreen HostScreen { get; }
    private ApplicationContext Db;
    
    public bool VisibleBtnBack { get; } = true;
    
    private ObservableCollection<Charity> Charities { get; set; }

    public CharityListPageViewModel(IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();
        
        Charities = new(Db.Charities);
        
        NewCharityLogoAddresses(Charities);
    }

    private void NewCharityLogoAddresses(ObservableCollection<Charity> charities)
    {
        foreach (var charity in charities)
        {
            string fileName = "/Assets/Images/CharityLogos/" + charity.Charity_Logo;
            charity.FullCharity_Logo = fileName;
        }
    }
}
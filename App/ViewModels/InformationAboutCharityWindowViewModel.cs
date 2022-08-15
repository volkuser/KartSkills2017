using System.Collections.ObjectModel;
using App.Models;

namespace App.ViewModels;

public class InformationAboutCharityWindowViewModel : ViewModelBase
{
    public string UrlPathSegment => "informationAboutCharity";
    
    private string CharityName { get; set; }
    private string CharityDescription { get; set; }
    private string FullCharityLogo { get; set; }

    public InformationAboutCharityWindowViewModel(Charity charity)
    {
        CharityName = charity.Charity_Name;
        CharityDescription = charity.Charity_Description;

        ApplicationContext db = Singleton.GetInstance();
        ObservableCollection<Charity> charities = new(db.Charities);
        NewCharityLogoAddresses(charities);
        FullCharityLogo = charity.FullCharity_Logo;
    }
    
    private void NewCharityLogoAddresses(ObservableCollection<Charity> charities)
    {
        foreach (var charity in charities)
        {
            string fileName;
            if (charity.Charity_Logo.Equals("Red-Cross.png"))
                fileName = "/Assets/Images/CharityLogos/the-red-cross-logo.png";
            else
                fileName = "/Assets/Images/CharityLogos/" + charity.Charity_Logo;
            charity.FullCharity_Logo = fileName;
        }
    }
}
namespace App.ViewModels.RacerMenu;

public class InformationAboutContactsWindowViewModel : ViewModelBase
{
    public string UrlPathSegment => "informationAboutContacts";
    
    private string Phone { get; set; } 
    private string Email { get; set; }

    public InformationAboutContactsWindowViewModel(string email)
    {
        Phone = " +7 999 999 99 99 ";
        Email = " " + email;
    }
}
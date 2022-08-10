using System.Threading.Tasks;
using App.Models;

namespace App.ViewModels;

public interface IPageNavigation
{
    public void OpnMainMenuPage();
    public void OpnSponsorOfRacersPage();
    public void OpnConfirmationOfSponsorshipPage(string amountInDollars, Racer racer, string nameOfFund);
    public void OpnDetailedInformationPage();
    public void OpnCharityListPage();
    public void OpnAuthorizationMenuPage();
    public void OpnRacerMenuPage(User user);
    public Task OpnInformationAboutContactsWindow(string email);
    public void OpnCoordinatorMenuPage();
    public void OpnAdministratorMenuPage();

    public void Back();
}
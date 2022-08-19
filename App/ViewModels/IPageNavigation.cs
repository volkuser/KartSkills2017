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
    public void OpnVerificationOfPreviouslyRacersPage();
    public void OpnRacerRegistrationPage();
    public Task OpnOpenFileDialog();
    public string GetPathToImage();
    public void OpnRaceRegistrationPage(User currentUser);
    public Task OpnInformationAboutCharityWindow(Charity charity);
    public void OpnConfirmationOfRacerRegistrationPage();
    public void OpnProfileEditingPage(User currentUser);
    public void OpnMyResultsPage(User currentUser);
    public void OpnPastRaceResultsPage();
    public void OpnKartSkills2017Page();

    public void Back();
}
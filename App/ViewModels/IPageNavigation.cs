using System.Threading.Tasks;
using App.Models;
using Avalonia.Controls;

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
    public void OpnInventoryPage();
    public void OpnInventoryIncomingPage();
    public void OpnRaceMapPage();
    public void OpnCharityControlPage();
    public void OpnCharityAddingOrEditingPage(Charity? charity = null);
    public void OpnVolunteerControlPage();
    public void OpnVolunteerLoadPage();
    public void OpnMySponsorsPage(User currentUser);
    public Task OpnRacerCardWindow(Racer currentRacer);
    public void OpnRacerControlPage();
    public void OpnSponsorViewPage();
    public void OpnReportPrintPage();

    public void Back();
}
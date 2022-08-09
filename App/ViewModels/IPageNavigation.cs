using App.Models;

namespace App.ViewModels;

public interface IPageNavigation
{
    public void OpnMainMenuPage();
    public void OpnSponsorOfRacersPage();
    public void OpnConfirmationOfSponsorshipPage(string amountInDollars, Racer racer, string nameOfFund);
    public void OpnDetailedInformationPage();
    public void OpnCharityListPage();

    public void Back();
}
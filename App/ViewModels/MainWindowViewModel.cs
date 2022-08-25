using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Windows.Input;
using App.Models.FromDatabase;
using App.ViewModels.AdministratorMenu;
using App.ViewModels.CoordinatorMenu;
using App.ViewModels.InformationMenu;
using App.ViewModels.RacerMenu;
using App.ViewModels.SponsorMenu;
using ReactiveUI;

namespace App.ViewModels
{
    [DataContract]
    public class MainWindowViewModel : ReactiveObject, IScreen, IPageNavigation
    {
        // commands
        private ICommand OnClickBtnBack { get; set; }
        private ICommand OnClickBtnLogout { get; set; }
        
        // properties of element on view
        private bool VisibleBtnBack { get; set; }
        private bool VisibleBtnLogout { get; set; }
        private List<bool> VisibilityBtnBackHistory { get; set; } = new();
        private List<bool> VisibilityBtnLogoutHistory { get; set; } = new();

        // other
        private string? _displayTimer;

        [DataMember]
        public RoutingState Router { get; set; } = new();

        private string? DisplayTimer
        {
            get
            {
                TimerCalculation();
                return _displayTimer;
            }
            set => _displayTimer = value;
        }

        private async Task TimerCalculation()
        {
            var beginDateTime = new DateTime(2027, 6, 20);
            while (DateTime.Now < beginDateTime)
            {
                await Task.Delay(1000);
                var currentDateTime = DateTime.Now;
                var finalTimeSpan = beginDateTime.Subtract(currentDateTime);
                var finalYear = beginDateTime.Year - currentDateTime.Year;
                int finalMonth;
                if (currentDateTime.Month > beginDateTime.Month)
                {
                    finalYear--;
                    finalMonth = beginDateTime.Month + 12 - currentDateTime.Month;
                } else finalMonth = beginDateTime.Month - currentDateTime.Month;
                var finalDay = currentDateTime.Day > beginDateTime.Day 
                    ? DateTime.DaysInMonth(beginDateTime.Year, beginDateTime.Month - 1) + beginDateTime.Day
                      - currentDateTime.Day
                    : beginDateTime.Day - currentDateTime.Day;
                DisplayTimer = "До начала события осталось " + finalYear + " лет, " + finalMonth + " месяцев, " 
                                + finalDay + " дней, " + finalTimeSpan.Hours + " часов, " + finalTimeSpan.Minutes 
                               + " минут, " + finalTimeSpan.Seconds + " секунд";
            }
        }

        public MainWindowViewModel()
        {
            Singleton.GetInstance();
            OpnMainMenuPage();

            OnClickBtnBack = ReactiveCommand.Create(Back);
            OnClickBtnLogout = ReactiveCommand.Create(OpnAuthorizationMenuPage);
        }

        public void OpnMainMenuPage()
        {
            var viewModel = new MainMenuPageViewModel(this);
            Router.Navigate.Execute(viewModel);
            AdditionForHistory(false);
        }

        public void OpnSponsorOfRacersPage()
        {
            var viewModel = new SponsorOfRacersPageViewModel(this);
            Router.Navigate.Execute(viewModel);
            AdditionForHistory(true);
        }

        public void OpnConfirmationOfSponsorshipPage(string amountInDollars, Racer? racer, string nameOfFund)
        {
            if (racer != null)
            {
                var viewModel 
                    = new ConfirmationOfSponsorshipPageViewModel(this, amountInDollars, racer, nameOfFund);
                Router.Navigate.Execute(viewModel);
            }

            AdditionForHistory(false);
        }

        public void OpnDetailedInformationPage()
        {
            var viewModel = new DetailedInformationPageViewModel(this);
            Router.Navigate.Execute(viewModel);
            AdditionForHistory(true);
        }
        
        public void OpnCharityListPage()
        {
            var viewModel = new CharityListPageViewModel();
            Router.Navigate.Execute(viewModel);
            AdditionForHistory(true);
        } 
        
        public void OpnAuthorizationMenuPage()
        {
            var viewModel = new AuthorizationMenuPageViewModel(this);
            Router.Navigate.Execute(viewModel);
            AdditionForHistory(false);
        }
        
        public void OpnRacerMenuPage(User? user)
        {
            var viewModel = new RacerMenuPageViewModel(user, this);
            Router.Navigate.Execute(viewModel);
            AdditionForHistory(false, true);
        }
        
        public Interaction<InformationAboutContactsWindowViewModel, 
            InformationAboutContactsWindowViewModel?> ShowInformationAboutContactsWindow { get; } = new ();
        public async Task OpnInformationAboutContactsWindow(string email)
        {
            var viewModel = new InformationAboutContactsWindowViewModel(email);
            await ShowInformationAboutContactsWindow.Handle(viewModel);
        }
        
        public void OpnCoordinatorMenuPage()
        {
            var viewModel = new CoordinatorMenuPageViewModel(this);
            Router.Navigate.Execute(viewModel);
            AdditionForHistory(false, true);
        }
        
        public void OpnAdministratorMenuPage()
        {
            var viewModel = new AdministratorMenuPageViewModel(this);
            Router.Navigate.Execute(viewModel);
            AdditionForHistory(false, true);
        }

        public void OpnVerificationOfPreviouslyRacersPage()
        {
            var viewModel = new VerificationOfPreviouslyEnteredRacersPageViewModel(this);
            Router.Navigate.Execute(viewModel);
            AdditionForHistory(true);
        }
        
        public void OpnRacerRegistrationPage()
        {
            var viewModel = new RacerRegistrationPageViewModel(this);
            Router.Navigate.Execute(viewModel);
            AdditionForHistory(true);
        }

        private string? PathToImage { get; set; }
        public Interaction<Unit, string?> ShowOpenFileDialog { get; } = new ();
        public async Task OpnOpenFileDialog()
        {
            var fileName = await ShowOpenFileDialog.Handle(Unit.Default);

            if (fileName != null) PathToImage = fileName;
        }
        public string? GetPathToImage()
        {
            return PathToImage;
        }
        
        public void OpnRaceRegistrationPage(User? currentUser)
        {
            var viewModel = new RaceRegistrationPageViewModel(currentUser, this);
            Router.Navigate.Execute(viewModel);
            AdditionForHistory(true, true);
        }

        public Interaction<InformationAboutCharityWindowViewModel, 
            InformationAboutCharityWindowViewModel?> ShowInformationAboutCharityWindow { get; } = new ();
        public async Task OpnInformationAboutCharityWindow(Charity? charity)
        {
            var viewModel = new InformationAboutCharityWindowViewModel(charity);
            await ShowInformationAboutCharityWindow.Handle(viewModel);
        }

        public void OpnConfirmationOfRacerRegistrationPage()
        {
            var viewModel = new ConfirmationOfRacerRegistrationPageViewModel(this);
            Router.Navigate.Execute(viewModel);
            AdditionForHistory(false, true);
        }
        
        public void OpnProfileEditingPage(User? currentUser)
        {
            var viewModel = new ProfileEditingPageViewModel(currentUser, this);
            Router.Navigate.Execute(viewModel);
            AdditionForHistory(false, true);
        }
        
        public void OpnMyResultsPage(User? currentUser)
        {
            var viewModel = new MyResultsPageViewModel(currentUser, this);
            Router.Navigate.Execute(viewModel);
            AdditionForHistory(true, true);
        }
        
        public void OpnPastRaceResultsPage()
        {
            var viewModel = new PastRaceResultsPageViewModel(this);
            Router.Navigate.Execute(viewModel);
            AdditionForHistory(true);
        }
        
        public void OpnKartSkills2017Page()
        {
            var viewModel = new KartSkills2017PageViewModel(this);
            Router.Navigate.Execute(viewModel);
            AdditionForHistory(true);
        }
        
        public void OpnInventoryPage()
        {
            var viewModel = new InventoryPageViewModel(this);
            Router.Navigate.Execute(viewModel);
            AdditionForHistory(true);
        }
        
        public void OpnInventoryIncomingPage()
        {
            var viewModel = new InventoryIncomingPageViewModel(this);
            Router.Navigate.Execute(viewModel);
            AdditionForHistory(false);
        }
        
        public void OpnRaceMapPage()
        {
            var viewModel = new RaceMapPageViewModel();
            Router.Navigate.Execute(viewModel);
            AdditionForHistory(true);
        }
        
        public void OpnCharityControlPage()
        {
            var viewModel = new CharityControlPageViewModel(this);
            Router.Navigate.Execute(viewModel);
            AdditionForHistory(true, true);
        }
        
        public void OpnCharityAddingOrEditingPage(Charity? charity = null)
        {
            var viewModel = new CharityAddingOrEditingPageViewModel(this, charity);
            Router.Navigate.Execute(viewModel);
            AdditionForHistory(false, true);
        }
        
        public void OpnVolunteerControlPage()
        {
            var viewModel = new VolunteerControlPageViewModel(this);
            Router.Navigate.Execute(viewModel);
            AdditionForHistory(true, true);
        }
        
        public void OpnVolunteerLoadPage()
        {
            var viewModel = new VolunteerLoadPageViewModel(this);
            Router.Navigate.Execute(viewModel);
            AdditionForHistory(false);
        }
        
        public void OpnMySponsorsPage(User? currentUser)
        {
            var viewModel = new MySponsorsPageViewModel(currentUser, this);
            Router.Navigate.Execute(viewModel);
            AdditionForHistory(true, true);
        }
        
        public Interaction<RacerCardWindowViewModel, RacerCardWindowViewModel?> ShowRacerCardWindow { get; } = new ();
        public async Task OpnRacerCardWindow(Racer currentRacer)
        {
            var viewModel = new RacerCardWindowViewModel(currentRacer);
            await ShowRacerCardWindow.Handle(viewModel);
        }
        
        public void OpnRacerControlPage()
        {
            var viewModel = new RacerControlPageViewModel(this);
            Router.Navigate.Execute(viewModel);
            AdditionForHistory(true, true);
        }
        
        public void OpnSponsorViewPage()
        {
            var viewModel = new SponsorViewPageViewModel(this);
            Router.Navigate.Execute(viewModel);
            AdditionForHistory(true, true);
        }
        
        public void OpnReportPrintPage()
        {
            var viewModel = new ReportPrintPageViewModel(this);
            Router.Navigate.Execute(viewModel);
            AdditionForHistory(false);
        }
        
        public void Back()
        {
            Router.NavigateBack.Execute();
            SetVisibleBtnBack(GetLastVisibleBtnBackHistory());
            SetVisibleBtnLogout(GetLastVisibleBtnLogoutHistory());
        }

        private void AdditionForHistory(bool visibleBtnBack, bool visibleBtnLogout = false)
        {
            VisibilityBtnBackHistory.Add(visibleBtnBack);
            SetVisibleBtnBack(visibleBtnBack);
            VisibilityBtnLogoutHistory.Add(visibleBtnLogout);
            SetVisibleBtnLogout(visibleBtnLogout);
        }
        private bool GetLastVisibleBtnBackHistory()
        {
            VisibilityBtnBackHistory.RemoveAt(VisibilityBtnBackHistory.Count - 1);
            return VisibilityBtnBackHistory[^1];
        }
        private bool GetLastVisibleBtnLogoutHistory()
        {
            VisibilityBtnLogoutHistory.RemoveAt(VisibilityBtnLogoutHistory.Count - 1);
            return VisibilityBtnLogoutHistory[^1];
        }
        private void SetVisibleBtnBack(bool visible)
        {
            VisibleBtnBack = visible; 
        }
        private void SetVisibleBtnLogout(bool visible)
        {
            VisibleBtnLogout = visible; 
        }
    }
}
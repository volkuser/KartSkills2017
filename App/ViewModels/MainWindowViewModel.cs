using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Windows.Input;
using App.Models;
using App.Views.Pages;
using ReactiveUI;

namespace App.ViewModels
{
    [DataContract]
    public class MainWindowViewModel : ReactiveObject, IScreen, IPageNavigation
    {
        private RoutingState _router = new();

        // commands
        private ICommand OnClickBack { get; set; }
        
        // properties of element on view
        private bool VisibleBtnBack { get; set; }
        private List<bool> VisibilityHistory { get; set; } = new();

        // other
        private string? _displayTimer;

        [DataMember]
        public RoutingState Router
        {
            get => _router;
            set => _router = value;
        }

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

            OnClickBack = ReactiveCommand.Create(Back);
        }

        public void OpnMainMenuPage()
        {
            MainMenuPageViewModel viewModel = new MainMenuPageViewModel(this);
            Router.Navigate.Execute(viewModel);
            AdditionForHistory(viewModel.VisibleBtnBack);
        }

        public void OpnSponsorOfRacersPage()
        {
            SponsorOfRacersPageViewModel viewModel = new SponsorOfRacersPageViewModel(this);
            Router.Navigate.Execute(viewModel);
            AdditionForHistory(viewModel.VisibleBtnBack);
        }

        public void OpnConfirmationOfSponsorshipPage(string amountInDollars, Racer racer, string nameOfFund)
        {
            ConfirmationOfSponsorshipPageViewModel viewModel 
                = new ConfirmationOfSponsorshipPageViewModel(this, amountInDollars, racer, nameOfFund);
            Router.Navigate.Execute(viewModel);
            AdditionForHistory(viewModel.VisibleBtnBack);
        }

        public void OpnDetailedInformationPage()
        {
            DetailedInformationPageViewModel viewModel 
                = new DetailedInformationPageViewModel(this);
            Router.Navigate.Execute(viewModel);
            AdditionForHistory(viewModel.VisibleBtnBack);
        }
        
        public void OpnCharityListPage()
        {
            CharityListPageViewModel viewModel = new CharityListPageViewModel(this);
            Router.Navigate.Execute(viewModel);
            AdditionForHistory(viewModel.VisibleBtnBack);
        } 
        
        public void OpnAuthorizationMenuPage()
        {
            AuthorizationMenuPageViewModel viewModel = new AuthorizationMenuPageViewModel(this);
            Router.Navigate.Execute(viewModel);
            AdditionForHistory(viewModel.VisibleBtnBack);
        }
        
        public void OpnRacerMenuPage()
        {
            RacerMenuPageViewModel viewModel = new RacerMenuPageViewModel(this);
            Router.Navigate.Execute(viewModel);
            AdditionForHistory(viewModel.VisibleBtnBack);
        }
        
        public void OpnCoordinatorMenuPage()
        {
            CoordinatorMenuPageViewModel viewModel = new CoordinatorMenuPageViewModel(this);
            Router.Navigate.Execute(viewModel);
            AdditionForHistory(viewModel.VisibleBtnBack);
        }
        
        public void OpnAdministratorMenuPage()
        {
            AdministratorMenuPageViewModel viewModel = new AdministratorMenuPageViewModel(this);
            Router.Navigate.Execute(viewModel);
            AdditionForHistory(viewModel.VisibleBtnBack);
        }

        public void Back()
        {
            Router.NavigateBack.Execute();
            SetVisibleBtnBack(GetLastHistory());
        }

        private void AdditionForHistory(bool visible)
        {
            VisibilityHistory.Add(visible);
            SetVisibleBtnBack(visible);
        }
        private bool GetLastHistory()
        {
            VisibilityHistory.RemoveAt(VisibilityHistory.Count - 1);
            return VisibilityHistory[^1];
        }
        private void SetVisibleBtnBack(bool visible)
        {
            VisibleBtnBack = visible; 
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Windows.Input;
using App.Models;
using ReactiveUI;

namespace App.ViewModels
{
    [DataContract]
    public class MainWindowViewModel : ReactiveObject, IScreen, IPageNavigation
    {
        private RoutingState _router = new();

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

            OnClickBtnBack = ReactiveCommand.Create(Back);
            OnClickBtnLogout = ReactiveCommand.Create(OpnAuthorizationMenuPage);
        }

        public void OpnMainMenuPage()
        {
            MainMenuPageViewModel viewModel = new MainMenuPageViewModel(this);
            Router.Navigate.Execute(viewModel);
            AdditionForHistory(false);
        }

        public void OpnSponsorOfRacersPage()
        {
            SponsorOfRacersPageViewModel viewModel = new SponsorOfRacersPageViewModel(this);
            Router.Navigate.Execute(viewModel);
            AdditionForHistory(true);
        }

        public void OpnConfirmationOfSponsorshipPage(string amountInDollars, Racer racer, string nameOfFund)
        {
            ConfirmationOfSponsorshipPageViewModel viewModel 
                = new ConfirmationOfSponsorshipPageViewModel(this, amountInDollars, racer, nameOfFund);
            Router.Navigate.Execute(viewModel);
            AdditionForHistory(false);
        }

        public void OpnDetailedInformationPage()
        {
            DetailedInformationPageViewModel viewModel 
                = new DetailedInformationPageViewModel(this);
            Router.Navigate.Execute(viewModel);
            AdditionForHistory(true);
        }
        
        public void OpnCharityListPage()
        {
            CharityListPageViewModel viewModel = new CharityListPageViewModel(this);
            Router.Navigate.Execute(viewModel);
            AdditionForHistory(true);
        } 
        
        public void OpnAuthorizationMenuPage()
        {
            AuthorizationMenuPageViewModel viewModel = new AuthorizationMenuPageViewModel(this);
            Router.Navigate.Execute(viewModel);
            AdditionForHistory(false);
        }
        
        public void OpnRacerMenuPage(User user)
        {
            RacerMenuPageViewModel viewModel = new RacerMenuPageViewModel(user, this);
            Router.Navigate.Execute(viewModel);
            AdditionForHistory(false, true);
        }
        
        public Interaction<InformationAboutContactsWindowViewModel, InformationAboutContactsWindowViewModel?> ShowDialog { get; }
            = new ();
        public async Task OpnInformationAboutContactsWindow(string email)
        {
            var viewModel = new InformationAboutContactsWindowViewModel(email);
            var result = await ShowDialog.Handle(viewModel);
        }
        
        public void OpnCoordinatorMenuPage()
        {
            CoordinatorMenuPageViewModel viewModel = new CoordinatorMenuPageViewModel(this);
            Router.Navigate.Execute(viewModel);
            AdditionForHistory(false, true);
        }
        
        public void OpnAdministratorMenuPage()
        {
            AdministratorMenuPageViewModel viewModel = new AdministratorMenuPageViewModel(this);
            Router.Navigate.Execute(viewModel);
            AdditionForHistory(false, true);
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
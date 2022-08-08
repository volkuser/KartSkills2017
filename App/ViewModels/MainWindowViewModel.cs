using System;
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
        private ICommand OnClickBack { get; set; }
        
        // properties of element on view
        private bool VisibleBtnBack { get; set; }
        // 2 - not true (1), not false (0)
        private byte[] Visibility { get; set; } = new byte[2] { 2, 2 };

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
            MainMenuPageViewModel mainMenuPageViewModel = new MainMenuPageViewModel(this);
            Router.Navigate.Execute(mainMenuPageViewModel);
            SetVisibleBtnBack(mainMenuPageViewModel.VisibleBtnBack);
            SetVisibilityBtnBack(Visibility, mainMenuPageViewModel.VisibleBtnBack);
        }

        public void OpnSponsorOfRacersPage()
        {
            SponsorOfRacersPageViewModel sponsorOfRacersPageViewModel = new SponsorOfRacersPageViewModel(this);
            Router.Navigate.Execute(sponsorOfRacersPageViewModel);
            SetVisibleBtnBack(sponsorOfRacersPageViewModel.VisibleBtnBack); 
            SetVisibilityBtnBack(Visibility, sponsorOfRacersPageViewModel.VisibleBtnBack);
        }

        public void OpnConfirmationOfSponsorshipPage(string amountInDollars, Racer racer, string nameOfFund)
        {
            ConfirmationOfSponsorshipPageViewModel confirmationOfSponsorshipPageViewModel 
                = new ConfirmationOfSponsorshipPageViewModel(this, amountInDollars, racer, nameOfFund);
            Router.Navigate.Execute(confirmationOfSponsorshipPageViewModel);
            SetVisibleBtnBack(confirmationOfSponsorshipPageViewModel.VisibleBtnBack); 
            SetVisibilityBtnBack(Visibility, confirmationOfSponsorshipPageViewModel.VisibleBtnBack);
        }

        public void OpnDetailedInformationPage()
        {
            DetailedInformationPageViewModel detailedInformationPageViewModel = new DetailedInformationPageViewModel(this);
            Router.Navigate.Execute(detailedInformationPageViewModel);
            SetVisibleBtnBack(detailedInformationPageViewModel.VisibleBtnBack); 
            SetVisibilityBtnBack(Visibility, detailedInformationPageViewModel.VisibleBtnBack);
        }

        public void Back()
        {
            Router.NavigateBack.Execute();
            SetVisibleBtnBack(GetLastVisibleBtnBack(Visibility));
        }

        private void SetVisibleBtnBack(bool visible)
        {
            VisibleBtnBack = visible; 
        }

        private void SetVisibilityBtnBack(byte[] visibility, bool visible)
        {
            byte byteVisible = (byte) (visible ? 1 : 0);
            if (visibility[0] == 2) visibility[0] = byteVisible;
            else if (visibility[1] == 2) visibility[1] = byteVisible;
            else
            {
                byte buf = visibility[1];
                visibility[0] = buf;
                visibility[1] = byteVisible;
            }
        }
        private bool GetLastVisibleBtnBack(byte[] visibility)
        {
            bool visible = visibility[0] == 1;
            SetVisibilityBtnBack(Visibility, visible);
            return visible;
        }
    }
}
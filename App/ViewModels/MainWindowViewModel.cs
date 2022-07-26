using System;
using System.Threading.Tasks;
using ReactiveUI;

namespace App.ViewModels
{
    public class MainWindowViewModel : ReactiveObject, IScreen
    {
        public RoutingState Router { get; } = new();
        
        private string? _displayTimer;
        
        public string? DisplayTimer
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
            Router.Navigate.Execute(new MainMenuPageViewModel(this));
        }
    }
}
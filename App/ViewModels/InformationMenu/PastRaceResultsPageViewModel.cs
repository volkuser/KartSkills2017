using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using App.Models;
using App.Models.FromDatabase;
using App.Models.OnlyView;
using ReactiveUI;
using Splat;

namespace App.ViewModels.InformationMenu;

public class PastRaceResultsPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "pastRaceResults";
    public IScreen HostScreen { get; }
    private ApplicationContext Db { get; set; }

    private ICommand OnClickBtnSearch { get; set; }
    
    private ObservableCollection<Event?>? Events { get; set; }
    private Event? Event { get; set; }
    private ObservableCollection<Gender>? Genders { get; set; }
    private Gender? Gender { get; set; }
    private ObservableCollection<EventType?>? EventTypes { get; set; }
    private EventType? EventType { get; set; }
    private AgeCategory[] AgeCategories { get; set; } = {
        new () {
            To = 17,
            Title = "до 18"
        },
        new() {
            From = 18,
            To = 29,
            Title = "от 18 до 29"
        },
        new() {
            From = 30,
            To = 39,
            Title = "от 30 до 39"
        },
        new() {
            From = 40,
            To = 55,
            Title = "от 40 до 55"
        },
        new() {
            From = 56,
            To = 70,
            Title = "от 56 до 70"
        },
        new() {
            From = 70,
            Title = "более 70"
        }
    };
    private AgeCategory? AgeCategory { get; set; }
    
    private int RacerCount { get; set; }
    private int RacerWhoFinishCount { get; set; }
    private string? MediumTime { get; set; }

    private ObservableCollection<PastResult> PastResults { get; set; } = new();
    
    public PastRaceResultsPageViewModel(IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();

        if (Db.Events != null) Events = new(Db.Events);
        if (Db.Genders != null) Genders = new(Db.Genders);
        if (Db.EventTypes != null) EventTypes = new(Db.EventTypes);

        OnClickBtnSearch = ReactiveCommand.Create(() =>
        {
            PastResults = GetPastResults(Db, Event, EventType, AgeCategory, Gender, container);
            if (PastResults.Count <= 0) return;
            RacerCount = PastResults.Count;
            RacerWhoFinishCount = /*logic to getting required information*/ PastResults.Count;

            var time = PastResults.Sum(pastResult => pastResult.TimeS.Seconds + pastResult.TimeS.Minutes * 60 
                                                                              + pastResult.TimeS.Hours * 120);
            time /= PastResults.Count;
            var timeS = TimeSpan.FromSeconds(time);
            if (timeS.Hours > 0) MediumTime = timeS.Hours + "ч ";
            MediumTime += timeS.Minutes + "м " + timeS.Seconds + "c";
        });
    }

    private ObservableCollection<PastResult> GetPastResults(ApplicationContext db, Event? selectedEvent, 
        EventType? selectedEventType, AgeCategory? selectedAgeCategory, Gender? selectedGender, 
        IPageNavigation container)
    {
        ObservableCollection<PastResult> pastResults = new();

        if (selectedEvent == null || selectedEventType == null || selectedAgeCategory == null || selectedGender == null)
            return pastResults;
        if (db.Results == null) return pastResults;
        ObservableCollection<Result> results = new(db.Results.Where(x 
            => x.ID_Event.Equals(selectedEvent.ID_Event)));
        for (int i = 0; i < results.Count; i++)
            for (int j = i + 1; j < results.Count; j++)
                if (results[i].RaceTime > results[j].RaceTime)
                    (results[i], results[j]) = (results[j], results[i]);
    
        int counter = 0;
        foreach (var result in results)
        {
            if (db.Registrations == null) continue;
            var registration = db.Registrations.FirstOrDefault(x 
                => x.ID_Registration.Equals(result.ID_Registration));
            if (db.Racers == null) continue;
            {
                var racer = db.Racers.FirstOrDefault(x => x != null && registration != null 
                                                                    && x.ID_Racer.Equals(registration.ID_Racer));
                if (racer == null || !racer.Gender.Equals(selectedGender.ID_Gender) ||
                    !GetCurrentAgeCategory(db, racer)!.Equals(selectedAgeCategory)) continue;
                {
                    if (Db.Events == null) continue;
                    var currentEvent = Db.Events.FirstOrDefault(x => x.ID_Event.Equals(result.ID_Event));
                    if (currentEvent == null || !currentEvent.ID_Event.Equals(selectedEvent.ID_Event) ||
                        !currentEvent.ID_EventType.Equals(selectedEventType.ID_Event_type)) continue;
                    {
                        var pastResult = new PastResult
                        {
                            // position
                            Position = "#" + Convert.ToString(++counter)
                        };

                        // time
                        if (result.RaceTime.Hours > 0) pastResult.Time = result.RaceTime.Hours + "ч ";
                        pastResult.Time += result.RaceTime.Minutes + "м " + result.RaceTime.Seconds + "c";
                        pastResult.TimeS = result.RaceTime;
                        
                        // racer name
                        pastResult.RacerName = racer.First_Name + " " + racer.Last_Name;
                        
                        // command for opening racer card
                        pastResult.CmdRacerCard = ReactiveCommand.CreateFromTask(async
                            => Task.FromResult(container.OpnRacerCardWindow(racer)));
                        
                        // country
                        if (Db.Races != null)
                        {
                            var race = Db.Races.FirstOrDefault(x => x != null 
                                                                      && x.ID_Race.Equals(currentEvent.ID_Race));
                            pastResult.Country = race?.ID_Country;
                        }

                        pastResults.Add(pastResult);
                    }
                }
            }
        }

        return pastResults;
    }
    
    private AgeCategory? GetCurrentAgeCategory(ApplicationContext db, Racer currentRacer)
    {
        var racerAge = DateTime.Today.Year - currentRacer.DateOfBirth.Year;

        return AgeCategories.FirstOrDefault(ageCategory => ageCategory.From <= racerAge && racerAge <= ageCategory.To);
    }
}